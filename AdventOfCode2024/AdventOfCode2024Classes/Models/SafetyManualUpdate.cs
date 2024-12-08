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
        private readonly List<int> pages = [];
        private readonly PageOrderingRule[] rules;
        internal bool Valid { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rules">The page ordering rules.</param>
        /// <param name="pages">Page numbers to update, comma seperated.</param>
        internal SafetyManualUpdate(PageOrderingRule[] rules, string pages) 
        {
            this.rules = rules;
            var split = pages.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                this.pages.Add(int.Parse(split[i]));
            }
            IsValid();
        }

        /// <summary>
        /// Sets the value of the Valid property by checking to see if the update is 
        /// valid according to the pages and rules.
        /// </summary>
        private void IsValid()
        {
            Valid = true;
            foreach (var rule in rules)
            {
                int second = pages.IndexOf(rule.PageOrder[1]);
                if (second >= 0)
                {
                    int first = pages.IndexOf(rule.PageOrder[0]);
                    if (second < first)
                    {
                        Valid = false;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Determines the number of the middle page printed. If the rule is invalid, pages
        /// will be reordered so the update is valid.
        /// </summary>
        /// <returns>The number of the middle page printed.</returns>
        public int MiddlePage()
        {
            while(! Valid)
            {
                foreach (var rule in rules)
                {
                    int second = pages.IndexOf(rule.PageOrder[1]);
                    if (second >= 0)
                    {
                        int first = pages.IndexOf(rule.PageOrder[0]);
                        if (second < first)
                        {
                            pages.RemoveAt(first);
                            pages.Insert(second, rule.PageOrder[0]);
                            Valid = false;
                            break;
                        }
                    }
                }
                IsValid();
            }
            var middleIndex = (int)Math.Round(pages.Count / 2m, MidpointRounding.AwayFromZero) - 1;
            return pages[middleIndex];
        }
    }
}
