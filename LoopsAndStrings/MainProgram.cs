using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopsAndStrings.Helpers;
using LoopsAndStrings.Utilities;

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
                        RunCinemaMenu();
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

            Console.WriteLine("Programmet avslutas");
        }

        //Skriver ut en meny för att räkna ut biobiljettpris (enkel- eller gruppbiljett).
        private static void RunCinemaMenu()
        {
            string? menuChoice;
            bool exitMenu = false;
            
            do
            {
                Console.WriteLine();
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
                success = Helper.CheckNoOfCustomers(Console.ReadLine(), 2, 20, out noOfCustomers);

                if (!success)
                    Console.WriteLine("Felaktigt antal personer. Försök igen.");

            } while (!success);

            for (int customerCount = 1; customerCount <= noOfCustomers; customerCount++)
            {  
               do
                { 
                    Console.WriteLine($"Ange ålder på person nr {customerCount}:");
                    success = Helper.CheckAgeInput(Console.ReadLine(), 0, 120, out age);
                    if (!success)
                        Console.WriteLine("Felaktig ålder. Försök igen.");
                } while (!success);

                totalGroupPrice += Helper.GetTicketPriceByAge(age);                
            }

            Console.WriteLine($"Antal personer: {noOfCustomers}. Totalpris: {totalGroupPrice} {Environment.NewLine}");
        }

        static void BuySingleTickets()
        {
            const uint minAge = 0, maxAge = 120;
            bool success;
            uint age;

            // Loopa tills angiven ålder är giltig
            do
            {
                Console.WriteLine("Ange ålder:");
                success = Helper.CheckAgeInput(Console.ReadLine(), minAge, maxAge, out age);
                if (!success)
                    Console.WriteLine("Felaktig ålder. Försök igen."); 
            } while (!success);

            decimal ticketPrice = Helper.GetTicketPriceByAge(age);

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
                success = Utils.IsStringValidText(userInput, false);
                if (!success)
                    Console.WriteLine("Felaktig text. Försök igen.");

            } while (!success);

            // Skriv ut användarens inmatade text 10 gånger, visa räknaren i output.
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i}. {userInput}");

                if (i != 10)
                    Console.Write(", "); // Mellanslag och komma läggs på angiven text i alla utskrifter utom sista (i==10)
            }

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
                success = Utils.FindNthWordInSentence(Console.ReadLine(), 3, out thirdWord);

                if (!success)
                    Console.WriteLine("Felaktig inmatning. Försök igen.");

            } while (!success);

            Console.WriteLine($"Det tredje ordet i meningen är '{thirdWord}' {Environment.NewLine}{Environment.NewLine}");
        }
    }
}
