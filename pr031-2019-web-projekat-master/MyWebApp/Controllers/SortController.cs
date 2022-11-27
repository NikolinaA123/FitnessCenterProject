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
    public class SortController : ApiController
    {
        public static List<FitnesCentar> fcentri = new List<FitnesCentar>();
        [HttpPost]
        public List<FitnesCentar> Sortiranje()
        {
            string opcija = HttpContext.Current.Request.Params["sortSelect"];
            //List<FitnesCentar> retlist = new List<FitnesCentar>();
            List<FitnesCentar> temp = new List<FitnesCentar>();
            fcentri.Clear();
            fcentri = FitnesCentri.UcitajFCentre();
            foreach (var item in fcentri)
            {
                if (item.Obrisan == false)
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
            else if (opcija == "Adresa")
            {
                if (HttpContext.Current.Request.Params["rb"] == "rastuce")
                {
                    temp.Sort((x, y) => string.Compare(x.Adresa, y.Adresa));
                }
                else
                {
                    temp.Sort((x, y) => string.Compare(y.Adresa, x.Adresa));
                }
            }
            else
            {
                if (HttpContext.Current.Request.Params["rb"] == "rastuce")
                {
                    temp.Sort((x, y) => x.GodinaOtvaranja.CompareTo(y.GodinaOtvaranja));
                }
                else
                {
                    temp.Sort((x, y) => y.GodinaOtvaranja.CompareTo(x.GodinaOtvaranja));
                }
            }

            return temp;
        }
    }
}
