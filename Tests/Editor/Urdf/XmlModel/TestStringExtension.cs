// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using NUnit.Framework;
using Preliy.Flange.Editor.XmlModel;
using UnityEngine;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestStringExtension
    {
        [Test]
        public void Parse_ValidInput_ReturnsCorrectVector()
        {
            // Arrange
            const string input = "1.23 4.56 -7.89";
            var expected = new Vector3(1.23f, 4.56f, -7.89f);

            // Act
            var actual = StringExtension.Parse(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Theory]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Parse_NullOrWhitespace_ThrowsArgumentNullException(string input)
        {
            Assert.Throws<ArgumentNullException>(() => StringExtension.Parse(input));
        }
        
        [Theory]
        [TestCase("1 2")]          // too few parts
        [TestCase("1 2 3 4")]      // too many parts
        public void Parse_WrongNumberOfParts_ThrowsFormatException(string input)
        {
            Assert.Throws<FormatException>(() => StringExtension.Parse(input));
        }
        
        [Test]
        public void Parse_InvalidFloats_ThrowsFormatException()
        {
            const string input = "a b c";
            var ex = Assert.Throws<FormatException>(() => StringExtension.Parse(input));
            var contains = ex.Message.Contains("Failed to parse");
            Assert.IsTrue(contains);
        }
        
        [Theory]
        [TestCase("1.0 2.0 3.0", 1f, 2f, 3f)]
        [TestCase("  1.5   2.5   -3.5  ", 1.5f, 2.5f, -3.5f)]  // extra spaces
        public void TryParse_ValidInput_ReturnsTrueAndOutputsCorrectVector(string input, float x, float y, float z)
        {
            // Act
            bool result = StringExtension.TryParse(input, out var vector);

            // Assert
            Assert.True(result);
            Assert.AreEqual(new Vector3(x, y, z), vector);
        }
        
        [Theory]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("1 2")]         // too few
        [TestCase("1 2 3 4")]     // too many
        [TestCase("a b c")]       // non-numeric
        public void TryParse_InvalidInput_ReturnsFalseAndOutputsZero(string input)
        {
            // Act
            bool result = StringExtension.TryParse(input, out var vector);

            // Assert
            Assert.False(result);
            Assert.AreEqual(Vector3.zero, vector);
        }
    }
}
