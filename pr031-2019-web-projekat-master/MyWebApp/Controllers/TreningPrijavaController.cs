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
    public class TreningPrijavaController : ApiController
    {
        List<GrupniTrening> treninzi = new List<GrupniTrening>();
        [HttpPost]
        public bool Prijava()
        { // ako je max br prijavljenih
            treninzi = GrupniTreninzi.gtreninzi;
            int idTreninga = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            foreach (var item in treninzi)
            {
                if(idTreninga == item.Id)
                {
                   if(!item.Posetioci.Contains(Korisnici.UlogovanKorisnik.KorisnickoIme) && item.Posetioci.Count < item.MaksimalanBrPosetilaca)
                    {
                        item.Posetioci.Add(Korisnici.UlogovanKorisnik.KorisnickoIme);
                        Korisnici.UlogovanKorisnik.grupniTreninzi.Add(idTreninga);
                        GrupniTreninzi.UpisiTreninge();
                        Korisnici.Registracija();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
