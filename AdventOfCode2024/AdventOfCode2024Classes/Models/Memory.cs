using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Classes.Models
{
    internal class Memory(string[] contents)
    {
        internal string Scan()
        {
            var pattern = "mul\\((\\d{1,3}),(\\d{1,3})\\)";

            int total = 0;
            foreach (var line in contents)
            {
                var matches = Regex.Matches(line, pattern);
                foreach (Match match in matches)
                {
                    total += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                }
            }

            return total.ToString();
        }
    }
}
