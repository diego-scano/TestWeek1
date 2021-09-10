using System;
using System.Collections.Generic;
using System.IO;

namespace TestWeek1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher fsw = new FileSystemWatcher
            {
                Path = @"C:\Users\diego.scano\Desktop\TestWeek1\TestWeek1",
                Filter = "spese.txt"
            };

            fsw.EnableRaisingEvents = true;
            fsw.Created += GestoreEvento.GestisciNuovoFile;

            Console.WriteLine("In attesa del File spese.txt");
            Console.WriteLine("Premi q per uscire");
            while (Console.Read() != 'q') ;

            #region DATI MANUALI

            List<Spesa> spese = new List<Spesa>();
            spese.Add(new Spesa { Data = new DateTime(2013 , 12 , 20), Categoria = "Viaggio", Descrizione = "New York", Importo = 2600 });
            spese.Add(new Spesa { Data = new DateTime(2014 , 1 , 5), Categoria = "Altro", Descrizione = "Alimentari", Importo = 58 });
            spese.Add(new Spesa { Data = new DateTime(2014 , 1 , 15), Categoria = "Vitto", Descrizione = "Pasto", Importo = 12 });
            spese.Add(new Spesa { Data = new DateTime(2014 , 1 , 22), Categoria = "Alloggio", Descrizione = "Resort", Importo = 380 });
            spese.Add(new Spesa { Data = new DateTime(2014 , 2 , 10), Categoria = "Altro", Descrizione = "Smartphone", Importo = 800 });
            spese.Add(new Spesa { Data = new DateTime(2014 , 3 , 25), Categoria = "Viaggio", Descrizione = "Venezia", Importo = 500 });
            spese.Add(new Spesa { Data = new DateTime(2014 , 4 , 4), Categoria = "Alloggio", Descrizione = "Hotel", Importo = 3100 });
            spese.Add(new Spesa { Data = new DateTime(2014 , 4 , 23), Categoria = "Vitto", Descrizione = "Cena", Importo = 34 });
            spese.Add(new Spesa { Data = new DateTime(2014 , 5 , 12), Categoria = "Altro", Descrizione = "Chitarra", Importo = 1300 });
            spese.Add(new Spesa { Data = new DateTime(2014 , 6 , 3), Categoria = "Viaggio", Descrizione = "Maldive", Importo = 2800 });

            #endregion

            foreach (Spesa s in spese)
            {
                s.isApproved();
                s.quantoRimborso();
                s.SaveToFile();
            }

            Console.WriteLine("Dati salvati correttamente");
        }
    }
}
