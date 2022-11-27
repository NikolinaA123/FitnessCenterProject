using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class UlogovanKorisnikController : ApiController
    {
        public static List<GrupniTrening> gtreninzi = new List<GrupniTrening>();
        [HttpGet]
        public bool Get()
        {
            gtreninzi = GrupniTreninzi.gtreninzi;
            string korIme = Korisnici.KorisnickoIme();
            foreach (var item in gtreninzi)
            {
                if (item.Posetioci.Contains(korIme))
                    return true;
            }
            return false;
        }
    }
}
