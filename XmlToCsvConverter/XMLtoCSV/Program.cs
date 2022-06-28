using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;


namespace XMLtoCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Convert from XML to CSV - Vendor Availability List 001---\n");
            Console.Write("Enter the full file path (including file name and extension) of the source XML file\n>> ");
            string sourceFilePath = Console.ReadLine();
            while (!File.Exists(sourceFilePath))
            {
                Console.Write("File not found...\n\nEnter the file path of the XML file\n>> ");
                sourceFilePath = Console.ReadLine();
            }
            Console.WriteLine("File found...\n");
            Console.Write("Enter the full file path (including file name and extension) to where you want the CSV file saved\n>> ");
            string destinationFilePath = Console.ReadLine();
            if (File.Exists(destinationFilePath))
            {
                Console.Write("The file name already exists.  Do you want to overwrite it? [y/N] >> ");
                string yesOrNo = Console.ReadLine();
                while (yesOrNo != "y" && yesOrNo != "Y" && yesOrNo != "N" && yesOrNo != "n")
                {
                    Console.Write($"Incorrect character entered. Overwrite file? [y/N] >> ");
                    yesOrNo = Console.ReadLine();
                }
                if (yesOrNo == "y" || yesOrNo == "Y")
                {
                    ETL(sourceFilePath, destinationFilePath);
                }
                else
                {
                    Console.Write("PROCESS CANCELLED");
                }
            }
            else
            {     
                ETL(sourceFilePath, destinationFilePath);
            }
            Console.Write("\nPress any key to terminate the application...");
            Console.ReadKey();
            Environment.Exit(0);
        }
        public static void ETL(string sourceFilePath, string destinationFilePath)
        {
            Transaction transact1 = new Transaction(sourceFilePath, destinationFilePath);

            Console.WriteLine("\nnow extracting data...");
            List<Record> extractedRecords = Record.Extract(transact1);
            Console.WriteLine("now loading data...");
            Record.Load(transact1, extractedRecords);
        }
    }
}