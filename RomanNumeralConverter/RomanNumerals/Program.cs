using System;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuSelection = TopMenu();
            while ( menuSelection != "1" && menuSelection != "2")
            {
                Console.Clear();
                menuSelection = TopMenu();    
            }
            switch (menuSelection)
            {
                case "1":
                    IntToRomanNumerals();
                    break;
                case "2":
                    RomamnNumeralsToInt();
                    break;
                default:
                    Console.WriteLine("DEFAULT");
                    break;
            };
            Console.ReadKey();
            Environment.Exit(0);
        }
        //----------------//
        //----------------//
        static string TopMenu()
        {
            Console.WriteLine("       CHOOSE AN OPTION");
            Console.WriteLine("     --------------------\n");
            Console.WriteLine("(1) -- YYYY TO ROMAN NUMERALS");
            Console.WriteLine("(2) -- ROMAN NUMERALS TO YYYY\n");
            Console.Write(">> ");
            string menuSelection = Console.ReadLine();

            return menuSelection;
        }
        static void IntToRomanNumerals()
        {
            Year yearAsObject = AcceptInputAsInt();
            PrintResultIntToRomanNumerals(yearAsObject);
        }
        static void RomamnNumeralsToInt()
        {
            Year yearAsObject = AcceptInputAsString();
            PrintResultRomanNumeralsToInt(yearAsObject);
        }
        //
        //ACCEPT INPUT (AN to RN)
        //
        static Year AcceptInputAsInt()
        {
            Console.Clear();
            Console.Write("Enter a year between 1 and 3999 (yyyy format) >> ");
            int yearAsInt = Convert.ToInt32(Console.ReadLine());
            while (yearAsInt > 3999 || yearAsInt < 1)
            {
                Console.Clear();
                Console.Write("Enter a year between 1 and 3999 (yyyy format) >> ");
                yearAsInt = Convert.ToInt32(Console.ReadLine());
            }
            return new Year(yearAsInt);
        }
        //
        //ACCEPT INPUT (RN to AN)
        //
        static Year AcceptInputAsString()
        {
            Console.Clear();
            Console.Write("Enter a year between 1 and 3999 (Roman numerals format) >> ");
            string yearAsString = Console.ReadLine().ToUpper();
            while (yearAsString == "foo") // Input validation needed. This function is not yet ready.
            {
                Console.Clear();
                Console.Write("Enter a year between 1 and 3999 (Roman numerals format) >> ");
                yearAsString = Console.ReadLine();
            }
            return new Year(yearAsString);
        }
        //
        // DISPLAY
        //
        static void PrintResultIntToRomanNumerals(Year yr)
        {
            Console.WriteLine($"\nYour year ( {yr.AsInt} ) in Roman numerals is: {yr.AsString}");
            Console.WriteLine("\n\nPress any key to terminate the application...");
        }
        static void PrintResultRomanNumeralsToInt(Year yr)
        {
            Console.WriteLine($"\nYour year ( {yr.AsString} ) in Arabic numerals is: {yr.AsInt}");
            Console.WriteLine("\n\nPress any key to terminate the application...");
        }
    }
}
