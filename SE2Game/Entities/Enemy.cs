using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using SE2Game.Sprites;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game.Entities
{
    public class Enemy : Character
    {
       public int DamagePerHit { get { return 10; } }

        public Enemy(Vector position)
        {
            this.Position = position;
            this.Sprite = new Sprite("sprites/sprites.png", new Point(3, 0));
        }


        /// <summary>
        /// Function that determines which action the enemy should take.
        /// </summary>
        /// 
        
        public override void Move()
        {
            int speed = 2;

            if (this.Position.Y > World.Instance.Player.Position.Y && this.Position.X == World.Instance.Player.Position.X) { this.Position.Y = this.Position.Y - speed; } //up
            if (this.Position.Y > World.Instance.Player.Position.Y && this.Position.X < World.Instance.Player.Position.X) { this.Position.Y = this.Position.Y - speed; this.Position.X = this.Position.X + speed; } //up right
            if (this.Position.X < World.Instance.Player.Position.X && this.Position.Y == World.Instance.Player.Position.Y) { this.Position.X = this.Position.X + speed; } //right
            if (this.Position.Y > World.Instance.Player.Position.Y && this.Position.X > World.Instance.Player.Position.X) { this.Position.Y = this.Position.Y - speed; this.Position.X = this.Position.X - speed; } //up left
            if (this.Position.X > World.Instance.Player.Position.X && this.Position.Y == World.Instance.Player.Position.Y) { this.Position.X = this.Position.X - speed; } //left
            if (this.Position.Y < World.Instance.Player.Position.Y && this.Position.X < World.Instance.Player.Position.X) { this.Position.Y = this.Position.Y + speed; this.Position.X = this.Position.X + speed; } //down right
            if (this.Position.Y < World.Instance.Player.Position.Y && this.Position.X == World.Instance.Player.Position.X) { this.Position.Y = this.Position.Y + speed; } //down
            if (this.Position.Y < World.Instance.Player.Position.Y && this.Position.X > World.Instance.Player.Position.X) { this.Position.Y = this.Position.Y + speed; this.Position.X = this.Position.X - speed; } //down left    
        }
        
        /// <summary>
        /// Updates the position of the enemy.
        /// </summary>
        /// <param name="deltaTime">The number of seconds elapsed since the previous call.</param>
       
    }
}
