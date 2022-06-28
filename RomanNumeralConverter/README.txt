---Convert from yyyy to Roman Numerals---
by Jon Cauble
Framework: .NET 5
Language: C#

This simple application converts a year in the 'yyyy' Arabic numeral format to Roman numeral format.  It also has the basic framework ready to convert Roman numeral formatted dates into 'yyyy' Arabic numeral format.  However, it needs an appropriate input validation sequence to to make this function viable.  All functions are limited to year values above 0 AND below 4000.  This is due to the way that Roman numerals above the value 3999 are handled.  The ability to process values above 3999 can be achieved through additional code.

The user experience includes:

1) In the CLI, choose between 'yyyy to Roman numerals' and 'Roman numerals to yyyy.'  There is an input validation check.

2) Enter a year value in the selected format.

3) The input year is displayed in Roman numerals (or Arabic numerals, depending on mode) in the CLI.