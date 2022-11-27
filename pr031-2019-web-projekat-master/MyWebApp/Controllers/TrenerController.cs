using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class TrenerController : ApiController
    {
        public static int idCentra;
        public static List<GrupniTrening> gtreninzi = new List<GrupniTrening>();
        public static List<int> treninzi = new List<int>();
        public static List<Korisnik> korisnici = new List<Korisnik>();
        [HttpGet]
        public List<GrupniTrening> Get()
        {
            //int idFC = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            //idCentra = idFC;
            List<GrupniTrening> ret = new List<GrupniTrening>();
            ret.Clear();
            korisnici.Clear();
            korisnici = Korisnici.UcitajKorisnike();
            gtreninzi.Clear();
            gtreninzi = GrupniTreninzi.UcitajGTreninge();
            //korisnici = Korisnici.korisnici;
            //gtreninzi = GrupniTreninzi.gtreninzi;
            foreach (var item in korisnici)
            {
                if(Korisnici.UlogovanKorisnik.KorisnickoIme == item.KorisnickoIme)
                {
                    foreach (var t in item.grupniTreninzi)
                    {
                        treninzi.Add(t);
                    }
                    foreach (var gt in gtreninzi)
                    {
                        foreach (var id in treninzi)
                        {   //  item.FC == gt.FCentar.Id da bi bio bas taj fitnes centar u kom je zaposlen
                            string datum = gt.DatumVreme;
                            DateTime dt = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", null);
                            if (gt.Id == id && item.FC == gt.FCentar.Id && dt < DateTime.Now && gt.Obrisan == false)
                                ret.Add(gt);
                        }
                    }
                }
            }
            return ret;
        }
    }
}
