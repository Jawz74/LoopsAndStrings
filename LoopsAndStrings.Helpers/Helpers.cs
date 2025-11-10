using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

// Helper-klasser är projekt- eller lagerspecifika och återanvänds vanligtvis inte i andra projekt.

namespace LoopsAndStrings.Helpers
{
    public static class CinemaHelper
    {
        //CheckAgeInput() returnerar om angiven ålder är giltig och angiven ålder konverterad till uint
        //uint.TryParse() returnerar false om ålder är negativ.
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

        //Returnerar biljettpris baserat på ålder. Datatyp uint förhindrar negativt värde på age.
        //Prislista:
        //Barn 0-4 år: 0 kr. Ungdom 5-19 år: 80 kr. Standard (Vuxen) 20-64 år: 120 kr.
        //Pensionär 65-100 år: 90 kr. Åldring 101-120: 0kr.
        public static decimal GetTicketPriceByAge(uint age)
        {
            if (age < 5 || age > 100) return 0;
            if (age < 20) return 80;
            if (age > 64) return 90;
            return 120;
        }


    }
}
