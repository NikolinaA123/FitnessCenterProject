using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class OdbijeniController : ApiController
    {
        public static List<Komentar> komentari = new List<Komentar>();
        [HttpGet]
        public List<Komentar> Get()
        {
            List<Komentar> retList = new List<Komentar>();
            komentari = Komentari.komentari;
            foreach (var item in komentari)
            {
                if(item.FCentar == KomentariTController.idFC && item.Odobren == 2)
                {
                    retList.Add(item);
                }
            }

            return retList;
        }
    }
}
