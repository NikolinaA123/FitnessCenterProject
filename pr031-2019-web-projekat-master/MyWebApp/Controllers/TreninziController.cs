using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class TreninziController : ApiController
    {
        public static List<GrupniTrening> gtreninzi = new List<GrupniTrening>();
        [HttpGet]
        public List<GrupniTrening> Get()
        {
            List<GrupniTrening> ret = new List<GrupniTrening>();
            gtreninzi = GrupniTreninzi.gtreninzi;
            foreach (var item in gtreninzi)
            {
                string datum = item.DatumVreme;
                DateTime dt = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", null);
                if (dt > DateTime.Now && item.Obrisan == false && item.FCentar.Id == DetailsController.idFCenter)
                    ret.Add(item);
            }
            return ret;
        }

    }
}
