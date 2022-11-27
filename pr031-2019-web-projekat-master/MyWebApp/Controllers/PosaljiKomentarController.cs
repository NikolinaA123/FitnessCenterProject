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
    public class PosaljiKomentarController : ApiController
    {
        List<Komentar> komentari = new List<Komentar>();
        List<FitnesCentar> fcentri = new List<FitnesCentar>();
        List<GrupniTrening> gtreninzi = new List<GrupniTrening>();
        public static int idTreninga;
        public static int idFCentra;
        [HttpPost]
        public IHttpActionResult Komentarisi()
        {
            //int idFCentra = DetailsController.idFCenter;
            //int idTreninga = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            
            komentari = Komentari.komentari;
            fcentri = FitnesCentri.fcentri;
            gtreninzi = GrupniTreninzi.gtreninzi;
            foreach (var item in gtreninzi)
            {
                if (idTreninga == item.Id)
                    idFCentra = item.FCentar.Id;
            }
            string tekstKomentara = HttpContext.Current.Request.Params["tekstKomentara"];
            string ocenaInput = HttpContext.Current.Request.Params["ocena"];
            int ocena;
            if (ocenaInput == "1")
                ocena = 1;
            else if (ocenaInput == "2")
                ocena = 2;
            else if (ocenaInput == "3")
                ocena = 3;
            else if (ocenaInput == "4")
                ocena = 4;
            else
                ocena = 5;
            // ID FCENTRA
            Komentar k = new Komentar(Korisnici.UlogovanKorisnik.KorisnickoIme, idFCentra, tekstKomentara, ocena, 0, Komentari.GenerateId());
            komentari.Add(k);
            Komentari.UpisiKomentare();
            return Ok();
        }
        [HttpGet]
        public int IDT()
        {
            idTreninga = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            return idTreninga;
        }
    }
}
