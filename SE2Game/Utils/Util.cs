using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Input;

namespace SE2Game.Utils
{
    public static class Util
    {
        public static bool IsKeyDown(Key key)
        {
            return (Keyboard.GetKeyStates(key) & KeyStates.Down) > 0;
        }

        public static Direction DetermineDirection(Vector v)
        {
            if (Math.Abs(v.X) >= Math.Abs(v.Y))
            {
                if (v.X >= 0)
                {
                    return Direction.Right;
                }
                return Direction.Left;
            }
            else
            {
                if (v.Y >= 0)
                {
                    return Direction.Down;
                }
                return Direction.Up;
            }
        }
    }
}
