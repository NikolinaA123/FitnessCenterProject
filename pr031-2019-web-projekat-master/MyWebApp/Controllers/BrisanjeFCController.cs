using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class BrisanjeFCController : ApiController
    {
        public static List<FitnesCentar> fcentri = new List<FitnesCentar>();
        public static List<GrupniTrening> treninzi = new List<GrupniTrening>();
        public static List<GrupniTrening> predstojeciTreninzi = new List<GrupniTrening>();
        public static List<Korisnik> korisnici = new List<Korisnik>();
        [HttpDelete]
        public bool Delete()
        {
            int idFC = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            fcentri = FitnesCentri.fcentri;
            treninzi = GrupniTreninzi.gtreninzi;
            korisnici = Korisnici.korisnici;
            // provera da li ima zakazanih treninga u fitnes centru koji zelimo da obrisemo
            foreach (var item in treninzi)
            {
                string datum = item.DatumVreme;
                DateTime dt = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", null);
                if (item.FCentar.Id == idFC && dt > DateTime.Now)
                {
                    predstojeciTreninzi.Add(item);
                }
            }
            foreach (var item in fcentri)
            {
                if (item.Id == idFC && predstojeciTreninzi.Count == 0)
                {
                    item.Obrisan = true;
                    // blokiranje trenera zaposlenih u FC koji brisemo
                    foreach (var tr in korisnici)
                    {
                        if(tr.FC == idFC && tr.Uloga == UlogaKorisnika.Trener)
                        {
                            tr.Blokiran = true;
                            Korisnici.Registracija();
                        }
                    }
                    //GrupniTreninzi.UpisiTreninge();
                    FitnesCentri.UpisiFC();
                    return true;
                }
            }
            return false;
        }
    }
}
