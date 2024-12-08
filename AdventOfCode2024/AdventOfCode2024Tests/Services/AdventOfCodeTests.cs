﻿using Classes.Services;
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
        /// <param name="allowedFailures">The number of times a report can fail the safety check and still be considered safe.</param>
        /// <param name="expected">Expected values.</param>
        [Theory]
        [InlineData(false, "2")]
        [InlineData(true, "4")]
        public void CountSafeReports(bool problemDampener, string expected)
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\2.txt");

            //Act
            var result = AdventOfCode.CountSafeReports(data, problemDampener);

            //Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Test for the ScanMemory method.
        /// </summary>
        /// <param name="conditional">True to process conditional commands, false to skip.</param>
        /// <param name="expected">Expected result.</param>
        [Theory]
        [InlineData(false, ".\\Data\\3A.txt", "161")]
        [InlineData(true, ".\\Data\\3B.txt", "48")]
        public void ScanMemory(bool conditional, string file, string expected)
        {
            //Arrange
            var data = File.ReadAllLines(file);

            //Act
            var result = AdventOfCode.ScanMemory(data, conditional);

            //Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests the WordSearch method.
        /// </summary>
        [Fact]
        public void WordSearch()
        {
            //Arrange
            var puzzle = File.ReadAllLines(".\\Data\\4.txt");

            //Act
            var result = AdventOfCode.WordSearch(puzzle);

            //Assert
            Assert.Equal("18", result);
        }

        /// <summary>
        /// Tests the WordSearchX method.
        /// </summary>
        [Fact]
        public void WordSearchX()
        {
            //Arrange
            var puzzle = File.ReadAllLines(".\\Data\\4.txt");

            //Act
            var result = AdventOfCode.WordSearchX(puzzle);

            //Assert
            Assert.Equal("9", result);
        }

        /// <summary>
        /// Tests the CheckSafetyManualUpdate method.
        /// </summary>
        [Fact]
        public void CheckSafetyManualUpdate()
        {
            //Arrange
            var input = File.ReadAllLines(".\\Data\\5.txt");

            //Act
            var result = AdventOfCode.CheckSafetyManualUpdate(input);

            //Assert
            Assert.Equal("143", result);
        }
    }
}
