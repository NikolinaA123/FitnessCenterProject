using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class EditFCController : ApiController
    {
        public static int idFC;
        public static FitnesCentar fc = new FitnesCentar();
        List<FitnesCentar> fcentri = new List<FitnesCentar>();
        List<Korisnik> korisnici = new List<Korisnik>();
        [HttpPost]
        public void SaveIdFC()
        {
            idFC = Int32.Parse(HttpContext.Current.Request.Params["value"]);
        }
        [HttpGet]
        public FitnesCentar FC()
        {
            int fcID = 0;
            fcID = idFC;
            fcentri = FitnesCentri.fcentri; 

            foreach (var item in fcentri)
            {
                if(item.Id == fcID)
                {
                    fc = item;
                }
            }
            return fc;
        }
        public static bool useRegex(String input)
        {
           // Regex r = new Regex("[A-Z][a-z]");
            Regex regex = new Regex(@"^[A-Za-z\s]+\s+[0-9]+,[A-Za-z\s]+\s+[0-9]+$", RegexOptions.IgnoreCase);
            return regex.IsMatch(input);
        }
        [HttpPut]
         public bool Editovanje()
         {
             fcentri = FitnesCentri.fcentri;
             korisnici = Korisnici.korisnici;
             string naziv = HttpContext.Current.Request.Params["naziv"];
             string adresa = HttpContext.Current.Request.Params["adresa"];
             int godina = int.Parse(HttpContext.Current.Request.Params["godina"]);
             int mesecna = int.Parse(HttpContext.Current.Request.Params["mesecna"]);
             int godisnja = int.Parse(HttpContext.Current.Request.Params["godisnja"]);
             int trening = int.Parse(HttpContext.Current.Request.Params["trening"]);
             int grupni = int.Parse(HttpContext.Current.Request.Params["grupni"]);
             int personalni = int.Parse(HttpContext.Current.Request.Params["personalni"]);

             //string reg = @"^[A-Za-z\s]+\s+[0-9]+,[A-Za-z\s]+\s+[0-9]+$";
             foreach (var item in fcentri)
             {
                 if(item.Id == idFC)
                 {
                     item.Naziv = naziv;
                     if (useRegex(adresa))
                         item.Adresa = adresa;
                     else
                         return false;
                     item.GodinaOtvaranja = godina;
                     item.CenaMesecneClanarine = mesecna;
                     item.CenaGodisnjeClanarine = godisnja;
                     item.CenaTreninga = trening;
                     item.CenaGrupnogTreninga = grupni;
                     item.CenaPersonalnogTreninga = personalni;
                     FitnesCentri.UpisiFC();
                     return true;
                 }
             }


             return false;
         }
    }
}
