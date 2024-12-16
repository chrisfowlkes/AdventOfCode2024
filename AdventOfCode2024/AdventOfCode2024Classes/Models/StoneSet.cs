using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Represnets a set of stones.
    /// </summary>
    internal class StoneSet
    {
        /// <summary>
        /// Stones.
        /// </summary>
        internal List<long> Stones { get; private set; } = [];

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stones">The stones in their initial state.</param>
        internal StoneSet(string stones) 
        {
            var stoneValues = stones.Split(' ');
            foreach(var stone in stoneValues)
            {
                this.Stones.Add(int.Parse(stone));
            }
        }

        /// <summary>
        /// Performs a blink.
        /// </summary>
        /// <param name="blinkCount">The number of blinks to perform.</param>
        internal void Blink(int blinkCount)
        {
            for (int i = 0; i < blinkCount; i++)
            {
                var newStones = new List<long>();

                foreach (var stone in Stones)
                {
                    if (stone == 0)
                    {
                        newStones.Add(1);
                    }
                    else
                    {
                        var stoneValue = stone.ToString();
                        if (stoneValue.Length % 2 == 0)
                        {
                            var midpoint = stoneValue.Length / 2;
                            newStones.Add(long.Parse(stoneValue[..midpoint]));
                            newStones.Add(long.Parse(stoneValue[midpoint..]));
                        }
                        else
                        {
                            newStones.Add(stone * 2024);
                        }
                    }
                }

                Stones = newStones;
            }
        }
    }
}
