using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartMenuCleanUp1._0
{
    public class StartMenu
    {
        public static string path = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs";

        public static string[] array1 = Directory.GetFiles(@path, "*.lnk", SearchOption.AllDirectories);

        public static int NumCount = array1.Length;

        public static void GetStartMenu()
        {         
            foreach (string name in array1)
            {
                Form1.StartMenuList.Add(Path.GetFileName(name));
                Form1.StartMenuList.Sort();
            }
        }
    }
}
