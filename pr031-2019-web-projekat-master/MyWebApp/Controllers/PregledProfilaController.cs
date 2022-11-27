using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class PregledProfilaController : ApiController
    {
        //ulogovan korisnik
        Korisnik ulogovan;
        [HttpGet]
        public Korisnik UlogovanKorisnik()
        {
            ulogovan = Korisnici.UlogovanKorisnik;
            return ulogovan;
        }
    }
}
