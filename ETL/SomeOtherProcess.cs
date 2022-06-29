using System;
using System.Collections.Generic;

// This ETL process extracts:
// //
// Destination Type:
// //
namespace ETL
{
    internal class SomeOtherProcess
    {
        public static void SomeOtherProcessMain()
        {
            Console.WriteLine("---SomeOtherProcess---");
        // EXTRACT
            Console.WriteLine("extracting Fake File 1...");
            // Code goes here
            Console.WriteLine("extracting Fake File 2...");
            // Code goes here
            Console.WriteLine("extracting Fake File 3...");
            // Code goes here
        // TRANSFORM
            Console.WriteLine("transforming data...");
            //List<TransformedSomeOtherProcess> transformedData = new List<TransformedSomeOtherProcess>();
        // LOAD
            Console.WriteLine("loading to some made up place...");
            bool success = false;
            try
            {
                //LoadSomeOtherProcess(transformedData);
                success = true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {ex.Message}  --  Please contact system administrator.");
                Console.ResetColor();
            }
            finally
            {
                if (success == true)
                {
                    Console.WriteLine("process completed\n");
                }
            }
        }
        //internal static void LoadSomeOtherProcess(List<TransformedSomeOtherProcess> transformedData)
        //{
                // Code goes here
        //}
    }
}
