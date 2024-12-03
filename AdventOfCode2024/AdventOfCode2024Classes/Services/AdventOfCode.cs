using Classes.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var cols = ParseColumns(data);
            Array.Sort(cols.Left);
            Array.Sort(cols.Right);

            var total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                total += Math.Abs(cols.Left[i] - cols.Right[i]);
            }

            return total.ToString();
        }

        private static (int[] Left, int[] Right) ParseColumns(string[] data)
        {
            var left = new int[data.Length];
            var right = new int[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                var row = data[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                left[i] = int.Parse(row[0]);
                right[i] = int.Parse(row[1]);
            }

            return (left, right);
        }

        /// <summary>
        /// Calculates a similaruty score based on how many times a number in the left column appears in the right column.
        /// </summary>
        /// <param name="data">Two sets of numbers.</param>
        /// <returns>Similarity score.</returns>
        public static string FindSimilarityScore(string[] data)
        {
            var cols = ParseColumns(data);
            Array.Sort(cols.Left);
            Array.Sort(cols.Right);

            var score = 0;
            for (int i = 0; i < data.Length; i++)
            {
                score += cols.Left[i] * cols.Right.Where(r => r == cols.Left[i]).Count();
            }

            return score.ToString();
        }

        /// <summary>
        /// Counts the number of reports that are safe. Safe reports only ascend or descend
        /// and only in increments of 1, 2, or 3.
        /// </summary>
        /// <param name="reports">Reports.</param>
        /// <returns>The number of safe reports.</returns>
        public static string CountSafeReports(string[] reports)
        {
            var safeCount = 0;
            foreach (var levels in reports)
            {
                var report = new Report(levels);
                if(report.IsSafe()) { safeCount++; }
            }

            return safeCount.ToString();
        }
    }
}
