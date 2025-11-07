using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopsAndStrings.Helpers
{
    public static class InputHelpers
    {
        //CheckAgeInput() returnerar: om angiven ålder är giltig, samt angiven ålder konverterad till int 
        public static bool CheckAgeInput(string? ageInput, int minAge, int maxAge, out int age)
        {   
            bool _success = int.TryParse(ageInput?.Trim(), out age) && age >= minAge && age <= maxAge;
            return _success;
        }
    }
}
