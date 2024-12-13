using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A location on the antenna map.
    /// </summary>
    /// <remarks>
    /// Constructor.
    /// </remarks>
    /// <param name="antenna">The type of antenna for the location.</param>
    /// <param name="location">The coordinates of the location.</param>
    internal class AntennaMapLocation(char antenna, Point location)
    {
        /// <summary>
        /// The point on the map for the location.
        /// </summary>
        internal Point Location { get; set; } = location;
        /// <summary>
        /// The antenna located at the location.
        /// </summary>
        internal char Antenna { get; set; } = antenna;
        /// <summary>
        /// Indicates how many antinodes the location contains.
        /// </summary>
        internal int Antinode { get; set; }
    }
}
