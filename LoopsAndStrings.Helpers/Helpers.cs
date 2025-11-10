using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

// Helper-klasser är projekt- eller lagerspecifika och återanvänds vanligtvis inte i andra projekt.

namespace LoopsAndStrings.Helpers
{
    public static class Helper
    {
        //CheckAgeInput() returnerar om angiven ålder är giltig och angiven ålder konverterad till int 
        public static bool CheckAgeInput(string? ageInput, uint minAge, uint maxAge, out uint age)
        {   
            bool success = uint.TryParse(ageInput?.Trim(), out age) && age >= minAge && age <= maxAge;
            return success;
        }

        public static bool CheckNoOfCustomers(string? noOfCustomersStr, uint minNo, uint maxNo, out int noOfCustomers)
        {
            bool success = int.TryParse(noOfCustomersStr, out noOfCustomers);  // Kolla om strängen NoOfCustomersStr går att kovertera till ett heltal 

            return success && (noOfCustomers >= minNo && noOfCustomers <= maxNo); // Returnera hur strängkonverteringen gick och om antalet är inom intervallet
        }

        public static decimal GetTicketPriceByAge(uint age)
        {
            switch (age)
            {
                case < 20:
                    switch (age)
                    {
                        case < 5:
                            return 0;
                    }
                    return 80;
                case > 64:
                    switch (age)
                    {
                        case > 100:
                            return 0;
                    }
                    return 90;
                default:
                    return 120;
            }
        }
    }
}
