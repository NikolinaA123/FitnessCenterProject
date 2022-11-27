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
    public class MixTrenerController : ApiController
    {
        public static int idCentra;
        public static List<GrupniTrening> gtreninzi = new List<GrupniTrening>();
        public static List<int> treninziID = new List<int>();
        public static List<Korisnik> korisnici = new List<Korisnik>();
       // public static List<GrupniTrening> treninzi = new List<GrupniTrening>();
        [HttpPost]
        public List<GrupniTrening> Pretrazi()
        {
            string Naziv = HttpContext.Current.Request.Params["Naziv"] != null ? HttpContext.Current.Request.Params["Naziv"] : String.Empty;
            string toLowerNaziv = Naziv.ToLower();
            string tiptreninga = HttpContext.Current.Request.Params["tiptreninga"] != null ? HttpContext.Current.Request.Params["tiptreninga"] : String.Empty;
            string toLowertiptreninga = tiptreninga.ToLower();
            /*string fitnescentar = HttpContext.Current.Request.Params["fitnescentar"] != null ? HttpContext.Current.Request.Params["fitnescentar"] : String.Empty;
            string toLowerFC = fitnescentar.ToLower();*/
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

            string opcija = HttpContext.Current.Request.Params["pretragaSelect"];


            List<GrupniTrening> retlist = new List<GrupniTrening>();


            string tipTr;

            if (toLowerNaziv != "" && toLowerNaziv != null)
                retlist = ret.FindAll(item => item.Naziv.ToLower() == toLowerNaziv);
            if (toLowertiptreninga != "" && toLowertiptreninga != null)
            {
                foreach (var item in ret)
                {
                    if (item.Tip == TipTreninga.BodyPump)
                        tipTr = "BODY PUMP";
                    else if (item.Tip == TipTreninga.LesMillsTone)
                        tipTr = "LES MILLS TONE";
                    else
                        tipTr = "YOGA";
                    if (tipTr.ToLower() == toLowertiptreninga)
                        retlist.Add(item);
                }
            }
            //if (toLowerFC != "" && toLowerFC != null)
              //  retlist = temp.FindAll(item => item.FCentar.Naziv.ToLower() == toLowerFC);
            return retlist;
        }
    }
}
