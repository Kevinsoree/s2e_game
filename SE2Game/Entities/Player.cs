using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using SE2Game.Sprites;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game.Entities
{
    public class Player : Character
    {
        public int Hitpoints
        {
            get;
            private set;
        }

        public Player(Vector position)
        {
            this.Position = position;
            this.Sprite = new Sprite("sprites/sprites.png", new Point(0, 0));
            Hitpoints = 100;
        }

        public int Hit(Enemy hitBy)
        {
            int damageDealt = Math.Min(Hitpoints, hitBy.DamagePerHit);
            Hitpoints -= damageDealt;
            return damageDealt;
        }
    }
}
