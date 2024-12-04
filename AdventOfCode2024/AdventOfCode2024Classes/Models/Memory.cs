using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Represents memory in a computer.
    /// </summary>
    /// <param name="contents">Contents of the memory.</param>
    internal class Memory(string[] contents)
    {
        /// <summary>
        /// Scans the memory.
        /// </summary>
        /// <param name="conditional">Process conditional statemnts if true, skip them if false.</param>
        /// <returns>The total of the result of all mul commands in memory.</returns>
        internal string Scan(bool conditional)
        {
            string pattern;
            if (conditional)
            {
                pattern = "mul\\((\\d{1,3}),(\\d{1,3})\\)|do\\(\\)|don\\'t\\(\\)";
            }
            else
            {
                pattern = "mul\\((\\d{1,3}),(\\d{1,3})\\)";
            }

            int total = 0;
            bool calculate = true;
            foreach (var line in contents)
            {
                var matches = Regex.Matches(line, pattern);
                foreach (Match match in matches)
                {
                    if (match.Groups[0].Value == "do()")
                    {
                        calculate = true;
                    }
                    else if (match.Groups[0].Value == "don't()")
                    {
                        calculate = false;
                    }
                    else if(calculate)
                    {
                        total += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                    }
                }
            }

            return total.ToString();
        }
    }
}
