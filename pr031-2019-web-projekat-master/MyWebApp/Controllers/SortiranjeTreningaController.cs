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
    public class SortiranjeTreningaController : ApiController
    {
        public static List<GrupniTrening> treninzi = new List<GrupniTrening>();
        [HttpPost]
        public List<GrupniTrening> Sortiranje()
        {
            string opcija = HttpContext.Current.Request.Params["sortSelect"];
            //List<FitnesCentar> retlist = new List<FitnesCentar>();
            List<GrupniTrening> temp = new List<GrupniTrening>();
            treninzi = GrupniTreninzi.gtreninzi;
            foreach (var item in treninzi)
            {
                string datum = item.DatumVreme;
                DateTime dt = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", null);
                if (dt < DateTime.Now && item.Obrisan == false)
                    temp.Add(item);
            }

            if (opcija == "Naziv")
            {
                if (HttpContext.Current.Request.Params["rb"] == "rastuce")
                {
                    temp.Sort((x, y) => string.Compare(x.Naziv, y.Naziv));
                }
                else
                {
                    temp.Sort((x, y) => string.Compare(y.Naziv, x.Naziv));
                }
            }
            else if (opcija == "Tip treninga")
            {
                if (HttpContext.Current.Request.Params["rb"] == "rastuce")
                {
                    temp.Sort((x, y) => string.Compare(x.Tip.ToString(), y.Tip.ToString()));
                }
                else
                {
                    temp.Sort((x, y) => string.Compare(y.Tip.ToString(), x.Tip.ToString()));
                }
            }
            else
            {
                if (HttpContext.Current.Request.Params["rb"] == "rastuce")
                {
                    //temp.Sort((x, y) => x.DatumVreme.CompareTo(y.DatumVreme));
                    temp.Sort((x, y) => string.Compare(x.DatumVreme, y.DatumVreme));
                }
                else
                {
                    // temp.Sort((x, y) => y.DatumVreme.CompareTo(x.DatumVreme));
                    temp.Sort((x, y) => string.Compare(y.DatumVreme, x.DatumVreme));
                }
            }

            return temp;
        }
    }
}
