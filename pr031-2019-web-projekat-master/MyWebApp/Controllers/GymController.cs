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
    public class GymController : ApiController
    {
        public static List<FitnesCentar> fcentri = new List<FitnesCentar>();
        public static List<FitnesCentar> ret = new List<FitnesCentar>();
        [HttpGet]
        public List<FitnesCentar> Get()
        {
            fcentri.Clear();
            fcentri = FitnesCentri.fcentri;
            foreach (var item in fcentri)
            {
                if (item.Obrisan == false)
                    ret.Add(item);
            }
            return ret;
            //return Users.UsersList;
        }

        
        [HttpPost]
        public List<FitnesCentar> Pretrazi()
        {
            string opcija = HttpContext.Current.Request.Params["pretragaSelect"];
            
            
            List<FitnesCentar> retlist = new List<FitnesCentar>();
            List<FitnesCentar> temp = new List<FitnesCentar>();
            // fcentri.Clear();
            // fcentri = FitnesCentri.fcentri;
            fcentri.Clear();
            fcentri = FitnesCentri.UcitajFCentre();
            foreach (var item in fcentri)
            {
                if (item.Obrisan == false)
                    temp.Add(item);
            }

            if(opcija == "Naziv")
            {
                string inputText = HttpContext.Current.Request.Params["pretragaInput"];
                foreach (var item in temp)
                {
                    //if(inputText.ToLower() == item.Naziv.ToLower())
                    if(item.Naziv.ToLower().Contains(inputText.ToLower()))
                    {
                        retlist.Add(item);
                    }
                }
            }else if(opcija == "Godina")
            {
                int minG = int.Parse(HttpContext.Current.Request.Params["minG"]);
                int maxG = int.Parse(HttpContext.Current.Request.Params["maxG"]);
                foreach (var item in temp)
                {
                    if (item.GodinaOtvaranja >= minG && item.GodinaOtvaranja <= maxG)
                    {
                        retlist.Add(item);
                    }
                }
            }else if (opcija == "Adresa")
            {
                string inputText = HttpContext.Current.Request.Params["pretragaInput"];
                foreach (var item in temp)
                {
                    if (item.Adresa.ToLower().Contains(inputText.ToLower()))
                    {
                        retlist.Add(item);
                    }
                }
            }
            return retlist;
        }
        /*[HttpPost]
        public List<FitnesCentar> Mix()
        {
            string Naziv = HttpContext.Current.Request.Params["Naziv"];
            string toLowerNaziv = Naziv.ToLower();
            string Adresa = HttpContext.Current.Request.Params["Adresa"];
            string toLowerAdresa = Adresa.ToLower();
            string Godina = HttpContext.Current.Request.Params["Godina"];
            List<FitnesCentar> retlist = new List<FitnesCentar>();
            List<FitnesCentar> temp = new List<FitnesCentar>();
            fcentri = FitnesCentri.fcentri;

            foreach (var item in fcentri)
            {
                if (item.Obrisan == false)
                    temp.Add(item);
            }
            foreach (var item in temp)
            {
                //string s = item.AddressF.Street + " " + item.AddressF.Number + ", " + item.AddressF.Town + ", " + item.AddressF.PostNumber;
                //string lower = s.ToLower();
                string lowerName = item.Naziv.ToLower();
                string lowerAddress = item.Adresa.ToLower();
                if (lowerName.Contains(Naziv) && lowerAddress.Contains(Adresa) && item.GodinaOtvaranja.ToString().Contains(Godina))
                {
                    retlist.Add(item);
                }
            }

            return retlist;
        }*/

    }
}
