using LoopsAndStrings.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopsAndStrings.Tests
{
    public class CinemaHelperTests
    {
        // Med Theory och InlineData kan flera fall testas i samma metod
        [Theory]
        [InlineData(4u, 0)]      // Barn
        [InlineData(10u, 80)]    // Ungdom
        [InlineData(30u, 120)]   // Vuxen
        [InlineData(70u, 90)]    // Pensionär
        [InlineData(105u, 0)]    // Åldringspris
        //[InlineData(121u, 0)]    // Över maxålder
        //[InlineData(-1u, 0)]    // Under minålder
        public void GetTicketPriceByAge_ShouldReturnExpectedPrice(uint age, decimal expected)
        {
            // Act
            var result = CinemaHelper.GetTicketPriceByAge(age);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("25", 0u, 120u, true)]
        [InlineData("abc", 0u, 120u, false)]  // Ej siffror
        [InlineData("200", 0u, 120u, false)]  // Över maxålder
        [InlineData("-5", 0u, 120u, false)]  // Under minålder
        [InlineData("", 0u, 120u, false)]  // Tom sträng
        [InlineData(null, 0u, 120u, false)]  // null
        public void CheckAgeInput_ShouldValidateAgeCorrectly(string input, uint min, uint max, bool expectedSuccess)
        {
            // Act
            var success = CinemaHelper.CheckAgeInput(input, min, max, out uint age);

            // Assert
            Assert.Equal(expectedSuccess, success);
        }


    }
}
