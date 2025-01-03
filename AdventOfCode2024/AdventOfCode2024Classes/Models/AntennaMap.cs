﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A map of antena locations.
    /// </summary>
    internal class AntennaMap
    {
        /// <summary>
        /// Locations on the map.
        /// </summary>
        internal List<AntennaMapLocation> Locations = [];

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mapData">Map data.</param>
        internal AntennaMap(string[] mapData) 
        {
            for (var y = 0; y < mapData.Length; y++)
            {
                for (var x = 0; x < mapData[y].Length; x++)
                {
                    var location = new AntennaMapLocation(mapData[y][x], new System.Drawing.Point(x, y));
                    Locations.Add(location);
                }
            }
        }

        private Point? CheckForAntinode(Point antinodeCoordinates)
        {
            var antinodeLocation = Locations.Where(l => l.Location == antinodeCoordinates).FirstOrDefault();
            if (antinodeLocation != null)
            {
                antinodeLocation.Antinode++;
            }

            return antinodeLocation?.Location;
        }

        /// <summary>
        /// Counts the number of antinodes on the map.
        /// </summary>
        /// <param name="resonantHarmonics">Pass as true to consider resonant harmonics.</param>
        /// <returns>The number of antinodes on the map.</returns>
        internal int CountAntinodes(bool resonantHarmonics)
        {
            for (var i = 0; i < Locations.Count; i++)
            {
                if (Locations[i].Antenna != '.')
                {
                    for (var j = i + 1; j < Locations.Count; j++)
                    {
                        if (Locations[i].Antenna == Locations[j].Antenna)
                        {
                            if(resonantHarmonics)
                            {
                                Locations[i].Antinode++;
                                Locations[j].Antinode++;
                            }
                            var distance = new Size(Locations[j].Location.X - Locations[i].Location.X, Locations[j].Location.Y - Locations[i].Location.Y);
                            var antinode = CheckForAntinode(Point.Subtract(Locations[i].Location, distance));
                            while (resonantHarmonics && antinode != null)
                            {
                                antinode = CheckForAntinode(Point.Subtract(antinode.Value, distance));
                            }
                            antinode = CheckForAntinode(Point.Add(Locations[j].Location, distance));
                            while (resonantHarmonics && antinode != null)
                            {
                                antinode = CheckForAntinode(Point.Add(antinode.Value, distance));
                            }
                        }
                    }
                }
            }

            return Locations.Where(l => l.Antinode > 0).Count();
        }
    }
}
