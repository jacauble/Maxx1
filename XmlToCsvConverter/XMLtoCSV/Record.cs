using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XMLtoCSV
{
    internal class Record
    {
        public string Id { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string MinimumQuantity { get; set; }
        public string VendorPrice { get; set; }
        public string Category { get; set; }
        public string CsvString => Id + "," + CommonName + "," + ScientificName + "," + MinimumQuantity + "," + VendorPrice + "," + Category; // This property takes care of the 'transform' process in this application

        internal Record(XElement record)
        {
            Id = record.Value;
            CommonName = (string)record.Attribute("CommonName");
            ScientificName = (string)record.Attribute("ScientificName");
            MinimumQuantity = (string)record.Attribute("MinimumQuantity");
            VendorPrice = (string)record.Attribute("VendorPrice");
            Category = (string)record.Attribute("Category");
        }

        internal static List<Record> Extract(Transaction transact1)
        {
            string path = /*transact1.OriginPath*/@"Data/xml-doc.xml"; // Changed this for demo pruposes
            List<Record> extractedRecords = new List<Record>();

            if (File.Exists(path))
            {
                XElement XmlDoc = XElement.Load(path);
                foreach (var record in XmlDoc.Descendants($"Record"))
                {
                    Record singleRecord = new Record(record);
                    extractedRecords.Add(singleRecord);
                }
                Console.WriteLine("SUCCESSFUL");
            }
            else
            {
                Console.WriteLine("FILE NOT FOUND!");
            }
            return extractedRecords.OrderBy(rec => rec.Category).ThenBy(rec => rec.CommonName).ToList();
        }
        internal static void Load(Transaction transact1, List<Record> extractedRecords)
        {
            string path = /*transact1.DestinationPath*/@"Data/csv-doc.csv"; // Changed this for demo purposes
            List<string> recordsToBeLoaded = new List<string>();
            recordsToBeLoaded.Add("Id,Name,ScientificName,MinQ,Price,Category");
            foreach (var record in extractedRecords)
            {
                string csvRecord = record.CsvString;
                recordsToBeLoaded.Add(csvRecord);
            }
            if (File.Exists(path))
            {
                File.Delete(path);
                File.AppendAllLines(path, recordsToBeLoaded);
                Console.WriteLine("FILE OVERWRITE COMPLETE");
            }
            else
            {
                File.AppendAllLines(path, recordsToBeLoaded);
                Console.WriteLine("FILE CREATION COMPLETE");
            }
        }
    }
}
