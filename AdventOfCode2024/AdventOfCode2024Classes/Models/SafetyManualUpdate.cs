using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Update to the sleigh launch safety manual.
    /// </summary>
    internal class SafetyManualUpdate
    {
        private readonly int[] pages;
        private readonly PageOrderingRule[] rules;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rules">The page ordering rules.</param>
        /// <param name="pages">Page numbers to update, comma seperated.</param>
        internal SafetyManualUpdate(PageOrderingRule[] rules, string pages) 
        {
            this.rules = rules;
            var split = pages.Split(',');
            this.pages = new int[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                this.pages[i] = int.Parse(split[i]);
            }
        }

        /// <summary>
        /// Checks to see if the update is valid according to the pages and rules.
        /// </summary>
        /// <returns>True if valid, false otherwise.</returns>
        internal bool IsValid()
        {
            bool valid = true;

            foreach (var rule in rules)
            {
                int second = Array.IndexOf(pages, rule.PageOrder[1]);
                if (second >= 0 && second < Array.IndexOf(pages, rule.PageOrder[0]))
                {
                    valid = false;
                    break;
                }
            }

            return valid;
        }

        /// <summary>
        /// Determines the number of the middle page printed.
        /// </summary>
        /// <returns>The number of the middle page printed.</returns>
        public int MiddlePage()
        {
            var middleIndex = (int)Math.Round(pages.Length / 2m, MidpointRounding.AwayFromZero) - 1;
            return pages[middleIndex];
        }
    }
}
