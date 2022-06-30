using System;
using System.Collections.Generic;
using static System.Console;

namespace Library1
{
    internal class Rainbowizer
    {
        // This library class accomplishes the goal of RAINBOWIZING a string, meaning that the text is displayed in the console in a more colorful way.  There are three versions included in
        // this version: Rainbowizer.Sequential(), Rainbowizer.ByWord(), and Rainbowizer.Random().  The best way to incorporate this utility into your application is by adding the
        // entire Rainbowizer class to your C# project.  You can then utilize the functionality by calling one of the included methods using 'Class.Method(argument);' call format. Please note that
        // the console output statements are contained within the methods and that the methods do not return a value (therefore, do not use 'variable = Class.Method(argument)' call format).
        // Additionally, note that you can easily customize your color palettes as well as add additional color palettes.  Look for '***' and '/*Foo*/' which denote areas that can be edited to
        // access additional features.
        public static void Sequential(string inputText) // Call this method (e.g. Rainbowizer.Sequential(stringYouWantRainbowized);) to display sequential RAINBOWIZED version of passed argument
        {
            List<ConsoleColor> colorPalette = SetColorsRainbow(); // This method call gets the color palette from SetColors() method - ***You can access alternate palettes by creating new SetColors() methods and changing the method call to reflect the chosem SetColors() palette***
            char[] characters = inputText.ToCharArray(); // Converts inputString to an array of characters (necessary in order to assign a new color to each individual character)

            for (int ch = 0, color = 0; ch < characters.Length; ch++) // Loops through array of characters (converted from inputString) to assign a new color to each sequential, non-'space' character
            {
                if (characters[ch] != ' ') // This selection prevents charachers that bookend a 'space' character from sharing a color
                {
                    if (color == colorPalette.Count) // This selection resets the incremented index position to the primary element of the color palette list once it has reached the ultimate element
                    {
                        color = 0;
                    }
                    ForegroundColor = colorPalette[color]; // This statement assigns the color for next character
                    color++; // This statement increments the index position of the color palette
                }
                Write($"{characters[ch]}"); // This statement writes the Rainbowized text to Console //++ Original
            }
            ResetColor();
        }
        public static void ByWord(string inputText) // Call this method (e.g. Rainbowizer.ByWord(stringYouWantRainbowized);) to display word-by-word RAINBOWIZED version of passed argument
        {
            List<ConsoleColor> colorPalette = SetColorsRainbow(); // This method call gets the color palette from SetColors() method - ***You can access alternate palettes by creating new SetColors() methods and changing the method call to reflect the chosem SetColors() palette***
            char[] characters = inputText.ToCharArray(); // Converts inputString to an array of characters (necessary in order to assign a new color to each individual character)

            for (int ch = 0, color = 0; ch < characters.Length; ch++) // Loops through array of characters (converted from inputString) to assign a new color to each sequential, non-'space' character
            {
                ForegroundColor = colorPalette[color]; // This statement initializes the first color
                if (characters[ch] == ' ') // This selection creates a condition where the index of color palette increments at each 'space' character
                {
                    color++; // This statement increments the index position of the color palette
                    if (color == colorPalette.Count) // This selection resets the incremented index position to the primary element of the color palette list once it has reached the ultimate element
                    {
                        color = 0;
                    }
                    ForegroundColor = colorPalette[color]; // This statement assigns the color for next character
                }
                Write($"{characters[ch]}"); // This statement writes the Rainbowized text to Console
            }
            ResetColor();
        }
        public static void Random(string inputText) // Call this method (e.g. Rainbowizer.Random(stringYouWantRainbowized);) to display ramdomized RAINBOWIZED version of passed argument
        {
            List<ConsoleColor> colorPalette = SetColorsRainbow(); // This method call gets the color palette from SetColors() method - ***You can access alternate palettes by creating new SetColors() methods and changing the method call to reflect the chosem SetColors() palette***
            Random randomColor = new Random();
            int nextColor = randomColor.Next(0, colorPalette.Count); // This statements generates a random number which corresponds to an index of the color palette list
            char[] characters = inputText.ToCharArray(); // Converts inputString to an array of characters (necessary in order to assign a new color to each individual character)

            for (int ch = 0; ch < characters.Length; ch++) // Loops through array of characters (converted from inputString) to assign a new, random color to each sequential character
            {
                if (characters[ch] != ' ') // This selection prevents charachers that bookend a 'space' character from sharing a color
                {
                    nextColor = DoNotRepeat(colorPalette, nextColor); // This method call prevents any two adjacent characters from sharing the same color
                    ForegroundColor = colorPalette[nextColor]; // This statement assigns the color for next character
                }
                Write($"{characters[ch]}"); // [This statement writes the Rainbowized text to Console]
            }
            ResetColor(); // This statement reverts the text color to default
        }
        public static void Test(string inputText)
        {
            List<ConsoleColor> colorPalette = SetColorsUSA();
            char[] characters = inputText.ToCharArray();

            for (int ch = 0, color = 0; ch < characters.Length; ch++)
            {
                if (characters[ch] != ' ')
                {
                    if (color == colorPalette.Count)
                    {
                        color = 0;
                    }
                    ForegroundColor = colorPalette[color];
                    color++;
                }
                Write($"{characters[ch]}");
            }
            ResetColor();
        }
        public static List<ConsoleColor> SetColorsRainbow() // This method allows programmer to customize the color palette
        {
            ConsoleColor black = ConsoleColor.Black;             // This is the masterlist of available console colors
            ConsoleColor blue = ConsoleColor.Blue;               //
            ConsoleColor cyan = ConsoleColor.Cyan;               //
            ConsoleColor darkBlue = ConsoleColor.DarkBlue;       //
            ConsoleColor darkCyan = ConsoleColor.DarkCyan;       //
            ConsoleColor darkGray = ConsoleColor.DarkGray;       //
            ConsoleColor darkGreen = ConsoleColor.DarkGreen;     //
            ConsoleColor darkMagenta = ConsoleColor.DarkMagenta; //
            ConsoleColor darkRed = ConsoleColor.DarkRed;         //
            ConsoleColor darkYellow = ConsoleColor.DarkYellow;   //
            ConsoleColor gray = ConsoleColor.Gray;               //
            ConsoleColor green = ConsoleColor.Green;             //
            ConsoleColor magenta = ConsoleColor.Magenta;         //
            ConsoleColor red = ConsoleColor.Red;                 //
            ConsoleColor white = ConsoleColor.White;             //
            ConsoleColor yellow = ConsoleColor.Yellow;           //
            List<ConsoleColor> colorPalette = new List<ConsoleColor> { red, darkYellow, yellow, green, blue, cyan, magenta };

            return colorPalette;
        }
        public static List<ConsoleColor> SetColorsUSA() // ***This is an iteration of an alternate color palette***
        {
            ConsoleColor black = ConsoleColor.Black;             // This is the masterlist of available console colors
            ConsoleColor blue = ConsoleColor.Blue;               //
            ConsoleColor cyan = ConsoleColor.Cyan;               //
            ConsoleColor darkBlue = ConsoleColor.DarkBlue;       //
            ConsoleColor darkCyan = ConsoleColor.DarkCyan;       //
            ConsoleColor darkGray = ConsoleColor.DarkGray;       //
            ConsoleColor darkGreen = ConsoleColor.DarkGreen;     //
            ConsoleColor darkMagenta = ConsoleColor.DarkMagenta; //
            ConsoleColor darkRed = ConsoleColor.DarkRed;         //
            ConsoleColor darkYellow = ConsoleColor.DarkYellow;   //
            ConsoleColor gray = ConsoleColor.Gray;               //
            ConsoleColor green = ConsoleColor.Green;             //
            ConsoleColor magenta = ConsoleColor.Magenta;         //
            ConsoleColor red = ConsoleColor.Red;                 //
            ConsoleColor white = ConsoleColor.White;             //
            ConsoleColor yellow = ConsoleColor.Yellow;           //
            List<ConsoleColor> colorPalette = new List<ConsoleColor> { red, white, blue };

            return colorPalette;
        }
        public static List<ConsoleColor> SetColorsMyCustomPalette() // ***This is an iteration of an alternate color palette***
        {
            ConsoleColor black = ConsoleColor.Black;             // This is the masterlist of available console colors
            ConsoleColor blue = ConsoleColor.Blue;               //
            ConsoleColor cyan = ConsoleColor.Cyan;               //
            ConsoleColor darkBlue = ConsoleColor.DarkBlue;       //
            ConsoleColor darkCyan = ConsoleColor.DarkCyan;       //
            ConsoleColor darkGray = ConsoleColor.DarkGray;       //
            ConsoleColor darkGreen = ConsoleColor.DarkGreen;     //
            ConsoleColor darkMagenta = ConsoleColor.DarkMagenta; //
            ConsoleColor darkRed = ConsoleColor.DarkRed;         //
            ConsoleColor darkYellow = ConsoleColor.DarkYellow;   //
            ConsoleColor gray = ConsoleColor.Gray;               //
            ConsoleColor green = ConsoleColor.Green;             //
            ConsoleColor magenta = ConsoleColor.Magenta;         //
            ConsoleColor red = ConsoleColor.Red;                 //
            ConsoleColor white = ConsoleColor.White;             //
            ConsoleColor yellow = ConsoleColor.Yellow;           //
            List<ConsoleColor> colorPalette = new List<ConsoleColor> { /*You can customize your color palette here*/ };

            return colorPalette;
        }
        public static int DoNotRepeat(List<ConsoleColor> colorPalette, int nextColor) // This method ensures that a color does not repeat for adjacent characters
        {
            Random randomColor = new Random();

            int nextColor2 = randomColor.Next(0, colorPalette.Count);
            while (nextColor == nextColor2)
            {
                nextColor2 = randomColor.Next(0, colorPalette.Count);
            }
            nextColor = nextColor2;

            return nextColor;
        }
        // © 2021 Jonathan Cauble
    }
}
