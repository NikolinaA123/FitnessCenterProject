using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class GrupniTrening
    {
        
        public string Naziv { get; set; }
        public TipTreninga Tip { get; set; }
        public FitnesCentar FCentar { get; set; }
        public int Trajanje { get; set; }
        public string DatumVreme { get; set; }
        public int MaksimalanBrPosetilaca { get; set; }
        public List<string> Posetioci { get; set; }
        public int Id { get; set; }
        public bool Obrisan { get; set; }

        public GrupniTrening()
        {
            
        }

        public GrupniTrening(List<string> posetioci, string naziv, TipTreninga tip, FitnesCentar fCentar, int trajanje, string datumVreme, int maksimalanBrPosetilaca, int id)
        {
            this.Posetioci = posetioci;
            Naziv = naziv;
            Tip = tip;
            FCentar = fCentar;
            Trajanje = trajanje;
            DatumVreme = datumVreme;
            MaksimalanBrPosetilaca = maksimalanBrPosetilaca;
            Id = id;
            Obrisan = false;
        }
        
    }
}