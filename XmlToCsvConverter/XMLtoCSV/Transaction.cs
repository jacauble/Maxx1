using System;

namespace XMLtoCSV
{
    internal class Transaction
    {
        internal string TransactionId { get; set; }
        internal string OriginPath { get; set; }
        internal string DestinationPath { get; set; }

        internal Transaction(string sourceFilePath, string destinationFilePath)
        {
            TransactionId = Convert.ToString(DateTime.Now);
            OriginPath = sourceFilePath;
            DestinationPath = destinationFilePath;
        }
    }
}
