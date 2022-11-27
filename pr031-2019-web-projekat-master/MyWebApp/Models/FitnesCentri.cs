using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class FitnesCentri
    {
        public static List<FitnesCentar> fcentri { get; set; } = new List<FitnesCentar>();
        public static int IdFCentra = 0;

        public static List<FitnesCentar> UcitajFCentre()
        {
            fcentri.Clear();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamReader r = new StreamReader(path + "fitnescentri.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);
                foreach (var item in items)
                {
                    fcentri.Add(item);
                }
            }
            return fcentri;
        }
        public static void UpisiFC()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            using (StreamWriter sw = new StreamWriter(path + "fitnescentri.json", append: false))
            {
                sw.WriteLine("[");
                var items = fcentri;
                foreach (var item in items)
                {
                    sw.WriteLine("{");
                    sw.WriteLine("\"Naziv\":\"" + item.Naziv + "\",");
                    sw.WriteLine("\"Adresa\":\"" + item.Adresa + "\",");
                    sw.WriteLine("\"GodinaOtvaranja\":" + item.GodinaOtvaranja + ",");
                    sw.WriteLine("\"Vlasnik\":\"" + item.Vlasnik + "\",");
                    sw.WriteLine("\"CenaMesecneClanarine\":" + item.CenaMesecneClanarine + ",");
                    sw.WriteLine("\"CenaGodisnjeClanarine\":" + item.CenaGodisnjeClanarine + ",");
                    sw.WriteLine("\"CenaTreninga\":" + item.CenaTreninga + ",");
                    sw.WriteLine("\"CenaGrupnogTreninga\":" + item.CenaGrupnogTreninga + ",");
                    sw.WriteLine("\"CenaPersonalnogTreninga\":" + item.CenaPersonalnogTreninga + ",");
                    sw.WriteLine("\"Id\":" + item.Id + ",");
                    if(item.Obrisan == false)
                        sw.WriteLine("\"Obrisan\":" + "false" + ",");
                    else
                        sw.WriteLine("\"Obrisan\":" + "true" + ",");
                    sw.WriteLine("},");
                }
                sw.WriteLine("]");
            }
        }
        public static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }
        /* public static List<FitnesCentar> Pretrazi()
         {
             List<FitnesCentar> filtrirani = new List<FitnesCentar>();
             List<FitnesCentar> svi = FitnesCentri.fcentri;

             return filtrirani;
         }*/

        public static FitnesCentar FindById(string id, List<FitnesCentar> fc)
        {
            foreach (var item in fc)
            {
                if (item.Id == int.Parse(id))
                {
                    return item;
                }
            }
            return null;
        }


    }
}