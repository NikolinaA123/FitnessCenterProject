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
    public class KomentariTController : ApiController
    {
        public static List<Komentar> komentars = new List<Komentar>();
        public static int idFC;
        public static Komentar k;
        [HttpPost]
        public void SaveIdFC()
        {
            idFC = Int32.Parse(HttpContext.Current.Request.Params["value"]);
        }
        [HttpGet]
        public List<Komentar> Get()
        {
            //idFC = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            komentars.Clear();
            komentars = Komentari.UcitajKomentare();
            List<Komentar> retlist = new List<Komentar>();
            foreach (var item in komentars)
            {
                if (item.FCentar == idFC && item.Odobren == 0)
                {
                    retlist.Add(item);
                }
            }
            return retlist;
        }
    }
}
