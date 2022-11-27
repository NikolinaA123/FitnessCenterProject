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
    public class PretragaTreningaMixController : ApiController
    {
        public static List<GrupniTrening> treninzi = new List<GrupniTrening>();
        [HttpPost]
        public List<GrupniTrening> Miks()
        {
            string Naziv = HttpContext.Current.Request.Params["Naziv"] != null ? HttpContext.Current.Request.Params["Naziv"] : String.Empty;
            string toLowerNaziv = Naziv.ToLower();
            string tiptreninga = HttpContext.Current.Request.Params["tiptreninga"] != null ? HttpContext.Current.Request.Params["tiptreninga"] : String.Empty;
            string toLowertiptreninga = tiptreninga.ToLower();
            string fitnescentar = HttpContext.Current.Request.Params["fitnescentar"] != null ? HttpContext.Current.Request.Params["fitnescentar"] : String.Empty;
            string toLowerFC = fitnescentar.ToLower();
            List<GrupniTrening> retNaziv = new List<GrupniTrening>();
            List<GrupniTrening> retTip = new List<GrupniTrening>();
            List<GrupniTrening> retFC = new List<GrupniTrening>();
            List<GrupniTrening> retlist1 = new List<GrupniTrening>();
            List<GrupniTrening> retlist = new List<GrupniTrening>();
            List<GrupniTrening> temp = new List<GrupniTrening>();
            //treninzi = GrupniTreninzi.gtreninzi;
            treninzi.Clear();
            treninzi = GrupniTreninzi.UcitajGTreninge();
            foreach (var item in treninzi)
            {
                string datum = item.DatumVreme;
                DateTime dt = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", null);
                if (dt < DateTime.Now && item.Obrisan == false)
                    temp.Add(item);
            }
            string tipTr;
            
            if (toLowerNaziv != "" && toLowerNaziv != null)
                retNaziv = temp.FindAll(item => item.Naziv.ToLower() == toLowerNaziv);
            
            if (toLowertiptreninga != "" && toLowertiptreninga != null)
            {
                foreach (var item in temp)
                {
                    if (item.Tip == TipTreninga.BodyPump)
                        tipTr = "BODY PUMP";
                    else if (item.Tip == TipTreninga.LesMillsTone)
                        tipTr = "LES MILLS TONE";
                    else
                        tipTr = "YOGA";
                    if (tipTr.ToLower() == toLowertiptreninga)
                        retTip.Add(item);
                }
            }
            if (toLowerFC != "" && toLowerFC != null)
                retFC = temp.FindAll(item => item.FCentar.Naziv.ToLower() == toLowerFC );

            //presek
            if(toLowerNaziv != "" && toLowerNaziv != null && toLowertiptreninga != "" && toLowertiptreninga != null && toLowerFC != "" && toLowerFC != null)
            {
                retlist1 = retNaziv.Intersect(retTip).ToList();
                retlist = retlist1.Intersect(retFC).ToList();
            }
            else if(toLowerNaziv != "" && toLowerNaziv != null && toLowertiptreninga != "" && toLowertiptreninga != null && (toLowerFC == "" || toLowerFC == null))
            {
                retlist = retNaziv.Intersect(retTip).ToList();
            }
            else if (toLowerNaziv != "" && toLowerNaziv != null && toLowerFC != "" && toLowerFC != null && (toLowertiptreninga == "" || toLowertiptreninga == null))
            {
                retlist = retNaziv.Intersect(retFC).ToList();
            }
            else if (toLowertiptreninga != "" && toLowertiptreninga != null && toLowerFC != "" && toLowerFC != null && (toLowerNaziv == "" || toLowerNaziv == null))
            {
                retlist = retTip.Intersect(retFC).ToList();
            }
            else if(toLowerNaziv != "" && toLowerNaziv != null && (toLowertiptreninga == "" || toLowertiptreninga == null) && (toLowerFC == "" || toLowerFC == null))
            {
                retlist = retNaziv;
            }
            else if(toLowertiptreninga != "" && toLowertiptreninga != null && (toLowerFC == "" || toLowerFC == null) && (toLowerNaziv == "" || toLowerNaziv == null))
            {
                retlist = retTip;
            }
            else if(toLowerFC != "" && toLowerFC != null && (toLowertiptreninga == "" || toLowertiptreninga == null) && (toLowerNaziv == "" || toLowerNaziv == null))
            {
                retlist = retFC;
            }
            return retlist;
        }
    }
}
