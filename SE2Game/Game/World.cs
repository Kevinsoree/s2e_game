using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using SE2Game.Entities;
using SE2Game.Utils;

namespace SE2Game.Game
{
    public class World
    {
#region Fields and Properties
        /// <summary>
        /// Returns the number of elapsed milliseconds since the game started.
        /// </summary>
        public long Time { get { return stopwatch.ElapsedMilliseconds; } }
        /// <summary>
        /// Gets the size of the world in pixels.
        /// </summary>
        public Size Size { get; private set; }

        /// <summary>
        /// Get the player instance.
        /// </summary>
        public Player Player { get { return player; } }

        /// <summary>
        /// Has the world been created yet?
        /// </summary>
        public bool Created { get; private set; }
        /// <summary>
        /// Is the game over?
        /// </summary>
        public bool GameOver { get { return player.Hitpoints == 0; } }
        /// <summary>
        /// Is the game won?
        /// </summary>
        public bool GameWon
        {
            get
            {
                bool atGoal = Map.CellContentAtPoint(Player.Position) == Game.Map.CellContent.Goal;
                return atGoal;
            }
        }

        /// <summary>
        /// The player entity.
        /// </summary>
        private Player player;
        /// <summary>
        /// The enemy entity.
        /// </summary>
        private Enemy enemy;

        /// <summary>
        /// Used to get the elapsed time.
        /// </summary>
        private Stopwatch stopwatch;
        /// <summary>
        /// Holds the time that the last update took place.
        /// </summary>
        private long prevTime = 0;
        /// <summary>
        /// Random number generator used throughout the game
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Gives the size of a single grid cell (always square)
        /// </summary>
        public int GridSize { get { return 32; } }

        /// <summary>
        /// The current map.
        /// </summary>
        public Map Map { get; private set; }

        /// <summary>
        /// Variable to hold to only possible instance of the World class.
        /// </summary>
        static private World instance = null;
        /// <summary>
        /// Retrieve the instance of the World class, and create it if it does
        /// not yet exist. This construct is called the "Singleton Pattern".
        /// </summary>
        static public World Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new World();
                }
                return instance;
            }
        }
#endregion

        /// <summary>
        /// Private constructor: can only be called from within this class.
        /// </summary>
        private World()
        {
            stopwatch = Stopwatch.StartNew();
            Created = false;
        }

        /// <summary>
        /// Initializes the game world by creating a new map, player and enemy.
        /// </summary>
        public void Create(Size size)
        {
            Size = size;
            Map = new Map(size.Width / GridSize + 1, size.Height / GridSize + 1);

            player = new Player(Map.CellCenter(new Point(0, 0)));
            enemy = new Enemy(Map.RandomFreePosition());

            Created = true;
        }

        /// <summary>
        /// Processes all updates to update the game world.
        /// </summary>
        public void Update()    
        {
            // Determine the elapsed time and update the player and enemy
            float deltaTime = (Time - prevTime) / 1000.0f;
            player.Update(deltaTime);
            enemy.Update(deltaTime);

            // Determine if the player has been hit
            if (player.BoundingBox.IntersectsWith(enemy.BoundingBox))
            {
                player.Hit(enemy);
            }

            prevTime = Time;
        }

        /// <summary>
        /// Draw the world objects to the canvas indicated by the parameter.
        /// </summary>
        /// <param name="g">The graphics object used to draw.</param>
        public void Draw(Graphics g)
        {
            Map.Draw(g);

            enemy.Draw(g);
            player.Draw(g);
        }

        /// <summary>
        /// Because we need many random number in quick succession, the numbers
        /// will become identical in many cases. By defining one point that
        /// generates all numbers this problem is avoided.
        /// </summary>
        /// <param name="maxValue">The maximum number to generate.</param>
        /// <returns>A random integer in the range [0..maxValue></returns>
        public int RandomNumber(int maxValue)
        {
            return random.Next(maxValue);
        }
        public int RandomNumber(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
        public Vector RandomPosition()
        {
            return new Vector((RandomNumber(Size.Width) / GridSize) * GridSize,
                              (RandomNumber(Size.Height) / GridSize) * GridSize);
        }
    }
}
