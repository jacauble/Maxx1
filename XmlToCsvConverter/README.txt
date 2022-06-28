---Convert from XML to CSV - Vendor Availability List 001---
by Jon Cauble
Framework: .NET 5
Language: C#

This application is intended to fulfill a very specific business need for the management of a tropical fish store that wants to automate some inventory processes.  The company recently implemented an information system that cooperates best with CSV files.  Their main fish supplier releases an XML file of their sales inventory on a weekly schedule.

This app, which converts a list of records in XML file format to a CSV file, requires user the user to input the source and destination file paths in a command line interface.  The steps in this process are as follows:

1) download the .xml file from the vendor
2) run the application, setting the source and destination file paths
3) the .csv file is now in the chosen location, the data able to be used by other processes.

If the source file path is not recognized, the application loops until a recognizable file path is input.

If a file already exists at the destination file path, the application deletes and overwrites the file after receiving permission.  If permission is denied, the application terminates after a final ReadKey() prompt.

In this demo version, the source file path defaults to " Data/xml-doc.xml " and the destination file path defaults to " Data/csv-doc.csv " to make the demonstration less reliant on operating system permission idiosyncrasies.  You must still enter a recognizable source file path regardless, as there is an addition File.Exists() check.

You can locate the source file at this path: " /XmlToCsvConverter/XMLtoCSV/bin/Debug/net5.0/Data/xml-doc.xml "

This is a rough proof of concept and ignores important elements like input validation and being fully modularized.  Additional features could include integrating additional file type conversion processes, augmenting the user interface/experience, and loading the POCOs into a relational database.