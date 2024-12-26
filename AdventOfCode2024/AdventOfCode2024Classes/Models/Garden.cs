using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A garden.
    /// </summary>
    internal class Garden
    {
        private readonly List<GardenRegion> regions = [];

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">The garden data.</param>
        internal Garden(string[] data) 
        { 
            var plots = new List<GardenPlot>();
            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[y].Length; x++)
                {
                    var plot = new GardenPlot(data[y][x], new Point(x, y));
                    if(x > 0)
                    {
                        var neighbor = plots.Last();
                        if (neighbor.PlantType == plot.PlantType)
                        {
                            plot.Perimeter.Remove('W');
                            neighbor.Perimeter.Remove('E');
                            neighbor.Region!.Plots.Add(plot);
                            plot.Region = neighbor.Region;
                        }
                    }
                    if (y > 0)
                    {
                        var neighbor = plots.Where(p => p.Location.X == plot.Location.X && p.Location.Y == plot.Location.Y - 1).Single();
                        if (neighbor.PlantType == plot.PlantType)
                        {
                            plot.Perimeter.Remove('N');
                            neighbor.Perimeter.Remove('S');
                            if(plot.Region == null)
                            {
                                neighbor.Region!.Plots.Add(plot);
                                plot.Region = neighbor.Region;
                            }
                            else if(plot.Region != neighbor.Region)
                            {
                                CombineRegions(neighbor, plot);
                            }
                        }
                    }
                    if (plot.Region == null)
                    {
                        plot.Region = new GardenRegion();
                        plot.Region.Plots.Add(plot);
                        regions.Add(plot.Region);
                    }
                    plots.Add(plot);
                }
            }
        }

        /// <summary>
        /// Calculates fence price for the garden.
        /// </summary>
        /// <param name="bulk">Pass true for a bulk discount.</param>
        /// <returns>The price for fencing around the garden.</returns>
        internal int CalculateFencePrice(bool bulk)
        {
            return regions.Sum(r => r.CalculateFencePrice(bulk));
        }

        private static void CombineRegions(GardenPlot plot1, GardenPlot plot2)
        {
            GardenRegion fromRegion, toRegion;
            if(plot2.Region!.Plots.Count > plot1.Region!.Plots.Count)
            {
                fromRegion = plot1.Region!;
                toRegion = plot2.Region!;
            }
            else
            {
                fromRegion = plot2.Region;
                toRegion = plot1.Region!;
            }
            foreach (GardenPlot plot in fromRegion.Plots)
            {
                toRegion.Plots.Add(plot);
                plot.Region = toRegion;
            }
            fromRegion.Plots.Clear();
        }
    }
}
