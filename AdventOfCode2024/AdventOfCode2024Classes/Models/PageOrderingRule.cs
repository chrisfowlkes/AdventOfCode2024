using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    internal class PageOrderingRule
    {
        /// <summary>
        /// Holds the page order of the rule.
        /// </summary>
        internal int[] PageOrder { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rule">Page order rule.</param>
        internal PageOrderingRule(string rule)
        {
            var split = rule.Split('|');
            PageOrder = new int[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                PageOrder[i] = int.Parse(split[i]);
            }
        }
    }
}
