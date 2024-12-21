using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A region of the same crop in the garden.
    /// </summary>
    internal class GardenRegion
    {
        /// <summary>
        /// Plots in the region.
        /// </summary>
        internal List<GardenPlot> Plots { get; } = [];

        /// <summary>
        /// Calculatews the price for fence around the region.
        /// </summary>
        /// <returns>The price of fence for the region.</returns>
        internal int CalculateFencePrice()
        {
            var perimeter = Plots.Sum(p => p.Perimeter);
            return perimeter * Plots.Count;
        }
    }
}
