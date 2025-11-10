using LoopsAndStrings.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopsAndStrings.Tests
{
    public class StringUtilsTests
    {
        [Theory]
        [InlineData("Hej du gamle indian", 3, "gamle")]  // Korrekt input o output
        [InlineData("Tjabba   tjena       hallå", 3, "hallå")]  // Korrekt input o output (med många whitespace)
        [InlineData("Ett två", 3, null)] // Fel, för få ord
        [InlineData("    ", 3, null)] // Fel, bara whitespace
        public void FindNthWordInSentence_ShouldReturnExpectedWord(string input, uint wordNo, string? expectedWord)
        {
            // Act
            var success = StringUtils.FindNthWordInSentence(input, wordNo, out string? result);

            // Assert
            if (expectedWord is null)
                Assert.False(success);
            else
            {
                Assert.True(success);
                Assert.Equal(expectedWord, result);
            }
        }

        [Theory]
        [InlineData("Hej", true)]
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData(null, false)]
        public void IsStringValidText_ShouldValidateProperly(string? input, bool expected)
        {
            var result = StringUtils.IsStringValidText(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RepeatText_ShouldReturnCorrectlyFormattedString()
        {
            var result = StringUtils.RepeatText("hej", 3);

            Assert.Equal("1. hej, 2. hej, 3. hej", result);
        }

    }
}
