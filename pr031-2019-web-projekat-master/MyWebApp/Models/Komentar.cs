using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Komentar
    {
        public Komentar(string autorKomentara, int fCentar, string tekstKomentara, int ocena, int odobren, int id)
        {
            AutorKomentara = autorKomentara;
            FCentar = fCentar;
            TekstKomentara = tekstKomentara;
            Ocena = ocena;
            Odobren = odobren;
            Id = id;
        }

        public string AutorKomentara { get; set; }
        public int FCentar { get; set; }
        public string TekstKomentara { get; set; }
        public int Ocena { get; set; }
        public int Odobren { get; set; }
        public int Id { get; set; }
    }
}