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
        [InlineData("  Tjabba   tjena       hallå  ", 4, null)]  // Fel. Ord nr 4 saknas i strängen
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
        [InlineData("Hej", false, true)]  // Korrekt textsträng om tom/space ej tillåtna 
        [InlineData("Hej", true, true)]  // Korrekt textsträng om tom/space tillåtna 
        [InlineData("", false, false)]    // Korrekt textsträng om tom/space ej tillåtna
        [InlineData("", true, true)]    // Korrekt textsträng om tom/space tillåtna
        [InlineData("   ", false, false)] // Ej korrekt textsträng om tom/space ej tillåtna
        [InlineData("   ", true, true)] // Korrekt textsträng om tom/space tillåtna        
        [InlineData(null, false, false)] // Ej korrekt textsträng om tom/space ej tillåtna
        [InlineData(null, true, false)] // Korrekt textsträng om tom/space tillåtna
        public void IsStringValidText_ShouldValidateProperly(string? input, bool allowEmptyOrBlanksOnly, bool expected)
        {
            var result = StringUtils.IsStringValidText(input, allowEmptyOrBlanksOnly);
            Assert.Equal(expected, result);

        }

        [Fact]
        public void RepeatText_ShouldReturnCorrectlyFormattedString()
        {
            var result = StringUtils.RepeatText("hej", 3);

            Assert.Equal("1. hej, 2. hej, 3. hej", result);

            result = StringUtils.RepeatText("hej", 0);

            Assert.Equal("", result);
            
        }

    }
}
