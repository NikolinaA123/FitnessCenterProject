using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class FitnesCentar
    {
        public FitnesCentar(string naziv, string adresa, int godinaOtvaranja, string vlasnik, double cenaMesecneClanarine, double cenaGodisnjeClanarine, double cenaTreninga, double cenaGrupnogTreninga, double cenaPersonalnogTreninga, int id)
        {
            Naziv = naziv;
            Adresa = adresa;
            GodinaOtvaranja = godinaOtvaranja;
            Vlasnik = vlasnik;
            CenaMesecneClanarine = cenaMesecneClanarine;
            CenaGodisnjeClanarine = cenaGodisnjeClanarine;
            CenaTreninga = cenaTreninga;
            CenaGrupnogTreninga = cenaGrupnogTreninga;
            CenaPersonalnogTreninga = cenaPersonalnogTreninga;
            Obrisan = false;
            Id = id;
        }
        public FitnesCentar() { }

        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int GodinaOtvaranja { get; set; }
        public string Vlasnik { get; set; }
        public double CenaMesecneClanarine { get; set; }
        public double CenaGodisnjeClanarine { get; set; }
        public double CenaTreninga { get; set; }
        public double CenaGrupnogTreninga { get; set; }
        public double CenaPersonalnogTreninga { get; set; }
        public int Id { get; set; }
        public bool Obrisan { get; set; }
    }
}