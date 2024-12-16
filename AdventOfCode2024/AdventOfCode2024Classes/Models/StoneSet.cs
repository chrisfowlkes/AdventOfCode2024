using System;
using System.Collections;
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
        private readonly List<long> stones = [];
        private readonly Dictionary<long, long?[]> answers = [];

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stones">The stones in their initial state.</param>
        internal StoneSet(string stones) 
        {
            var stoneValues = stones.Split(' ');
            foreach(var stone in stoneValues)
            {
                this.stones.Add(int.Parse(stone));
            }
        }

        /// <summary>
        /// Performs a blink.
        /// </summary>
        /// <param name="blinkCount">The number of blinks to perform.</param>
        /// <returns>The number of stones after the blinks are done.</returns>
        internal long Blink(int blinkCount)
        {
            long result = 0;
            foreach (var stone in stones)
            {
                result += ProcessStone(stone, blinkCount);
            }
            return result;
        }

        private long ProcessStone(long stone, int blinkCount)
        {
            long result;

            long?[] stoneAnswers;
            if (!answers.TryGetValue(stone, out stoneAnswers!))
            {
                stoneAnswers = new long?[75];
                answers.Add(stone, stoneAnswers);
            }

            if (stoneAnswers[blinkCount - 1] != null)
            {
                result = stoneAnswers[blinkCount - 1]!.Value;
            }
            else
            {
                if (stone == 0)
                {
                    if (blinkCount > 1)
                    {
                        result = ProcessStone(1, blinkCount - 1);
                    }
                    else
                    {
                        result = 1;
                    }
                }
                else
                {
                    var stoneValue = stone.ToString();
                    if (stoneValue.Length % 2 == 0)
                    {
                        if (blinkCount > 1)
                        {
                            var midpoint = stoneValue.Length / 2;
                            result = ProcessStone(long.Parse(stoneValue[..midpoint]), blinkCount - 1) + ProcessStone(long.Parse(stoneValue[midpoint..]), blinkCount - 1);
                        }
                        else
                        {
                            result = 2;
                        }
                    }
                    else
                    {
                        if (blinkCount > 1)
                        {
                            result = ProcessStone(stone * 2024, blinkCount - 1);
                        }
                        else
                        {
                            result = 1;
                        }
                    }
                }
                stoneAnswers[blinkCount - 1] = result;
            }

            return result;
        }
    }
}
