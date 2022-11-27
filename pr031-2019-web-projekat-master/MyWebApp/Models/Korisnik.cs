using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Korisnik
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Pol PolKorisnika { get; set; }
        public string Email { get; set; }
        public string DatumRodjenja { get; set; }
        public UlogaKorisnika Uloga { get; set; }
        public int FC { get; set; }  // gde je trener
        public List<int> grupniTreninzi { get; set; } //trener, posetilac  ID treninga
        public List<int> fitnesCentri { get; set; }  //vlasnik           ID
        public int Id { get; set; }
        public bool Obrisan { get; set; }
        public bool Ulogovan { get; set; }
        public bool Blokiran { get; set; }
        public Korisnik()
        {
            grupniTreninzi = new List<int>();
        }

        public Korisnik(string korisnickoIme, string lozinka, string ime, string prezime, Pol polKorisnika, string email, string datumRodjenja, UlogaKorisnika uloga, int id)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            PolKorisnika = polKorisnika;
            Email = email;
            DatumRodjenja = datumRodjenja;
            Uloga = uloga;
            Id = id;
        }
    }
}