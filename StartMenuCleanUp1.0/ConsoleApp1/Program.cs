using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartMenuCleanUpConsole
{
    class Program
    {
        static void Main()
        {
            string path = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs";

            string[] array1 = Directory.GetFiles(@path, "*.lnk", SearchOption.AllDirectories);

            int NumCount = array1.Length;

            foreach (string name in array1)
            {
                Console.WriteLine(Path.GetFileName(name));
            }

            Console.Title = "Total Count = " + NumCount.ToString();
            Console.ReadLine();
        }
    }
}

