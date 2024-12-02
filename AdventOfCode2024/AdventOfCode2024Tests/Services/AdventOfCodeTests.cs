using Classes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services
{
    /// <summary>
    /// Tests for the AdventOfCode service.
    /// </summary>
    public class AdventOfCodeTests
    {
        /// <summary>
        /// Test for the CalculateTotalDifference method.
        /// </summary>
        [Fact]
        public void CalculateTotalDifference()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\1.txt");

            //Act
            var result = AdventOfCode.CalculateTotalDifference(data);

            //Assert
            Assert.Equal("11", result);
        }
    }
}
