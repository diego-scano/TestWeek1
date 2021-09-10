using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek1
{
    public class Spesa
    {
        public DateTime Data { get; set; }
        public string Categoria { get; set; }
        public string Descrizione { get; set; }
        public double Importo { get; set; }
        public bool Approvata { get; set; }
        public string LvlApprov { get; set; }
        public double Rimborso { get; set; }

        public void isApproved()
        {
            if (Importo >= 1 && Importo <= 400)
            {
                Approvata = true;
                LvlApprov = "Manager";
            }
            else if (Importo > 400 && Importo <= 1000)
            {
                Approvata = true;
                LvlApprov = "Operational Manager";
            }
            else if (Importo > 1000 && Importo <= 2500)
            {
                Approvata = true;
                LvlApprov = "CEO";
            }
            else
            {
                Approvata = false;
                LvlApprov = "Respinta";
            }
        }

        public void quantoRimborso()
        {
            if (Categoria.Equals("Viaggio"))
            {
                Rimborso = Importo + 50;
            }else if (Categoria.Equals("Alloggio"))
            {
                Rimborso = Importo;
            }else if (Categoria.Equals("Vitto"))
            {
                Rimborso = (Importo * 70) / 100;
            }else if (Categoria.Equals("Altro"))
            {
                Rimborso = (Importo * 10) / 100;
            }
        }

        public void LoadFromFile() // non implementata
        {
            string path = @"C:\Users\diego.scano\Desktop\TestWeek1\TestWeek1\spese.txt";
            try
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    string[] dati = reader.ReadLine().Split(";");
                    DateTime.TryParse(dati[0], out DateTime data);
                    string categoria = dati[1];
                    string descrizione = dati[2];
                    double.TryParse(dati[3], out double importo);

                    List<Spesa> spese = new List<Spesa>();
                    while(reader.ReadLine() != null)
                    {
                        spese.Add(new Spesa { Data = data, Categoria = categoria, Descrizione = descrizione, Importo = importo });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            };          
        }

        public void SaveToFile()
        {
            string path = @"C:\Users\diego.scano\Desktop\TestWeek1\TestWeek1\spese_elaborate.txt";
            try
            {
                using(StreamWriter writer = File.AppendText(path))
                {
                    if(Approvata == true)
                    {
                        writer.WriteLine($"{Data.ToShortDateString()};{Categoria};{Descrizione};Approvata;{LvlApprov};{Rimborso}");
                    }
                    else
                    {
                        writer.WriteLine($"{Data.ToShortDateString()};{Categoria};{Descrizione};Respinta");
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
