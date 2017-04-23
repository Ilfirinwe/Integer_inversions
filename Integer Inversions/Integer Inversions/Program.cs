using Integer_Inversions.Common;
using Integer_Inversions.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integer_Inversions
{
    class Program
    {
        static DataStorage dataStorage;
        static void Main(string[] args)
        {
            var Data = new Int32[100000];
            using (var Reader = new StreamReader("Data.txt"))
                for (Int32 Iterator = 0; Iterator < 100000; Iterator++)
                    Data[Iterator] = Int32.Parse(Reader.ReadLine());
            dataStorage = new DataStorage(Data);

            Int64 InversionsCount = InversionsCounter.SortAndCountInversions(dataStorage.Data);

            Thread thread = new Thread(() => Clipboard.SetText(InversionsCount.ToString()));
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join();
        }
    }
}
