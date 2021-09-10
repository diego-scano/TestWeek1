using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek1
{
    public class GestoreEvento
    {
        public static void GestisciNuovoFile(object sender, FileSystemEventArgs e)
        {
            ReadFile(e);
        }

        private static void ReadFile(FileSystemEventArgs e)
        {
            try
            {
                using(StreamReader reader = File.OpenText(e.FullPath))
                {
                    Console.WriteLine("--- Inizio lettura file...");
                    string line = reader.ReadLine();
                    while(line != null)
                    {
                        Console.WriteLine(line);
                        line = reader.ReadLine();
                    }
                    Console.WriteLine("--- Fine del file");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
