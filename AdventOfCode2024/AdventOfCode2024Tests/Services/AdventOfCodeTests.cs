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

        /// <summary>
        /// Test for the CalculateTotalDifference method.
        /// </summary>
        [Fact]
        public void FindSimilarityScore()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\1.txt");

            //Act
            var result = AdventOfCode.FindSimilarityScore(data);

            //Assert
            Assert.Equal("31", result);
        }

        /// <summary>
        /// Test for the CalculateTotalDifference method.
        /// </summary>
        [Fact]
        public void CountSafeReports()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\2.txt");

            //Act
            var result = AdventOfCode.CountSafeReports(data);

            //Assert
            Assert.Equal("2", result);
        }
    }
}
