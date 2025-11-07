using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopsAndStrings.Helpers;

namespace LoopsAndStrings
{
    internal static class MainProgram
    {
        internal static void Run()
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
                        DisplayCinemaMenu();
                        break;
                    case "2":
                        PrintUserInputX10();
                        break;
                    case "3":
                        PrintWordNoThree();
                        break;
                    default:
                        Console.WriteLine("Felaktig input. Försök igen.");
                        break;
                }
            } while (!exitMenu);

            Console.WriteLine("Programmet avslutas");
        }

        private static void DisplayCinemaMenu()
        {
            string? menuChoice;
            bool exitMenu = false;

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
                        SingleTickets();
                        break;
                    case "2":
                        GroupTickets();
                        break;
                    default:
                        Console.WriteLine("Felaktig input. Försök igen.");
                        break;
                }
            } while (!exitMenu);
        }


        //Upprepar en användares inmatade text tio gånger, utan radbrytning
        private static void PrintUserInputX10()
        {
            Console.WriteLine($"{Environment.NewLine}Ange text som ska skrivas ut 10 gånger:");
            string? userInput = Console.ReadLine();                       // Todo: Lägg till helper som hanterar tom sträng

            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i}. {userInput}");

                if (i != 10)
                    Console.Write(", "); // Mellanslag och komma läggs på angiven text i alla utskrifter utom sista (i==10)
            }

            Console.WriteLine($"{ Environment.NewLine}");
        }


        //Skriver ut det tredje ordet i en mening   
        public static void PrintWordNoThree()
        {
            bool success;
            string[]? wordArray;

            do
            {
                Console.WriteLine($"{Environment.NewLine}Ange en mening på minst 3 ord:");
                wordArray = Console.ReadLine()?.Split(' ');
                success = wordArray?.Length >= 3;

                if (!success)
                    Console.WriteLine("Felaktig inmatning. Försök igen.");

            } while (!success);

            Console.WriteLine($"Det tredje ordet i meningen är {wordArray?[2]} {Environment.NewLine}{Environment.NewLine}");

        }


        private static void GroupTickets()
        {
            bool success;
            Console.WriteLine("Hur många är ni i sällskapet?");
            int.TryParse(Console.ReadLine(), out int noOfCustomers);  // Todo: Flytta till Helpers.CheckNoOfCustomers
            int counter = 0, age;
            decimal totalGroupPrice = 0;

            while (noOfCustomers > 0)
            {
                counter++;
                do
                { 
                    Console.WriteLine($"Ange ålder på person {counter}:");
                    success = InputHelpers.CheckAgeInput(Console.ReadLine(), 0, 120, out age);
                    if (!success)
                        Console.WriteLine("Felaktigt val. Försök igen.");
                } while (!success);

                totalGroupPrice += GetTicketPriceByAge(age);
                noOfCustomers--;
            }

            Console.WriteLine($"Antal personer: {counter}. Totalpris: {totalGroupPrice}");
        }

        static void SingleTickets()
        {
            const int minAge = 0, maxAge = 120;
            bool success;
            int age;

            // Loopa tills angiven ålder är giltig
            do
            {
                Console.WriteLine("Ange ålder:");
                success = InputHelpers.CheckAgeInput(Console.ReadLine(), minAge, maxAge, out age);
                if (!success)
                    Console.WriteLine("Felaktigt val. Försök igen."); //Todo: Lägga denna i CheckAgeInput() istället?
            } while (!success);

            decimal ticketPrice = GetTicketPriceByAge(age);

            if (age < 20)
            {
                if (age <= 5)
                    Console.WriteLine($"Barnpris: {ticketPrice} kr");
                else
                    Console.WriteLine($"Ungdomspris: {ticketPrice} kr");
            }
            else if (age > 64)
            {
                if (age <= 100)
                    Console.WriteLine($"Pensionärspris: {ticketPrice} kr");
                else
                    Console.WriteLine($"Åldringspris: {ticketPrice} kr");
            }
            else
            {
                Console.WriteLine($"Standardpris: {ticketPrice} kr");
            }

            Console.WriteLine();
        }

        private static decimal GetTicketPriceByAge(int age)
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
