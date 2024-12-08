using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Represents a map of the lab.
    /// </summary>
    internal class LabMap
    {
        private readonly char[][] map;
        private readonly Point start;
        private readonly List<char> orientation = new List<char> { '^', '>', 'V', '<' };
        private readonly Size[] direction = new Size[] { new Size(0, -1), new Size (1, 0), new Size(0, 1), new Size(-1, 0)};

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mapData">Data describing the map.</param>
        internal LabMap(string[] mapData)
        {
            map = new char[mapData.Length][];
            for (int y = 0; y < mapData.Length; y++)
            {
                map[y] = new char[mapData[y].Length];
                for (int x = 0; x < map[y].Length; x++)
                {
                    map[y][x] = mapData[y][x];
                    if (map[y][x] != '.' && map[y][x] != '#')
                    {
                        start = new Point(x, y);
                    }
                }
            }
        }

        /// <summary>
        /// Analyzes the map data and counts the number of spaces the guard will visit.
        /// </summary>
        /// <returns>The number of paces the guard will visit.</returns>
        internal int CountSpacesChecked()
        {
            int count = 0;
            Point location = start;
            int currentDirection = orientation.IndexOf(map[location.Y][location.X]);
            bool inside = true;

            while(inside) 
            {
                if(map[location.Y][location.X] != 'X')
                {
                    count++;
                    map[location.Y][location.X] = 'X';//Mark location visited.
                }
                var newLocation = location + direction[currentDirection];
                while ((inside = InBounds(newLocation)) && map[newLocation.Y][newLocation.X] == '#')
                {
                    //Need to rotate to the right.
                    currentDirection++;
                    if (currentDirection >= direction.Length)
                    {
                        currentDirection = 0;
                    }
                    newLocation = location + direction[currentDirection];
                }
                if (inside)
                {
                    location = newLocation;
                }
            }

            return count;
        }

        private bool InBounds(Point location)
        {
            return location.X >= 0 && location.Y >= 0 && location.Y < map.Length && location.X < map[location.Y].Length;
        }
    }
}
