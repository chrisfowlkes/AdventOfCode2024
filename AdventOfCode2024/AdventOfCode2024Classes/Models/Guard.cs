using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Security guard in the lab.
    /// </summary>
    /// <param name="map">Map of the lab.</param>
    internal class Guard(LabMap map)
    {
        /// <summary>
        /// The location of the guard on the map.
        /// </summary>
        internal required LabLocation Location { get; set; }
        /// <summary>
        /// The direction the guard is pointed.
        /// </summary>
        internal char Direction { get => orientation[directionIndex]; set => directionIndex = orientation.IndexOf(value); }
        private int directionIndex;
        /// <summary>
        /// True if the guard is within the bounds of the map, false otherwise.
        /// </summary>
        internal bool InsideMap { get; set; } = true;
        private readonly List<char> orientation = ['^', '>', 'V', '<'];
        private readonly Size[] direction = [new Size(0, -1), new Size(1, 0), new Size(0, 1), new Size(-1, 0)];

        /// <summary>
        /// Moves the guard one location forward. If blocked the guard will turn 90 degrees to the 
        /// right until he can move.
        /// </summary>
        internal void Move()
        {
            var newLocation = NextLocation();
            Location.ExitDirections.Add(Direction);
            if (newLocation != null)
            {
                Location = newLocation;
                Location.Checked = true;
            }
            else
            {
                InsideMap = false;
            }
        }

        /// <summary>
        /// Gets the next potential location of the guard, but does not move there yet.
        /// </summary>
        /// <returns>The next location of the guard, null if outside the map.</returns>
        internal LabLocation? NextLocation()
        {
            LabLocation? next;
            var newLocation = Location.Coordinates + direction[directionIndex];

            while ((InsideMap = map.InBounds(newLocation)) && map.GetLocation(newLocation).Blocked)
            {
                //Need to rotate to the right.
                directionIndex++;
                if (directionIndex >= direction.Length)
                {
                    directionIndex = 0;
                }
                newLocation = Location.Coordinates + direction[directionIndex];
            }

            if (map.InBounds(newLocation))
            {
                next = map.GetLocation(newLocation);
            }
            else
            {
                next = null;
            }

            return next;
        }
    }
}
