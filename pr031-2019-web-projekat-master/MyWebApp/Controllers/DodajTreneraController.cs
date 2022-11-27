﻿using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class DodajTreneraController : ApiController
    {
        public static int idFC;
        List<Korisnik> korisnici = new List<Korisnik>();
        [HttpPost]
        public IHttpActionResult Registracija()
        {
            //Registracija.html?KorisnickoIme=martaj&Lozinka=rfwe&Ime=Marta&Prezime=Jovic&PolKorisnika=ŽENSKI&Email=martaj%40gmail.com&DatumRodjenja=2022-08-02
            korisnici = Korisnici.korisnici;
            string kime = HttpContext.Current.Request.Params["KorisnickoIme"];
            string lozinka = HttpContext.Current.Request.Params["Lozinka"];
            string ime = HttpContext.Current.Request.Params["Ime"];
            string prezime = HttpContext.Current.Request.Params["Prezime"];
            string pol = HttpContext.Current.Request.Params["PolKorisnika"];
            Pol p;
            if (pol == "MUŠKI")
            {
                p = Pol.Muski;
            }
            else
            {
                p = Pol.Zenski;
            }
            string email = HttpContext.Current.Request.Params["Email"];
            string datum = HttpContext.Current.Request.Params["DatumRodjenja"];
            bool exists = false;
            foreach (var item in korisnici)
            {
                if (item.KorisnickoIme == kime)
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                Korisnik k = new Korisnik(kime, lozinka, ime, prezime, p, email, datum, UlogaKorisnika.Trener, Korisnici.GenerateId());
                k.FC = idFC;
                k.Blokiran = false;
                k.grupniTreninzi = new List<int>();
                k.fitnesCentri = new List<int>();
                korisnici.Add(k);
                Korisnici.RegistracijaTrenera();
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public int ID()
        {
            idFC = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            return idFC;
        }
    }
}
