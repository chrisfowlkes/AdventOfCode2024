using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Services
{
    /// <summary>
    /// Logic for the 2024 advent of code.
    /// </summary>
    public class AdventOfCode
    {
        /// <summary>
        /// Calculates the total difference of two sets of numbers. Each row contains two columns of
        /// numbers, seperated by a space. Each column is independently sorted, then the difference 
        /// between the two columns for each row is summed.
        /// </summary>
        /// <param name="data">Two sets of numbers.</param>
        /// <returns>The total difference.</returns>
        public static string CalculateTotalDifference(string[] data)
        {
            int[] left = new int[data.Length];
            int[] right = new int[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                var row = data[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                left[i] = int.Parse(row[0]);
                right[i] = int.Parse(row[1]);
            }

            Array.Sort(left);
            Array.Sort(right);

            var total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                total += Math.Abs(left[i] - right[i]);
            }

            return total.ToString();
        }
    }
}
