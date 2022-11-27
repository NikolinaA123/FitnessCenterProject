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
    public class LoginController : ApiController
    {
        List<Korisnik> korisnici = new List<Korisnik>();
        

        /*[HttpGet]
        public Korisnik RetKorisnik()
        {

            return k;
        }*/

        [HttpGet]
        public Korisnik LogIn()
        {
            korisnici = Korisnici.korisnici;
            string kime = HttpContext.Current.Request.Params["korisnickoime"];
            string lozinka = HttpContext.Current.Request.Params["lozinka"];
            return Korisnici.LoggedIn(kime, lozinka);
        }
    }
}
