// ETL PROCESSES
#define PurchIndClk
//#undef PurchIndClk
#define SomeOtherProcess
#undef SomeOtherProcess

using System;

// TEST CONSOLE
namespace ETL
{        
    public class Program
    {
        public static void Main()
        {
#if PurchIndClk
            PurchIndClk.PurchIndClkMain();            // SQLServer: DOTNET.REYNOLDS.EDU    Database: ITP236-03    Table: PurchasingDW
#endif
#if SomeOtherProcess
            SomeOtherProcess.SomeOtherProcessMain();          // Server: MADE.UP.NAME    Database: FOO123    Table: FakeTable
#endif
            Console.Write("\nALL PROCESSES COMPLETED - PRESS ANY KEY TO EXIT APPLICATION...");
            Console.ReadKey();
        }
    }
}
