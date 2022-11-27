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
    public class PretragaTreningaTrenerController : ApiController
    {
        public static int idCentra;
        public static List<GrupniTrening> gtreninzi = new List<GrupniTrening>();
        public static List<int> treninziID = new List<int>();
        public static List<Korisnik> korisnici = new List<Korisnik>();
        public static List<GrupniTrening> treninzi = new List<GrupniTrening>();
        [HttpPost]
        public List<GrupniTrening> Pretrazi()
        {
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
            /*List<GrupniTrening> temp = new List<GrupniTrening>();
            treninzi = GrupniTreninzi.gtreninzi;

            foreach (var item in treninzi)
            {
                string datum = item.DatumVreme;
                DateTime dt = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", null);
                if (dt < DateTime.Now && item.Obrisan == false)
                    temp.Add(item);
            }*/


            if (opcija == "Nazivu")
            {
                string inputText = HttpContext.Current.Request.Params["pretragaInput"];
                string lower = inputText.ToLower();
                foreach (var item in ret)
                {
                    if (lower == item.Naziv.ToLower())
                    {
                        retlist.Add(item);
                    }
                }
            }
            else if (opcija == "Tipu treninga")
            {
                string inputText = HttpContext.Current.Request.Params["pretragaInput"];
                string lower = inputText.ToLower();
                string tipTr;

                foreach (var item in ret)
                {
                    if (item.Tip == TipTreninga.BodyPump)
                        tipTr = "BODY PUMP";
                    else if (item.Tip == TipTreninga.LesMillsTone)
                        tipTr = "LES MILLS TONE";
                    else
                        tipTr = "YOGA";
                    if (lower == tipTr.ToLower())
                    {
                        retlist.Add(item);
                    }
                }
            }
            else if (opcija == "Datumu i vremenu")
            {
               /* string inputText = HttpContext.Current.Request.Params["pretragaInput"];
                string lower = inputText.ToLower();
                foreach (var item in temp)
                {
                    if (lower == item.FCentar.Naziv.ToLower())
                    {
                        retlist.Add(item);
                    }
                }*/
            }
            return retlist;
        }
    }
}
