---Rainbowizer---
by Jon Cauble
Framework: .NET 5
Language: C#

The Rainbowizer takes boring old console output and adds a fun splash.  The color palettes are customizable and the color distribution can be set to Sequential, Random, or ByWord.  Just add the Rainbowizer.cs file to your project and it is ready out of the box.  Simple customization is available too with just a few lines of code.

Here's how it works...
1) Set your color palette by adding colors to the List<ConsoleColor>.  A palette is then called by the chosen method (defaults: Sequential, Random, or ByWord).
2) When writing your code, send the string you want Rainbowized to the chosen method (defaults: Sequential, Random, or ByWord).
3)When your application is executed, the selected text will be RAINBOWIZED!!!  The following image is from a test console.


This is the first library tool I built.  I plan to rebuild it soon using object oriented programming methods and possibly a user interface.