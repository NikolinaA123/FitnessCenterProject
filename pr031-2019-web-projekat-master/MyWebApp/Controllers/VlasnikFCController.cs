using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class VlasnikFCController : ApiController
    {
        public static List<FitnesCentar> fcentri = new List<FitnesCentar>();
        [HttpGet]
        public List<FitnesCentar> Get()
        {
            List<int> centri = new List<int>();
            List<FitnesCentar> retList = new List<FitnesCentar>();
            fcentri = FitnesCentri.UcitajFCentre();

            foreach (var item in Korisnici.UlogovanKorisnik.fitnesCentri)
            {
                centri.Add(item);
            }
            foreach (var item in fcentri)
            {
                foreach (var id in centri)
                {
                    if(item.Id == id && item.Obrisan == false)
                    {
                        retList.Add(item);
                    }
                }
            }

            return retList;
        }
    }
}
