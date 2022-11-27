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
    public class PretragaTreningaController : ApiController
    {
        public static List<GrupniTrening> treninzi = new List<GrupniTrening>();
        [HttpPost]
        public List<GrupniTrening> Pretrazi()
        {
            string opcija = HttpContext.Current.Request.Params["pretragaSelect"];


            List<GrupniTrening> retlist = new List<GrupniTrening>();
            List<GrupniTrening> temp = new List<GrupniTrening>();
            treninzi = GrupniTreninzi.gtreninzi;

            foreach (var item in treninzi)
            {
                string datum = item.DatumVreme;
                DateTime dt = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", null);
                if (dt < DateTime.Now && item.Obrisan == false)
                    temp.Add(item);
            }


            if (opcija == "Nazivu")
            {
                string inputText = HttpContext.Current.Request.Params["pretragaInput"];
                string lower = inputText.ToLower();
                foreach (var item in temp)
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
                
                foreach (var item in temp)
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
            else if (opcija == "Fitnes centru")
            {
                string inputText = HttpContext.Current.Request.Params["pretragaInput"];
                string lower = inputText.ToLower();
                foreach (var item in temp)
                {
                    if (lower == item.FCentar.Naziv.ToLower())
                    {
                        retlist.Add(item);
                    }
                }
            }
            return retlist;
        }
    }
}
