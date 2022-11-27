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
    public class BlokiranjeTreneraController : ApiController
    {
        public static List<Korisnik> korisnici = new List<Korisnik>();
        [HttpDelete]
        public bool Delete()
        {
            int idKorisnika = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            korisnici = Korisnici.korisnici;
            foreach (var item in korisnici)
            {
                if(item.Id == idKorisnika)
                {
                    item.Blokiran = true;
                    Korisnici.Registracija();
                    return true;
                }
            }
            return false;
        }
    }
}
