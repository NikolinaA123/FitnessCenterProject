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
    public class OdobriController : ApiController
    {
        public static List<Komentar> komentars = new List<Komentar>();
        public static int idK;
        [HttpPost]
        public void SaveId()
        {
            idK = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            komentars = Komentari.komentari;
            foreach (var item in komentars)
            {
                if (item.FCentar == KomentariTController.idFC && item.Odobren == 0 && idK == item.Id)
                {
                    item.Odobren = 1;
                    Komentari.UpisiKomentare();
                }
            }
        }
    }
}
