using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL
{
    public class Log
    {
        public static void RegistroLog(String message)
        {
            try
            {
                String getName = DateTime.Now.ToString("dd-MM-yyyy");
                String folderTemp = AppDomain.CurrentDomain.BaseDirectory;
                String dirLog = "Logs";

                String path = Path.Combine(folderTemp, dirLog, getName + ".txt");

                if (!Directory.Exists(Path.Combine(folderTemp, dirLog)))
                    Directory.CreateDirectory(Path.Combine(folderTemp, dirLog));

                if (!File.Exists(path))
                    File.Create(path).Dispose();

                StreamWriter file;
                file = File.AppendText(path);
                file.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                file.WriteLine(message);
                file.WriteLine();
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
