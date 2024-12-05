using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Word search puzzle.
    /// </summary>
    internal class WordSearch(string[] puzzle)
    {
        private readonly char[] word = ['X', 'M', 'A', 'S'];
        private readonly Point[] directions = [new Point(-1, -1), new Point(-1, 0), new Point(-1, 1), new Point(0, -1), new Point(0, 1), new Point(1, -1), new Point(1, 0), new Point(1, 1)];

        /// <summary>
        /// Searches the puzzle for XMAS
        /// </summary>
        /// <returns>The number of times XMAS apears in the puzzle.</returns>
        internal string Search()
        {
            int count = 0;

            for (int row = 0; row < puzzle.Length; row++)
            {
                for (int col = 0; col < puzzle[row].Length; col++)
                {
                    //Look for the first letter of the word in every position of the puzzle.
                    if (puzzle[row][col] == word[0])
                    {
                        //Found the first letter, now look for the rest of the word in every direction.
                        foreach (Point direction in directions)
                        {
                            var found = true;
                            for (int i = 1; i < word.Length; i++)
                            {
                                int newRow = row + direction.Y * i;
                                int newCol = col + direction.X * i;
                                if (newRow < 0 || newRow >= puzzle.Length || newCol < 0 || newCol >= puzzle[row].Length || puzzle[newRow][newCol] != word[i])
                                {
                                    //Either outside the bounds of the puzzle or the letter is not the one we are looking for.
                                    found = false;
                                    break;
                                }
                            }
                            //Found the word in this direction.
                            if(found)
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return count.ToString();
        }
    }
}
