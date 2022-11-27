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
    public class SortTrenerController : ApiController
    {
        public static int idCentra;
        public static List<GrupniTrening> gtreninzi = new List<GrupniTrening>();
        public static List<int> treninziID = new List<int>();
        //public static List<GrupniTrening> treninzi = new List<GrupniTrening>();
        public static List<Korisnik> korisnici = new List<Korisnik>();
        [HttpPost]
        public List<GrupniTrening> Sortiranje()
        {
            string opcija = HttpContext.Current.Request.Params["sortSelect"];
            //List<FitnesCentar> retlist = new List<FitnesCentar>();
            List<GrupniTrening> ret = new List<GrupniTrening>();
            korisnici = Korisnici.korisnici;
            gtreninzi = GrupniTreninzi.gtreninzi;
            foreach (var item in korisnici)
            {
                if (Korisnici.UlogovanKorisnik.KorisnickoIme == item.KorisnickoIme)
                {
                    foreach (var t in item.grupniTreninzi)
                    {
                        treninziID.Add(t);
                    }
                    foreach (var gt in gtreninzi)
                    {
                        foreach (var id in treninziID)
                        {   //  item.FC == gt.FCentar.Id da bi bio bas taj fitnes centar u kom je zaposlen
                            string datum = gt.DatumVreme;
                            DateTime dt = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", null);
                            if (gt.Id == id && item.FC == gt.FCentar.Id && dt < DateTime.Now && gt.Obrisan == false)
                                ret.Add(gt);
                        }
                    }
                }
            }

            if (opcija == "Naziv")
            {
                if (HttpContext.Current.Request.Params["rb"] == "rastuce")
                {
                    ret.Sort((x, y) => string.Compare(x.Naziv, y.Naziv));
                }
                else
                {
                    ret.Sort((x, y) => string.Compare(y.Naziv, x.Naziv));
                }
            }
            else if (opcija == "Tip treninga")
            {
                if (HttpContext.Current.Request.Params["rb"] == "rastuce")
                {
                    ret.Sort((x, y) => string.Compare(x.Tip.ToString(), y.Tip.ToString()));
                }
                else
                {
                    ret.Sort((x, y) => string.Compare(y.Tip.ToString(), x.Tip.ToString()));
                }
            }
            else
            {
                if (HttpContext.Current.Request.Params["rb"] == "rastuce")
                {
                    //temp.Sort((x, y) => x.DatumVreme.CompareTo(y.DatumVreme));
                    ret.Sort((x, y) => string.Compare(x.DatumVreme, y.DatumVreme));
                }
                else
                {
                    // temp.Sort((x, y) => y.DatumVreme.CompareTo(x.DatumVreme));
                    ret.Sort((x, y) => string.Compare(y.DatumVreme, x.DatumVreme));
                }
            }

            return ret;
        }
    }
}
