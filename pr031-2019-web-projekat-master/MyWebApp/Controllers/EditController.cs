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
    public class EditController : ApiController
    {
        List<Korisnik> korisnici = new List<Korisnik>();
        
        [HttpPut]
        public IHttpActionResult Put()
        {
            //Registracija.html?KorisnickoIme=martaj&Lozinka=rfwe&Ime=Marta&Prezime=Jovic&PolKorisnika=ŽENSKI&Email=martaj%40gmail.com&DatumRodjenja=2022-08-02
            korisnici = Korisnici.korisnici;
          //  string kime = HttpContext.Current.Request.Params["KorisnickoIme"];
            string lozinka = HttpContext.Current.Request.Params["Lozinka"];
            string ime = HttpContext.Current.Request.Params["Ime"];
            string prezime = HttpContext.Current.Request.Params["Prezime"];
            string pol = HttpContext.Current.Request.Params["PolKorisnika"];
            Pol p;
            if (pol == "Muški")
            {
                p = Pol.Muski;
            }
            else
            {
                p = Pol.Zenski;
            }
            string email = HttpContext.Current.Request.Params["Email"];
            string datum = HttpContext.Current.Request.Params["DatumRodjenja"];
            /*if((lozinka == null && lozinka == "") || (ime == null && ime == "") || (prezime == null && prezime == "") || (email == null && email == "") || (datum == null && datum == ""))
                return BadRequest();*/
            foreach (var item in korisnici)
            {
                if (item.KorisnickoIme == Korisnici.UlogovanKorisnik.KorisnickoIme)
                {
                    //korisnici.Remove(item);
                   // item.KorisnickoIme = kime;
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
           return BadRequest();
        }

        /*[HttpPut]
        public IHttpActionResult Put(string parametri)
        {
            //  parametri = KorisnickoIme + "/" + Lozinka + "/" + Ime + "/" + Prezime + "/" + Email + "/" + DatumRodjenja/id ;
            Korisnik korisnik = new Korisnik();
            korisnik.KorisnickoIme = parametri.Split('/')[0];
            korisnik.Lozinka = parametri.Split('/')[1];
            korisnik.Ime = parametri.Split('/')[2];
            korisnik.Prezime = parametri.Split('/')[3];
            korisnik.Email = parametri.Split('/')[4];
            korisnik.DatumRodjenja = (parametri.Split('/')[5]);
            korisnik.Id = int.Parse(parametri.Split('/')[6]);
            Korisnici.Promeni(korisnik);
            Korisnici.Registracija();
            //KorisniciList.UpisiKorisnike();
           // KorisniciList.UpisiVlasnike();
            //KorisniciList.IsprazniList();
           // KorisniciList.Korisnici();
           // KorisniciList.Vlasnici();

            return Ok();
        }*/
    }
}
