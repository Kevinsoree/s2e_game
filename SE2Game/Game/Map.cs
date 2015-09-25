using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using SE2Game.Utils;

namespace SE2Game.Game
{
    public class Map
    {
        public enum CellContent
        {
            Blank = 1,
            Wall = 2,
            Goal = 4
        };

        // Two dimensional array to hold each cell value
        private CellContent[,] cells;

        private Point goalPosition;
        /// <summary>
        /// The chance that a wall is randomly inserted into generated maps.
        /// </summary>
        private const int WallProbability = 20;

        /// <summary>
        /// The width of the map in cells.
        /// </summary>
        public int Width { get { return cells.GetLength(0); } }
        /// <summary>
        /// The height of the map in cells.
        /// </summary>
        public int Height { get { return cells.GetLength(1); } }

        /// <summary>
        /// Create a new map instance with the given size.
        /// </summary>
        /// <param name="width">The width of the map in cells.</param>
        /// <param name="height">The height of the map in cells.</param>
        public Map(int width, int height)
        {
            // Initialize the array, generating a random map
            cells = new CellContent[width, height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if ((x > 1 || y > 1) && // We don't want a wall were we start
                        World.Instance.RandomNumber(100) < WallProbability)
                    {
                        cells[y, x] = CellContent.Wall;
                    }
                    else
                    {
                        cells[y, x] = CellContent.Blank;
                    }
                }
            }

            // Set a random goal position in the lower right quartile
            goalPosition = new Point(World.Instance.RandomNumber(Width * 3 / 4, Width),
                                     World.Instance.RandomNumber(Height * 3 / 4, Height));
            cells[goalPosition.Y, goalPosition.X] = CellContent.Goal;
            goalPosition.X *= World.Instance.GridSize;
            goalPosition.Y *= World.Instance.GridSize;
        }

        public void Draw(Graphics g)
        {
            // Abbreviation variable to shorten code below
            int gs = World.Instance.GridSize;

            // Draw grid and color cells
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // Draw the grid lines
                    if (x == 1)
                    { 
                        g.DrawLine(Pens.LightGray, 0, y * gs, Width * gs, y * gs);
                    }
                    if (y == 1)
                    {
                        g.DrawLine(Pens.LightGray, x * gs, 0, x * gs, Height * gs);
                    }

                    Rectangle rect = new Rectangle(x * gs, y * gs, gs, gs);
                    switch (cells[y, x])
                    {
                        case CellContent.Goal:
                            g.FillRectangle(Brushes.DarkGreen, rect);
                            break;
                        case CellContent.Wall:
                            g.FillRectangle(Brushes.Black, rect);
                            break;
                        case CellContent.Blank:
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Returns the center coordinate (for sprites) of a random cell that
        /// is passable and not occupied.
        /// </summary>
        public Vector RandomFreePosition()
        {
            Point playerCell = PointToCell(World.Instance.Player.Position);
            Point result;
            do
            {
                result = PointToCell(World.Instance.RandomPosition());
            } while (cells[result.Y, result.X] != CellContent.Blank && result != playerCell);
            return CellCenter(result);
        }

        /// <summary>
        /// Converts a coordinate to a cell index.
        /// </summary>
        public Point PointToCell(int x, int y)
        {
            return new Point(x / World.Instance.GridSize % Width,
                             y / World.Instance.GridSize % Height);
        }
        /// <summary>
        /// Converts a coordinate to a cell index.
        /// </summary>
        public Point PointToCell(Vector v)
        {
            return PointToCell(Convert.ToInt32(v.X), Convert.ToInt32(v.Y));
        }
        /// <summary>
        /// Given a point, returns the center of the cell that point is in.
        /// </summary>
        public Vector CellCenter(Point point)
        {
            return CellToPoint(point) + World.Instance.GridSize / 2;
        }
        /// <summary>
        /// Converts a cell index to the coordinate at the top left of that cell.
        /// </summary>
        public Vector CellToPoint(Point point)
        {
            int gs = World.Instance.GridSize;
            return new Vector(point.X * gs, point.Y * gs);
        }
        public CellContent CellContentAtPoint(Vector v)
        {
            Point p = PointToCell(Convert.ToInt32(v.X), Convert.ToInt32(v.Y));
            return cells[p.Y, p.X];
        }

        /// <summary>
        /// Returns true if the given position does not intersect an non-passable cell.
        /// </summary>
        public bool Reachable(Vector v)
        {
            return CellContentAtPoint(v) != CellContent.Wall;
        }
    }
}
