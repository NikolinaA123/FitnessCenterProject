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
    public class MixController : ApiController
    {
        public static List<FitnesCentar> fcentri = new List<FitnesCentar>();
        [HttpPost]
        public List<FitnesCentar> Miks()
        {
            string Naziv = HttpContext.Current.Request.Params["Naziv"] != null ? HttpContext.Current.Request.Params["Naziv"] : String.Empty;
            string toLowerNaziv = Naziv.ToLower();
            string Adresa = HttpContext.Current.Request.Params["Adresa"] != null ? HttpContext.Current.Request.Params["Adresa"] : String.Empty;
            string toLowerAdresa = Adresa.ToLower();
            int Godina = 0;
            if(HttpContext.Current.Request.Params["Godina"] != null && HttpContext.Current.Request.Params["Godina"] != "")
                Godina = int.Parse(HttpContext.Current.Request.Params["Godina"]);
            List<FitnesCentar> retlist1 = new List<FitnesCentar>();
            List<FitnesCentar> retlist = new List<FitnesCentar>();
            List<FitnesCentar> retNaziv = new List<FitnesCentar>();
            List<FitnesCentar> retAdresa = new List<FitnesCentar>();
            List<FitnesCentar> retGodina = new List<FitnesCentar>();
            List<FitnesCentar> temp = new List<FitnesCentar>();
            fcentri.Clear();
            fcentri = FitnesCentri.UcitajFCentre();
            foreach (var item in fcentri)
            {
                if (item.Obrisan == false)
                    temp.Add(item);
            }
            if (toLowerNaziv != "" && toLowerNaziv != null)
                retNaziv = temp.FindAll(item => item.Naziv.ToLower().Contains(toLowerNaziv));
            if (toLowerAdresa != "" && toLowerAdresa != null)
                retAdresa = temp.FindAll(item => item.Adresa.ToLower().Contains(toLowerAdresa));
            if(HttpContext.Current.Request.Params["Godina"] != "" && HttpContext.Current.Request.Params["Godina"] != null)
                retGodina = temp.FindAll(item => item.GodinaOtvaranja == Godina);
            //presek
            if (toLowerNaziv != "" && toLowerNaziv != null && toLowerAdresa != "" && toLowerAdresa != null && HttpContext.Current.Request.Params["Godina"] != "" && HttpContext.Current.Request.Params["Godina"] != null)
            {
                retlist1 = retNaziv.Intersect(retAdresa).ToList();
                retlist = retlist1.Intersect(retGodina).ToList();
            }
            else if (toLowerNaziv != "" && toLowerNaziv != null && toLowerAdresa != "" && toLowerAdresa != null && (HttpContext.Current.Request.Params["Godina"] == "" || HttpContext.Current.Request.Params["Godina"] == null))
            {
                retlist = retNaziv.Intersect(retAdresa).ToList();
            }
            else if (toLowerNaziv != "" && toLowerNaziv != null && HttpContext.Current.Request.Params["Godina"] != "" && HttpContext.Current.Request.Params["Godina"] != null && (toLowerAdresa == "" || toLowerAdresa == null))
            {
                retlist = retNaziv.Intersect(retGodina).ToList();
            }
            else if (toLowerAdresa != "" && toLowerAdresa != null && HttpContext.Current.Request.Params["Godina"] != "" && HttpContext.Current.Request.Params["Godina"] != null && (toLowerNaziv == "" || toLowerNaziv == null))
            {
                retlist = retAdresa.Intersect(retGodina).ToList();
            }
            else if (toLowerNaziv != "" && toLowerNaziv != null && (toLowerAdresa == "" || toLowerAdresa == null) && (HttpContext.Current.Request.Params["Godina"] == "" || HttpContext.Current.Request.Params["Godina"] == null))
            {
                retlist = retNaziv;
            }
            else if (toLowerAdresa != "" && toLowerAdresa != null && (HttpContext.Current.Request.Params["Godina"] == "" || HttpContext.Current.Request.Params["Godina"] == null) && (toLowerNaziv == "" || toLowerNaziv == null))
            {
                retlist = retAdresa;
            }
            else if (HttpContext.Current.Request.Params["Godina"] != "" && HttpContext.Current.Request.Params["Godina"] != null && (toLowerAdresa == "" || toLowerAdresa == null) && (toLowerNaziv == "" || toLowerNaziv == null))
            {
                retlist = retGodina;
            }
            return retlist;
        }

        /*[HttpPost]
        public List<FitnesCentar> Sortiranje()
        {
            List<FitnesCentar> retlist = new List<FitnesCentar>();
            List<FitnesCentar> temp = new List<FitnesCentar>();
            fcentri = FitnesCentri.fcentri;
            foreach (var item in fcentri)
            {
                if (item.Obrisan == false)
                    temp.Add(item);
            }

            return retlist;
        }*/
    }
}
