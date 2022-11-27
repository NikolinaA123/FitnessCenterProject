using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class GrupniTreninzi
    {
        public static List<GrupniTrening> gtreninzi { get; set; } = new List<GrupniTrening>();

        public static List<GrupniTrening> UcitajGTreninge()
        {
            gtreninzi.Clear();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamReader r = new StreamReader(path + "grupnitreninzi.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);
                foreach (var item in items)
                {
                    gtreninzi.Add(item);
                }
            }
            return gtreninzi;
        }

        public static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }



        public static void UpisiTreninge()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            using (StreamWriter sw = new StreamWriter(path + "grupnitreninzi.json", append: false))
            {
                sw.WriteLine("[");
                var items = gtreninzi;
                foreach (var item in items)
                {
                    //if (item.Uloga != UlogaKorisnika.Vlasnik)
                    //{
                    sw.WriteLine("{");
                    sw.WriteLine("\"Naziv\":\"" + item.Naziv + "\",");
                    if(item.Tip == TipTreninga.Yoga)
                        sw.WriteLine("\"Tip\":" + 0 + ",");
                    else if (item.Tip == TipTreninga.LesMillsTone)
                        sw.WriteLine("\"Tip\":" + 1 + ",");
                    else
                        sw.WriteLine("\"Tip\":" + 2 + ",");
                    sw.WriteLine("\"FCentar\":{");
                    sw.WriteLine("\"Naziv\":\"" + item.FCentar.Naziv + "\",");
                    sw.WriteLine("\"Adresa\":\"" + item.FCentar.Adresa + "\",");
                    sw.WriteLine("\"GodinaOtvaranja\":" + item.FCentar.GodinaOtvaranja + ",");
                    sw.WriteLine("\"Vlasnik\":\"" + item.FCentar.Vlasnik + "\",");
                    sw.WriteLine("\"CenaMesecneClanarine\":" + item.FCentar.CenaMesecneClanarine + ",");
                    sw.WriteLine("\"CenaGodisnjeClanarine\":" + item.FCentar.CenaGodisnjeClanarine + ",");
                    sw.WriteLine("\"CenaTreninga\":" + item.FCentar.CenaTreninga + ",");
                    sw.WriteLine("\"CenaGrupnogTreninga\":" + item.FCentar.CenaGrupnogTreninga + ",");
                    sw.WriteLine("\"CenaPersonalnogTreninga\":" + item.FCentar.CenaPersonalnogTreninga + ",");
                    sw.WriteLine("\"Id\":" + item.FCentar.Id + ",");
                   // sw.WriteLine("\"Id\":" + item.Id + ",");
                    if (item.FCentar.Obrisan == false)
                        sw.WriteLine("\"Obrisan\":" + "false" + ",");
                    else
                        sw.WriteLine("\"Obrisan\":" + "true" + ",");
                    sw.WriteLine("},");
                    sw.WriteLine("\"Trajanje\":\"" + item.Trajanje + "\",");
                    sw.WriteLine("\"DatumVreme\":" + JsonConvert.SerializeObject(item.DatumVreme) + ",");
                    sw.WriteLine("\"MaksimalanBrPosetilaca\":" + item.MaksimalanBrPosetilaca + ",");
                    //posetioci
                    sw.WriteLine("\"Posetioci\":[");
                    foreach (var t in item.Posetioci)
                    {
                        sw.Write("\""+t+ "\"" + ",");
                    }
                   
                    sw.WriteLine("],");
                    sw.WriteLine("\"Id\":" + item.Id + ",");
                    if (item.Obrisan == false)
                        sw.WriteLine("\"Obrisan\":" + "false" + ",");
                    else
                        sw.WriteLine("\"Obrisan\":" + "true" + ",");
                    
                    sw.WriteLine("},");
                    // }
                }
                sw.WriteLine("]");
            }
        }

    }
}