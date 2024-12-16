using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A topographic map containing trailheads.
    /// </summary>
    internal class TopographicMap
    {
        private readonly double[][] locations;
        private readonly List<Point> trailheads = [];
        private readonly Size[] directions = [new Size(0, -1), new Size(1, 0), new Size(0, 1), new Size(-1, 0)];

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mapData">Map data.</param>
        internal TopographicMap(string[] mapData) 
        {
            locations = new double[mapData.Length][];
            for (int y = 0; y < mapData.Length; y++)
            {
                locations[y] = new double[mapData[y].Length];
                for (int x = 0; x < mapData[y].Length; x++)
                {
                    locations[y][x] = char.GetNumericValue(mapData[y][x]);
                    if(locations[y][x] == 0)
                    {
                        trailheads.Add(new Point(x, y));
                    }
                }
            }
        }

        /// <summary>
        /// Sums the scores of all the trailheads. A trailhead score is equal to the number of 
        /// peaks that can be reached from the trailhead.
        /// </summary>
        /// <returns>The sum of the scores of the trailheads.</returns>
        internal int SumTrailScores()
        {
            int sum = 0;

            foreach (Point trailhead in trailheads)
            {
                sum += CheckTrailhead(trailhead).Distinct().Count();
            }

            return sum;
        }

        /// <summary>
        /// Sums the ratings of all the trailheads. A trailhead rating is equal to the number of 
        /// paths to peaks that can be reached from the trailhead.
        /// </summary>
        /// <returns>The sum of the ratings of the trailheads.</returns>
        internal int SumTrailRatings()
        {
            int sum = 0;

            foreach (Point trailhead in trailheads)
            {
                sum += CheckTrailhead(trailhead).Count;
            }

            return sum;
        }

        private List<Point> CheckTrailhead(Point trailhead)
        {
            var currentLocations = new List<Point>() { trailhead };
            for (int i = 0; i < 9; i++)
            {
                var nextLocations = new List<Point>();
                foreach (var currentLocation in currentLocations)
                {
                    nextLocations.AddRange(EvaluatePoint(currentLocation));
                }
                currentLocations = nextLocations;
            }

            return currentLocations;
        }

        private List<Point> EvaluatePoint(Point point)
        {
            var nextSteps = new List<Point>();

            foreach(var direction in directions)
            {
                var nextStep = point + direction;
                if(InBounds(nextStep) && locations[nextStep.Y][nextStep.X] == locations[point.Y][point.X] + 1)
                {
                    nextSteps.Add(nextStep);
                }
            }

            return nextSteps;
        }

        private bool InBounds(Point location)
        {
            return location.X >= 0 && location.Y >= 0 && location.Y < locations.Length && location.X < locations[location.Y].Length;
        }
    }
}
