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
    public class EditTreningController : ApiController
    {
        List<GrupniTrening> treninzi = new List<GrupniTrening>();
        [HttpPut]
        public void Izmena()
        {
            treninzi = GrupniTreninzi.gtreninzi;
            string naziv = HttpContext.Current.Request.Params["Naziv"];
            string Trajanje = HttpContext.Current.Request.Params["Trajanje"];
            string DatumVreme = HttpContext.Current.Request.Params["DatumVreme"];
            string MaksimalanBrPosetilaca = HttpContext.Current.Request.Params["MaksimalanBrPosetilaca"];
            /*/string pol = HttpContext.Current.Request.Params["PolKorisnika"];
            Pol p;
            if (pol == "Muški")
            {
                p = Pol.Muski;
            }
            else
            {
                p = Pol.Zenski;
            }*/
           
           /* foreach (var item in treninzi)
            {
                if (item.KorisnickoIme == Korisnici.UlogovanKorisnik.KorisnickoIme)
                {
                    //korisnici.Remove(item);
                    item.KorisnickoIme = kime;
                    item.Ime = ime;
                    item.Prezime = prezime;
                    item.PolKorisnika = p;
                    item.Email = email;
                    item.DatumRodjenja = datum;
                    korisnici.Add(item);
                    Korisnici.Registracija();
                    return Ok();
                }
            }
            return BadRequest();*/
        }
    }
}
