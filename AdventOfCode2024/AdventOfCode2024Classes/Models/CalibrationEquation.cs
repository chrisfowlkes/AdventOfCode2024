﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A calibration equation.
    /// </summary>
    internal class CalibrationEquation
    {
        /// <summary>
        /// True if the equation is valid, false otherwise.
        /// </summary>
        public bool Valid { get; set; }
        private readonly List<long> equationValues = [];
        /// <summary>
        /// Answer of the equation.
        /// </summary>
        internal long Answer;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="equation">The equation.</param>
        internal CalibrationEquation(string equation)
        {
            var split = equation.Split(':');
            Answer = long.Parse(split[0]);
            var equationValues = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var digit in equationValues)
            {
                this.equationValues.Add(long.Parse(digit));
            }
        }

        private bool Multiply(long[] values)
        {
            var newValues = new long[values.Length - 1];
            newValues[0] = values[0] * values[1];

            return Check(values, newValues);
        }

        private bool Add(long[] values)
        {
            var newValues = new long[values.Length - 1];
            newValues[0] = values[0] + values[1];

            return Check(values, newValues);
        }

        private bool Check(long[] values, long[] newValues)
        {
            bool result;
            if (newValues[0] > Answer)
            {
                //Already exceeded the value of the answer. No need to continue.
                result = false;
            }
            else if (values.Length > 2)
            {
                //More values to go, continue to check.
                for (int i = 1; i < newValues.Length; i++)
                {
                    newValues[i] = values[i + 1];
                }
                result = Multiply(newValues) || Add(newValues);
            }
            else
            {
                //All values used, check against the answer.
                result = newValues[0] == Answer;
            }

            return result;
        }

        /// <summary>
        /// Checks to see if the equation is valid.
        /// </summary>
        /// <returns>True if the equation is valid, false otherwise.</returns>
        internal bool IsValid()
        {
            var values = equationValues.ToArray();
            return Multiply(values) || Add(values);
        }
    }
}