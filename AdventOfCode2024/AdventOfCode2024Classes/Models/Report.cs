using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="levels">Levels in the report.</param>
    internal class Report
    {
        private readonly int[] levels;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="levels">Levels for the report.</param>
        internal Report(string levels)
        {
            var temp = levels.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            this.levels = new int[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                this.levels[i] = int.Parse(temp[i]);
            }
        }

        /// <summary>
        /// Determines if the report is safe. Reports are safe if all levels increase gradually,
        /// or decrease gradually.
        /// </summary>
        /// <param name="problemDampener">If true and removing one level will make the report safe, it will be considered safe.</param>
        /// <returns>True if safe, false otherwise.</returns>
        internal bool IsSafe(bool problemDampener)
        {
            return IsSafe(levels, problemDampener);
        }

        private bool IsSafe(int[] levels,  bool problemDampener)
        {
            int min, max;

            //Determine if the levels are increasing or decreasing.
            if (levels[0] == levels[1])
            {
                //First two are equal, not safe.
                if (problemDampener)
                {
                    //We either need to remove the first or second level and try again.
                    var newLevels = new int[levels.Length - 1];
                    Array.ConstrainedCopy(levels, 1, newLevels, 0, newLevels.Length);
                    return IsSafe(newLevels, false);
                }
                else
                {
                    return false;
                }
            }

            if (levels[0] < levels[1])
            {
                //Increasing levels.
                min = -3;
                max = -1;
            }
            else
            {
                //Decreasing levels.
                min = 1;
                max = 3;
            }

            for (int i = 0; i < levels.Length - 1; i++)
            {
                var diff = levels[i] - levels[i + 1];
                if (diff < min || diff > max)
                {
                    if (problemDampener)
                    {
                        //We either need to remove a level.
                        bool result = IsSafe(Skip(i + 1), false);
                        if(! result)
                        {
                            result = IsSafe(Skip(i), false);
                        }
                        if(! result && i > 0)
                        {
                            result = IsSafe(Skip(i - 1), false);
                        }
                        return result;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private int[] Skip(int index)
        {
            var newLevels = levels.ToList();
            newLevels.RemoveAt(index);
            return [.. newLevels];
        }
    }
}
