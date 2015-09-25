using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using SE2Game.Sprites;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game.Entities
{
    public class Character
    {
        private Sprite sprite;
        private Vector position = new Vector();
        private Vector direction = new Vector();
        private int maxSpeed = 100;

        /// <summary>
        /// The current sprite in the world.
        /// </summary>  
        public Sprite Sprite { get { return sprite; } set { sprite = value; } }

        /// <summary>
        /// The current position (center) of the sprite in the world.
        /// </summary>        
        public Vector Position { get { return position; } set { position = value; } }
        /// <summary>
        /// The current direction the sprite is heading to.
        /// </summary>   
        public Vector Directions { get { return direction; } set { direction = value; } }

        /// <summary>
        /// Gives the bounding box for the character. Not very smart, but it is
        /// sufficient for what is needed right now.
        /// </summary>
        public Rectangle BoundingBox
        {
            get
            {
                int hss = Sprite.Size / 2;
                int trim = 1; // Make the bounding box fit a little better
                return new Rectangle(Convert.ToInt32(Position.X) - hss + trim,
                                     Convert.ToInt32(Position.Y) - hss + trim,
                                     Sprite.Size - trim, Sprite.Size - trim);
            }
        }
        public void Draw(Graphics g)
        {
            g.DrawImage(sprite.Image, (Position - Sprite.Size / 2).ToPointF());
        }

        public virtual void Move()
        {
            direction.X = 0;
            direction.Y = 0;

            if (Util.IsKeyDown(Key.Up)) direction.Y = -1;
            else if (Util.IsKeyDown(Key.Left)) direction.X = -1;
            else if (Util.IsKeyDown(Key.Down)) direction.Y = 1;
            else if (Util.IsKeyDown(Key.Right)) direction.X = 1;
        }

        public void Update(float dt)
        {
            // Determine the action that is to be taken
            Move();

            // Update the sprite state to reflect that we are moving or not
            if (direction.X != 0 || direction.Y != 0)
            {
                sprite.ChangeState(Sprite.State.Moving);
            }
            else
            {
                sprite.ChangeState(Sprite.State.Idle);
            }

            if (sprite.SpriteState == Sprite.State.Moving)
            {
                Direction spriteDirection = Util.DetermineDirection(direction);
                Vector newPosition = new Vector(position);
                switch (spriteDirection)
                {
                    case Direction.Left: newPosition.X -= maxSpeed * dt; break;
                    case Direction.Right: newPosition.X += maxSpeed * dt; break;
                    case Direction.Up: newPosition.Y -= maxSpeed * dt; break;
                    case Direction.Down: newPosition.Y += maxSpeed * dt; break;
                }

                int hss = Sprite.Size / 2;
                newPosition.X = Math.Max(hss, Math.Min(World.Instance.Size.Width - hss, newPosition.X));
                newPosition.Y = Math.Max(hss, Math.Min(World.Instance.Size.Height - hss, newPosition.Y));

                Vector feetPosition = (newPosition + new Vector(0, Sprite.Size / 2.2));
                if (World.Instance.Map.Reachable(feetPosition))
                {
                    position = newPosition;
                }

                sprite.UpdateImage(spriteDirection);
            }
        }
    }
}
