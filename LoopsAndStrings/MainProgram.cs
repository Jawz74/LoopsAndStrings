using LoopsAndStrings.Helpers;
using LoopsAndStrings.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LoopsAndStrings
{
    internal static class MainProgram
    {
        //Skriver ut programmets huvudmeny.
        internal static void RunMainMenu()
        {            
            string? menuChoice;
            bool exitMenu = false;

            do
            {                
                Console.WriteLine("--------------- Huvudmeny ----------------");
                Console.WriteLine($"Välj genom att ange en siffra.{Environment.NewLine}");
                Console.WriteLine("1 - Räkna ut priset för biobesök.");
                Console.WriteLine("2 - Skriv ut en text 10 gånger på rad.");
                Console.WriteLine("3 - Skriv ut tredje ordet i en mening.");
                Console.WriteLine("0 - Avsluta.");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "0":
                        exitMenu = true;
                        break;
                    case "1":
                        ShowCinemaMenu();
                        break;
                    case "2":
                        PrintUserInputX10();
                        break;
                    case "3":
                        PrintWordNoThree();
                        break;
                    default:
                        Console.WriteLine("Felaktigt val. Försök igen.");
                        break;
                }
            } while (!exitMenu);

            Console.Clear();
            Console.WriteLine("Programmet avslutas");
        }

        //Skriver ut en meny för att räkna ut biobiljettpris (enkel- eller gruppbiljett).
        private static void ShowCinemaMenu()
        {
            string? menuChoice;
            bool exitMenu = false;

            Console.Clear();

            do
            {
                Console.WriteLine("--------------- Biomeny ----------------");
                Console.WriteLine($"Välj genom att ange en siffra.{Environment.NewLine}");
                Console.WriteLine("1 - Räkna ut priset för en besökare.");
                Console.WriteLine("2 - Räkna ut priset för ett helt sällskap.");
                Console.WriteLine("0 - Återgå till huvudmeny.");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "0":
                        exitMenu = true;
                        break;
                    case "1":
                        BuySingleTickets();                        
                        break;
                    case "2":
                        BuyGroupTickets();
                        break;
                    default:
                        Console.WriteLine("Felaktigt val. Försök igen.");
                        break;
                }
            } while (!exitMenu);

            Console.Clear();
        }

        static void BuySingleTickets()
        {
            uint age;
            
            age = GetValidAgeInput();

            decimal ticketPrice = CinemaHelper.GetTicketPriceByAge(age);

            if (age < 20)
            {
                if (age < 5)
                    Console.WriteLine($"Barnpris: {ticketPrice} kr");
                else
                    Console.WriteLine($"Ungdomspris: {ticketPrice} kr");
            }
            else if (age > 64)
            {
                if (age > 100)
                    Console.WriteLine($"Åldringspris: {ticketPrice} kr");
                else
                    Console.WriteLine($"Pensionärspris: {ticketPrice} kr");
            }
            else
            {
                Console.WriteLine($"Standardpris: {ticketPrice} kr");
            }

            Console.WriteLine();
        }

        private static void BuyGroupTickets()
        {
            bool success;
            int noOfCustomers;
            uint age;
            decimal totalGroupPrice = 0;

            Console.WriteLine("Hur många är ni i sällskapet?");
            
            do
            {
                success = CinemaHelper.CheckNoOfCustomers(Console.ReadLine(), 2, 20, out noOfCustomers);

                if (!success)
                    Console.WriteLine("Felaktigt antal personer. Försök igen.");

            } while (!success);

            for (int customerCount = 1; customerCount <= noOfCustomers; customerCount++)
            {  
               age = GetValidAgeInput($"Ange ålder på person nr { customerCount}:");
               totalGroupPrice += CinemaHelper.GetTicketPriceByAge(age);                
            }

            Console.WriteLine($"Antal personer: {noOfCustomers}. Totalpris: {totalGroupPrice} {Environment.NewLine}");
        }
               

        //Upprepar en användares inmatade text tio gånger, utan radbrytning
        private static void PrintUserInputX10()
        {
            bool success;
            string? userInput;

            // Loopa tills användaren matat in en giltig input (validerad genom metod i utilities-klass)
            do
            {
                Console.WriteLine($"{Environment.NewLine}Ange text som ska skrivas ut 10 gånger:");
                userInput = Console.ReadLine();
                success = StringUtils.IsStringValidText(userInput, false);
                if (!success)
                    Console.WriteLine("Felaktig text. Försök igen.");

            } while (!success);

            // Skriv ut användarens inmatade text 10 gånger, visa räknaren i output.
            Console.WriteLine(StringUtils.RepeatText(userInput, 10));

            Console.WriteLine($"{Environment.NewLine}");
        }


        //Skriver ut det tredje ordet i en mening   
        public static void PrintWordNoThree()
        {
            bool success;
            string? thirdWord;

            // Loopa tills användaren matat in en giltig input (kollen görs i FindNthWordInSentence())
            do
            {
                Console.WriteLine($"{Environment.NewLine}Ange en mening på minst 3 ord:");
                success = StringUtils.FindNthWordInSentence(Console.ReadLine(), 3, out thirdWord);

                if (!success)
                    Console.WriteLine("Felaktig inmatning. Försök igen.");

            } while (!success);

            Console.WriteLine($"Det tredje ordet i meningen är '{thirdWord}' {Environment.NewLine}{Environment.NewLine}");
        }

        // Metoden är garanterad att returnera en giltig ålder
        // TODO: Bör ligga i helper-klass, men Console.WriteLine() och .ReadLine() och gör den då svår att testa.
        private static uint GetValidAgeInput(string prompt = "Ange ålder:", string errorMessage = "Felaktig ålder. Försök igen:")
        {
            uint age;
            bool success;
            const uint minAge = 0, maxAge = 120;  // TODO: Ska man lägga dessa konstanter mer centralt? Enum:uint funkar inte i jämförelser med uint 

            // Loopa tills angiven ålder är giltig
            do
            {
                Console.WriteLine(prompt);
                success = CinemaHelper.CheckAgeInput(Console.ReadLine(), minAge, maxAge, out age);
                if (!success)
                    Console.WriteLine(errorMessage);
            } while (!success);

            return age;
        }
    }
}
