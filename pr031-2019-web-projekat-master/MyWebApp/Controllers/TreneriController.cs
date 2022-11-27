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
    public class TreneriController : ApiController
    {
        //public static List<FitnesCentar> fcentri = new List<FitnesCentar>();
        public static List<Korisnik> korisnici = new List<Korisnik>();
        public static int idFC;
        [HttpPost]
        public void SaveIdFC()
        {
            idFC = Int32.Parse(HttpContext.Current.Request.Params["value"]);
        }
        [HttpGet]
        public List<Korisnik> Get()
        {
            //idFC = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            List<Korisnik> ret = new List<Korisnik>();
            //fcentri = FitnesCentri.fcentri;
            korisnici = Korisnici.korisnici;
            foreach (var item in korisnici)
            {
                if(item.FC == idFC && item.Blokiran == false)
                {
                    ret.Add(item);
                }
            }
            return ret;
        }
    }
}
