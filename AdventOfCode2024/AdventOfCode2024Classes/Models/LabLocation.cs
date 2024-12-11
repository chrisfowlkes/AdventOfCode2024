using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A location on the lab map.
    /// </summary>
    /// <param name="location">The coordinates of the location.</param>
    internal class LabLocation()
    {
        /// <summary>
        /// False until the guard checks the location, the set to true.
        /// </summary>
        internal bool Checked { get; set; }
        /// <summary>
        /// True if the location is blocked, false otherwise.
        /// </summary>
        internal bool Blocked { get; set; }
        /// <summary>
        /// Coordinates of the location.
        /// </summary>
        internal Point Coordinates { get; set; }
        /// <summary>
        /// The directions in which this locations has previously been exited.
        /// </summary>
        internal List<int> ExitDirections { get; set; } = [];
    }
}
