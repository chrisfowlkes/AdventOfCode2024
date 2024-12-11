using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Represents a map of the lab.
    /// </summary>
    internal class LabMap
    {
        private readonly LabLocation[][] locations;
        private readonly Guard? guard;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mapData">Data describing the map.</param>
        internal LabMap(string[] mapData)
        {
            locations = new LabLocation[mapData.Length][];
            for (int y = 0; y < mapData.Length; y++)
            {
                locations[y] = new LabLocation[mapData[y].Length];
                for (int x = 0; x < locations[y].Length; x++)
                {
                    locations[y][x] = new LabLocation
                    {
                        Coordinates = new Point(x, y),
                        Blocked = mapData[y][x] == '#'
                    };
                    if (mapData[y][x] == '^' || mapData[y][x] == '>' || mapData[y][x] == 'V' || mapData[y][x] == '<')
                    {
                        guard = new Guard(this)
                        {
                            Location = locations[y][x],
                            Direction = mapData[y][x]
                        };
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
            while(guard?.InsideMap ?? false)
            {
                guard.Move();
            }

            return locations.Sum(l => l.Count(ll => ll.Checked));
        }

        /// <summary>
        /// Determines if a point is inside the bounds of the map.
        /// </summary>
        /// <param name="location">The coordinates of the location to check.</param>
        /// <returns>True if the location is inside the bounds of the map, false otherwise.</returns>
        internal bool InBounds(Point location)
        {
            return location.X >= 0 && location.Y >= 0 && location.Y < locations.Length && location.X < locations[location.Y].Length;
        }

        /// <summary>
        /// Gets the location at the given coordinates.
        /// </summary>
        /// <param name="location">The coordinates of the lcoation.</param>
        /// <returns>The location at the given coordinates.</returns>
        internal LabLocation GetLocation(Point location)
        {
            return locations[location.Y][location.X];
        }

        /// <summary>
        /// Counts the number of ways to trap the guard in a loop.
        /// </summary>
        /// <returns>The number of ways to trap the guard in a loop.</returns>
        internal int CountLoops()
        {
            int count = 0;
            if(guard != null)
            {
                var startingLocation = guard.Location;
                var startingDirection = guard.Direction;
                //Find locations visited by the guard.
                CountSpacesChecked();
                startingLocation.Checked = false;//Can't block the tarting position.
                var visitedLocations = locations.SelectMany(l => l.Where(ll => ll.Checked)).ToList();

                foreach (var location in visitedLocations)
                {
                    ClearExitLocations();
                    guard.Location = startingLocation;
                    guard.Direction = startingDirection;
                    guard.InsideMap = true;
                    location.Blocked = true;
                    bool inLoop = false;
                    while (guard.InsideMap && !inLoop)
                    {
                        LabLocation last = guard.Location;
                        guard.Move();
                        inLoop = InLoop(last);
                    }
                    if (inLoop)
                    {
                        count++;
                    }
                    location.Blocked = false;
                }
            }

            return count;
        }

        private static bool InLoop(LabLocation lastLocation)
        {
            var lastDirection = lastLocation.ExitDirections.Last();
            return lastLocation.ExitDirections.Where(el => el == lastDirection).Count() > 1;
        }

        private void ClearExitLocations()
        {
            foreach (var row in locations) 
            {
                foreach(var location in row)
                {
                    location.ExitDirections = [];
                }
            }
        }
    }
}
