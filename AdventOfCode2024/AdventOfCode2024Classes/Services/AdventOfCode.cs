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
            var (Left, Right) = ParseColumns(data);
            Array.Sort(Left);
            Array.Sort(Right);

            var total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                total += Math.Abs(Left[i] - Right[i]);
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
            var (Left, Right) = ParseColumns(data);
            Array.Sort(Left);
            Array.Sort(Right);

            var score = 0;
            for (int i = 0; i < data.Length; i++)
            {
                score += Left[i] * Right.Where(r => r == Left[i]).Count();
            }

            return score.ToString();
        }

        /// <summary>
        /// Counts the number of reports that are safe. Safe reports only ascend or descend
        /// and only in increments of 1, 2, or 3.
        /// </summary>
        /// <param name="reports">Reports.</param>
        /// <param name="problemDampener">If true and removing one level will make the report safe, it will be considered safe.</param>
        /// <returns>The number of safe reports.</returns>
        public static string CountSafeReports(string[] reports, bool problemDampener)
        {
            var safeCount = 0;
            foreach (var levels in reports)
            {
                var report = new Report(levels);
                if(report.IsSafe(problemDampener)) 
                { 
                    safeCount++; 
                }
            }

            return safeCount.ToString();
        }

        /// <summary>
        /// Scans the corrupt memory contents for multiply commands and executes them.
        /// </summary>
        /// <param name="contents"></param>
        /// <returns>The total of the mul commands.</returns>
        public static string ScanMemory(string[] contents, bool conditional)
        {
            var memory = new Memory(contents);
            return memory.Scan(conditional);
        }

        /// <summary>
        /// Searches the word search puzzle for the word XMAS.
        /// </summary>
        /// <param name="puzzle">The word search puzzle.</param>
        /// <returns>The number of times XMAS occurs in the puzzle.</returns>
        public static string WordSearch(string[] puzzle)
        {
            var wordSearch = new WordSearch(puzzle);
            return wordSearch.Search();
        }
    }
}
