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
    public class DetailsController : ApiController
    {
        public static List<FitnesCentar> fcentri = new List<FitnesCentar>();
        public static int idFCenter;
        public static FitnesCentar fc;
        [HttpPost]
        public FitnesCentar Get()
        {
            int idFC = Int32.Parse(HttpContext.Current.Request.Params["value"]);
            idFCenter = idFC;
            //fcentri = FitnesCentri.fcentri;
            fcentri = FitnesCentri.UcitajFCentre();
            FitnesCentar FC = null;
            foreach (var item in fcentri)
            {
                if (item.Id == idFC)
                {
                    FC = new FitnesCentar(item.Naziv, item.Adresa, item.GodinaOtvaranja, item.Vlasnik, item.CenaMesecneClanarine, item.CenaGodisnjeClanarine,
                       item.CenaTreninga, item.CenaGrupnogTreninga, item.CenaPersonalnogTreninga, item.Id);
                }
            }
            fc = FC;
            return FC;
        }
        [HttpGet]
        public FitnesCentar DetailsFC()
        {
            return fc;
        }
    }
}
