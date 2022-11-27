using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Korisnici
    {
        public static List<Korisnik> korisnici { get; set; } = new List<Korisnik>();
        public static List<Korisnik> ulogovani { get; set; } = new List<Korisnik>();
        public static Korisnik UlogovanKorisnik;
        
        public static UlogaKorisnika uloga = UlogaKorisnika.Posetilac;
        public static bool Ulogovan = false;

        public static List<Korisnik> UcitajKorisnike()
        {
            korisnici.Clear();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamReader r = new StreamReader(path + "korisnici.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<Korisnik>>(json);
                foreach (var item in items)
                {
                    korisnici.Add(item);
                }
            }
            return korisnici;
        }

        public static UlogaKorisnika Uloga()
        {
            return uloga;
        }

        public static Korisnik Promeni(Korisnik korisnik)
        {
            foreach (Korisnik k in korisnici)
            {
                if (k.Id == korisnik.Id)
                {
                    k.KorisnickoIme = korisnik.KorisnickoIme;
                    k.Lozinka = korisnik.Lozinka;
                    k.Ime = korisnik.Ime;
                    k.Prezime = korisnik.Prezime;
                    k.Email = korisnik.Email;
                    k.DatumRodjenja = korisnik.DatumRodjenja;
                    return k;
                }
            }
            return korisnik;
        }

        public static void LoggedOut()
        {
            ulogovani.Remove(UlogovanKorisnik);
            UlogovanKorisnik = null;
            Ulogovan = false;
        }

        public static string KorisnickoIme()
        {
            if (Ulogovan == true)
                return UlogovanKorisnik.KorisnickoIme;
            else
                return "blablabla";
        }

        public static Korisnik LoggedIn(string kime, string lozinka)
        {
            foreach (var item in korisnici)
            {
                if (item.KorisnickoIme == kime && item.Lozinka == lozinka && item.Blokiran == false)
                {
                    ulogovani.Add(item);
                    UlogovanKorisnik = item;
                    Ulogovan = true;
                    uloga = item.Uloga;
                    return item;
                }
            }
            return (new Korisnik { KorisnickoIme=" ", Lozinka=""}); 
        }

        public static void Registracija()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            using (StreamWriter sw = new StreamWriter(path + "korisnici.json", append: false))
            {
                sw.WriteLine("[");
                var items = korisnici;
                foreach (var item in items)
                {
                    //if (item.Uloga != UlogaKorisnika.Vlasnik)
                    //{
                    sw.WriteLine("{");
                    sw.WriteLine("\"KorisnickoIme\":\"" + item.KorisnickoIme + "\",");
                    sw.WriteLine("\"Lozinka\":\"" + item.Lozinka + "\",");
                    sw.WriteLine("\"Ime\":\"" + item.Ime + "\",");
                    sw.WriteLine("\"Prezime\":\"" + item.Prezime + "\",");
                    if (item.PolKorisnika == Pol.Muski)
                        sw.WriteLine("\"PolKorisnika\":" + 0 + ",");
                    else
                        sw.WriteLine("\"PolKorisnika\":" + 1 + ",");
                    sw.WriteLine("\"Email\":\"" + item.Email + "\",");
                    sw.WriteLine("\"DatumRodjenja\":" + JsonConvert.SerializeObject(item.DatumRodjenja) + ",");
                    if (item.Uloga == UlogaKorisnika.Posetilac)
                        sw.WriteLine("\"Uloga\":" + 0 + ","); // posetilac kad se registruje
                    else if (item.Uloga == UlogaKorisnika.Trener)
                        sw.WriteLine("\"Uloga\":" + 1 + ",");
                    else
                        sw.WriteLine("\"Uloga\":" + 2 + ","); 
                    if (item.Uloga == UlogaKorisnika.Trener)
                        sw.WriteLine("\"FC\":" + item.FC + ",");
                    else
                        sw.WriteLine("\"FC\":" + 0 + ",");
                    sw.WriteLine("\"grupniTreninzi\":[");
                    if (item.Uloga == UlogaKorisnika.Trener || item.Uloga == UlogaKorisnika.Posetilac)
                    {
                        foreach (var t in item.grupniTreninzi)
                        {
                            sw.Write(t + ",");
                        }
                    }
                    sw.WriteLine("],");
                    sw.WriteLine("\"fitnesCentri\":[");
                    if (item.Uloga == UlogaKorisnika.Vlasnik)
                    {
                        foreach (var t in item.fitnesCentri)
                        {
                            sw.Write(t + ",");
                        }
                    }
                    sw.WriteLine("],");
                    sw.WriteLine("\"Id\":" + item.Id + ",");
                    if(item.Obrisan == false)
                        sw.WriteLine("\"Obrisan\":" + "false" + ",");
                    else
                        sw.WriteLine("\"Obrisan\":" + "true" + ",");
                    if(item.Ulogovan == true)
                        sw.WriteLine("\"Ulogovan\":" + "true" + ",");
                    else
                        sw.WriteLine("\"Ulogovan\":" + "false" + ",");
                    if (item.Blokiran == true)
                        sw.WriteLine("\"Blokiran\":" + "true" + ",");
                    else
                        sw.WriteLine("\"Blokiran\":" + "false" + ",");
                    sw.WriteLine("},");
                   // }
                }
                sw.WriteLine("]");
            }
        }

        public static void RegistracijaTrenera()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            using (StreamWriter sw = new StreamWriter(path + "korisnici.json", append: false))
            {
                sw.WriteLine("[");
                var items = korisnici;
                foreach (var item in items)
                {
                    //if (item.Uloga != UlogaKorisnika.Vlasnik)
                    //{
                    sw.WriteLine("{");
                    sw.WriteLine("\"KorisnickoIme\":\"" + item.KorisnickoIme + "\",");
                    sw.WriteLine("\"Lozinka\":\"" + item.Lozinka + "\",");
                    sw.WriteLine("\"Ime\":\"" + item.Ime + "\",");
                    sw.WriteLine("\"Prezime\":\"" + item.Prezime + "\",");
                    if (item.PolKorisnika == Pol.Muski)
                        sw.WriteLine("\"PolKorisnika\":" + 0 + ",");
                    else
                        sw.WriteLine("\"PolKorisnika\":" + 1 + ",");
                    sw.WriteLine("\"Email\":\"" + item.Email + "\",");
                    sw.WriteLine("\"DatumRodjenja\":" + JsonConvert.SerializeObject(item.DatumRodjenja) + ",");
                    if (item.Uloga == UlogaKorisnika.Posetilac)
                        sw.WriteLine("\"Uloga\":" + 0 + ","); // posetilac kad se registruje
                    else if (item.Uloga == UlogaKorisnika.Trener)
                        sw.WriteLine("\"Uloga\":" + 1 + ",");
                    else
                        sw.WriteLine("\"Uloga\":" + 2 + ",");
                    if (item.Uloga == UlogaKorisnika.Trener)
                        sw.WriteLine("\"FC\":" + item.FC + ",");
                    else
                        sw.WriteLine("\"FC\":" + 0 + ",");
                    sw.WriteLine("\"grupniTreninzi\":[");
                    if (item.Uloga == UlogaKorisnika.Trener || item.Uloga == UlogaKorisnika.Posetilac)
                    {
                        foreach (var t in item.grupniTreninzi)
                        {
                            sw.Write(t + ",");
                        }
                    }
                    sw.WriteLine("],");
                    sw.WriteLine("\"fitnesCentri\":[");
                    if (item.Uloga == UlogaKorisnika.Vlasnik)
                    {
                        foreach (var t in item.fitnesCentri)
                        {
                            sw.Write(t + ",");
                        }
                    }
                    sw.WriteLine("],");
                    sw.WriteLine("\"Id\":" + item.Id + ",");
                    if (item.Obrisan == false)
                        sw.WriteLine("\"Obrisan\":" + "false" + ",");
                    else
                        sw.WriteLine("\"Obrisan\":" + "true" + ",");
                   // if (item.Ulogovan == true)
                    //    sw.WriteLine("\"Ulogovan\":" + "true" + ",");
                    //else
                    sw.WriteLine("\"Ulogovan\":" + "false" + ",");
                    if (item.Blokiran == true)
                        sw.WriteLine("\"Blokiran\":" + "true" + ",");
                    else
                        sw.WriteLine("\"Blokiran\":" + "false" + ",");
                    sw.WriteLine("},");
                    // }
                }
                sw.WriteLine("]");
            }
        }

        public static Korisnik DodajKorisnika(Korisnik k)
        {
            k.Id = GenerateId();
            korisnici.Add(k);
            return k;
        }

        public static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }

    }
}