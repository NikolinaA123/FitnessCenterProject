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
    public class PregledTreningaController : ApiController
    {
        public static List<GrupniTrening> grupniTrenings = new List<GrupniTrening>();
        public static int idGTrening;
        public static GrupniTrening gt;
        [HttpPost]
        public void SaveId()
        {
            idGTrening = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            
        }

        [HttpGet]
        public GrupniTrening DetailsGT()
        {
            int id = 0;
            id = idGTrening;
            grupniTrenings.Clear();
            grupniTrenings = GrupniTreninzi.UcitajGTreninge();
            foreach (var item in grupniTrenings)
            {
                if (item.Id == idGTrening)
                    gt = item;
            }
            return gt;
        }
        [HttpPut]
        public bool Editovanje()
        {
            grupniTrenings.Clear();
            grupniTrenings = GrupniTreninzi.UcitajGTreninge();
            string naziv = HttpContext.Current.Request.Params["Naziv"];
            int trajanje =int.Parse(HttpContext.Current.Request.Params["Trajanje"]);
            string DatumVreme = HttpContext.Current.Request.Params["DatumVreme"];
            int MaksimalanBrPosetilaca = int.Parse(HttpContext.Current.Request.Params["MaksimalanBrPosetilaca"]);
            string tip = HttpContext.Current.Request.Params["tip"];

            foreach (var item in grupniTrenings)
            {
                if (item.Id == idGTrening)
                {
                    item.Naziv = naziv;
                    item.Trajanje = trajanje;
                    item.DatumVreme = DatumVreme;
                    item.MaksimalanBrPosetilaca = MaksimalanBrPosetilaca;
                    if (tip == "YOGA")
                        item.Tip = TipTreninga.Yoga;
                    else if (tip == "LES MILLS TONE")
                        item.Tip = TipTreninga.LesMillsTone;
                    else
                        item.Tip = TipTreninga.BodyPump;
                    GrupniTreninzi.UpisiTreninge();
                    return true;
                }
            }


            return false;
        }
    }
}
