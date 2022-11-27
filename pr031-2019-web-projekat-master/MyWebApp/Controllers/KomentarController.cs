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
    public class KomentarController : ApiController
    {
        public static List<Komentar> komentars = new List<Komentar>();
        public static int idFC;
        public static Komentar k;
    
        [HttpGet]
        public List<Komentar> Get()
        {

            komentars.Clear();
            komentars = Komentari.UcitajKomentare();
            List<Komentar> retlist = new List<Komentar>();
            foreach (var item in komentars)
            {
                if (item.FCentar == DetailsController.idFCenter && item.Odobren == 1)
                {
                    retlist.Add(item);
                }
            }
            return retlist;
        }
    }
}
