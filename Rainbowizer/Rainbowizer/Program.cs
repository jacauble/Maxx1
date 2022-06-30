using System;
using Library1;

namespace TestConsole
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("---RAINBOWIZER TEST CONSOLE---\n");
            Console.Write("Enter the text that you would like Rainbowized\n >> ");
            string inputText = Console.ReadLine();
            Console.Write("\n\n\nThe 'Sequential-rainbow' style: ");
            Rainbowizer.Sequential(inputText);
            Console.Write("\n\n\nThe 'Random-rainbow' style: ");
            Rainbowizer.Random(inputText);
            Console.Write("\n\n\nThe 'ByWord-rainbow' style: ");
            Rainbowizer.ByWord(inputText);
            Console.Write("\n\n\nAn example of a custom palette in 'Sequential' style: ");
            Rainbowizer.Test(inputText);
            Console.Write("\n\n\nWords can also be ");
            Rainbowizer.Sequential("RaInBoWiZeD");
            Console.WriteLine(" within a sentence.");
            Console.Write("\n\n\n\n\nPress any key to exit application...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}