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
    public class PosetiociController : ApiController
    {
        public static List<GrupniTrening> gtreninzi = new List<GrupniTrening>();
        public static List<Korisnik> korisnici = new List<Korisnik>();
        public static List<Korisnik> retlist = new List<Korisnik>();
        public static int idTreninga;
        [HttpGet]
        public List<Korisnik> Posetioci()
        {
            idTreninga = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            gtreninzi = GrupniTreninzi.gtreninzi;
            korisnici = Korisnici.korisnici;
            foreach (var item in gtreninzi)
            {
                if (item.Id == idTreninga)
                {
                    
                    foreach (var p in item.Posetioci)
                    {
                        foreach (var kor in korisnici)
                        {
                            if(p == kor.KorisnickoIme)
                            {
                                Korisnik k = new Korisnik();
                                k.KorisnickoIme = p;
                                k.Ime = kor.Ime;
                                k.Prezime = kor.Prezime;
                                k.Lozinka = kor.Lozinka;
                                k.Id = kor.Id;
                                k.Obrisan = kor.Obrisan;
                                k.PolKorisnika = kor.PolKorisnika;
                                k.Uloga = kor.Uloga;
                                k.Ulogovan = kor.Ulogovan;
                                retlist.Add(k);
                            }
                        }
                    }
                }
            }
            return retlist;
        }
    }
}
