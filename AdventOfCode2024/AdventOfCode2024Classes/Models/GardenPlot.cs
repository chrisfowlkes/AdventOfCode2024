using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A garden plot.
    /// </summary>
    /// <param name="plantType">The plant type.</param>
    /// <param name="location">The plot location.</param>
    internal class GardenPlot(char plantType, Point location)
    {
        /// <summary>
        /// The crop type for the plot.
        /// </summary>
        internal char PlantType { get; private set; } = plantType;
        /// <summary>
        /// The location of the plot in the garden.
        /// </summary>
        internal Point Location { get; private set; } = location;
        /// <summary>
        /// The region to which the plot belongs.
        /// </summary>
        internal GardenRegion? Region { get; set; }
        /// <summary>
        /// The perimeter of the region around this plot. Starts as 4, decrement when bordering plots 
        /// of the same types are found.
        /// </summary>
        internal int Perimeter { get; set; } = 4;
    }
}
