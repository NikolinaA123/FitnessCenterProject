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
    public class PoseceniTreninziController : ApiController
    {
        public static int idCentra;
        public static List<GrupniTrening> gtreninzi = new List<GrupniTrening>();
        [HttpGet]
        public List<GrupniTrening> Get()
        {
            //int idFC = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            //idCentra = idFC;
            List<GrupniTrening> ret = new List<GrupniTrening>();
            gtreninzi.Clear();
            gtreninzi = GrupniTreninzi.UcitajGTreninge();
          //  gtreninzi = GrupniTreninzi.gtreninzi;
            foreach (var item in gtreninzi)
            {
                string datum = item.DatumVreme;
                DateTime dt = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", null);
                if (dt < DateTime.Now && item.Obrisan == false)
                    ret.Add(item);
            }
            return ret;
        }
    }
}
