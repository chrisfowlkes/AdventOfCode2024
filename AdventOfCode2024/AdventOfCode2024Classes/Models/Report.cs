using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    internal class Report
    {
        private string[] levels;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="levels">Levels in the report.</param>
        public Report(string levels)
        {
            this.levels = levels.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Determines if the report is safe. Reports are safe if all levels increase gradually,
        /// or decrease gradually.
        /// </summary>
        /// <returns>True if safe, false otherwise.</returns>
        public bool IsSafe()
        {
            var first = int.Parse(levels[0]);
            var second = int.Parse(levels[1]);
            int min, max;

            //Determine if the levels are increasing or decreasing.
            if (first < second)
            {
                //Increasing levels.
                min = -3;
                max = -1;
            }
            else if (first > second)
            {
                //Decreasing levels.
                min = 1;
                max = 3;
            }
            else
            {
                //First two are equal, not safe.
                return false;
            }

            for (int i = 0; i < levels.Length - 1; i++)
            {
                var diff = int.Parse(levels[i]) - int.Parse(levels[i + 1]);
                if (diff < min || diff > max)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
