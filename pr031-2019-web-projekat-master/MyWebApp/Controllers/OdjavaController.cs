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
    public class OdjavaController : ApiController
    {
        List<Korisnik> korisnici = new List<Korisnik>();
        [HttpPost]
        public void LogOut()
        {
            Korisnici.LoggedOut();
            /*korisnici = Korisnici.korisnici;
            string kime = HttpContext.Current.Request.Params["korisnickoime"];
            string lozinka = HttpContext.Current.Request.Params["lozinka"];
            return Korisnici.LoggedIn(kime, lozinka);*/
        }
    }
}
