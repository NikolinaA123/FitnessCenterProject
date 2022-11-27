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
    public class KreirajTreningController : ApiController
    {
        List<GrupniTrening> treninzi = new List<GrupniTrening>();
        [HttpPost]
        public IHttpActionResult KreirajTrening()
        {
            treninzi.Clear();
            treninzi = GrupniTreninzi.UcitajGTreninge();
            //treninzi = GrupniTreninzi.gtreninzi;
            string naziv = HttpContext.Current.Request.Params["naziv"];
            string opcija = HttpContext.Current.Request.Params["tip"];
            TipTreninga t;
            if (opcija == "Yoga")
                t = TipTreninga.Yoga;
            else if (opcija == "Les Mills Tone")
                t = TipTreninga.LesMillsTone;
            else
                t = TipTreninga.BodyPump;
            int trajanje;
            if (HttpContext.Current.Request.Params["trajanje"] != "" && HttpContext.Current.Request.Params["trajanje"] != null)
                trajanje = int.Parse(HttpContext.Current.Request.Params["trajanje"]);
            else
                trajanje = 0;
            string datumvreme;
            if (HttpContext.Current.Request.Params["datumvreme"] != "" && HttpContext.Current.Request.Params["datumvreme"] != null)
                datumvreme = HttpContext.Current.Request.Params["datumvreme"];
            else
                datumvreme = "";
            DateTime dt = DateTime.ParseExact(datumvreme, "dd/MM/yyyy HH:mm", null);
            if (dt < new DateTime(2022, 9, 4, 0, 0, 0))
                return BadRequest();
            int maxbr;
            if (HttpContext.Current.Request.Params["maxbr"] != "" && HttpContext.Current.Request.Params["maxbr"] != null)
                maxbr = int.Parse(HttpContext.Current.Request.Params["maxbr"]);
            else
                maxbr = 0;
            FitnesCentar fc = new FitnesCentar();
            int idFc = Korisnici.UlogovanKorisnik.FC;
            List<FitnesCentar> fcentri = new List<FitnesCentar>();
            //fcentri = FitnesCentri.fcentri;
            fcentri.Clear();
            fcentri = FitnesCentri.UcitajFCentre();
            foreach (var item in fcentri)
            {
                if (item.Id == idFc)
                    fc = item;
            }
            
            bool exists = false;
            
            foreach (var item in treninzi)
            {
                if (item.Naziv == naziv)
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                GrupniTrening gt = new GrupniTrening(new List<string>(), naziv, t, fc, trajanje, datumvreme, maxbr, GrupniTreninzi.GenerateId());
                treninzi.Add(gt);
                GrupniTreninzi.UpisiTreninge();
                return Ok();
            }
            return BadRequest();
        }
    }
}
