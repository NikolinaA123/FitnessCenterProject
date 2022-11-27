using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Komentari
    {
        public static List<Komentar> komentari { get; set; } = new List<Komentar>();

        public static List<Komentar> UcitajKomentare()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamReader r = new StreamReader(path + "komentari.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<Komentar>>(json);
                foreach (var item in items)
                {
                    komentari.Add(item);
                }
            }
            return komentari;
        }

        public static void UpisiKomentare()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            using (StreamWriter sw = new StreamWriter(path + "komentari.json", append: false))
            {
                sw.WriteLine("[");
                var items = komentari;
                foreach (var item in items)
                {
                    sw.WriteLine("{");
                    sw.WriteLine("\"AutorKomentara\":\"" + item.AutorKomentara + "\",");
                    sw.WriteLine("\"FCentar\":" + item.FCentar + ",");
                    sw.WriteLine("\"TekstKomentara\":\"" + item.TekstKomentara + "\",");
                    sw.WriteLine("\"Ocena\":" + item.Ocena + ",");
                    sw.WriteLine("\"Odobren\":" + item.Odobren + ",");
                    sw.WriteLine("\"Id\":" + item.Id + ",");
                    sw.WriteLine("},");
                }
                sw.WriteLine("]");
            }
        }

        public static Komentar DodajKomentar(Komentar k)
        {
            k.Id = GenerateId();
            komentari.Add(k);
            return k;
        }

        public static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }

    }
}