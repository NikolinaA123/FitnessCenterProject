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
    public class DodajFCController : ApiController
    {
        List<FitnesCentar> fcentri = new List<FitnesCentar>();
        List<Korisnik> korisnici = new List<Korisnik>();
        [HttpPost]
        public IHttpActionResult Registracija()
        {
            fcentri = FitnesCentri.fcentri;
            korisnici = Korisnici.korisnici;
            string naziv = HttpContext.Current.Request.Params["naziv"];
            string ulica = HttpContext.Current.Request.Params["ulica"];
            string broj = HttpContext.Current.Request.Params["broj"];
            string grad = HttpContext.Current.Request.Params["grad"];
            string pbroj = HttpContext.Current.Request.Params["pbroj"];
            int godina = int.Parse(HttpContext.Current.Request.Params["godina"]);
            int mesecna = int.Parse(HttpContext.Current.Request.Params["mesecna"]);
            int godisnja = int.Parse(HttpContext.Current.Request.Params["godisnja"]);
            int trening = int.Parse(HttpContext.Current.Request.Params["trening"]);
            int grupni = int.Parse(HttpContext.Current.Request.Params["grupni"]);
            int personalni = int.Parse(HttpContext.Current.Request.Params["personalni"]);
            string adresa = ulica + " " + broj + "," + grad + " " + pbroj;
            
            bool exists = false;
        
            foreach (var item in fcentri)
            {
                if (item.Adresa == adresa)
                {
                    exists = true;
                }
            }
            Korisnik k = new Korisnik();
            // vlasnik
            foreach (var item in korisnici)
            {
                if (Korisnici.UlogovanKorisnik.KorisnickoIme == item.KorisnickoIme)
                    k = item;
            }

            if (exists == false)
            {
                FitnesCentar f = new FitnesCentar(naziv, adresa, godina, k.KorisnickoIme, mesecna, godisnja, trening, grupni, personalni, FitnesCentri.GenerateId());
                fcentri.Add(f);
                // dodavanje fitnes centra vlasniku
                foreach (var item in korisnici)
                {
                    if (k.KorisnickoIme == item.KorisnickoIme)
                    {
                        item.fitnesCentri.Add(f.Id);
                        Korisnici.Registracija();
                    }
                        
                }
                FitnesCentri.UpisiFC();
              
                return Ok();
            }
            return BadRequest();
        }

    }
}
