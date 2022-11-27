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
    public class BrisanjeTreningaController : ApiController
    {
        public static List<GrupniTrening> gtreninzi = new List<GrupniTrening>();
        [HttpDelete]
        public bool Delete()
        {
            int idTreninga = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            gtreninzi = GrupniTreninzi.gtreninzi;
            foreach (var item in gtreninzi)
            {
                if(item.Id == idTreninga && item.Posetioci.Count == 0)
                {
                    item.Obrisan = true;
                    GrupniTreninzi.UpisiTreninge();
                    return true;
                }
            }
            return false;
        }
    }
}
