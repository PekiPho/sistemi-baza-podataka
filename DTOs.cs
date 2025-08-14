using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using proejkt.Entiteti;

namespace proejkt
{
    #region Banka

    public class BankaPregled
    {
        public int Id;
        public string Naziv;
        public string Email;
        public string AdresaCentrale;
        public string WebAdresa;
        public string BrojTelefona;

        public BankaPregled() { }

        public BankaPregled(int id, string naziv, string email, string adresaCentrale, string webAdresa, string brojTelefona)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Email = email;
            this.AdresaCentrale = adresaCentrale;
            this.WebAdresa = webAdresa;
            this.BrojTelefona = brojTelefona;
        }

        public BankaPregled(int idBanka)
        {
            this.Id = idBanka;
            this.Naziv = null;
            this.AdresaCentrale = null;
            this.BrojTelefona = null;
        }
    }

    public class BankaBasic
    {
        public int Id;
        public string Naziv;
        public string Email;
        public string AdresaCentrale;
        public string WebAdresa;
        public string BrojTelefona;

        public virtual IList<RacunBasic> Racuni { get; set; }

        public virtual IList<UredjajBasic> Uredjaji { get; set; }

        public virtual IList<FilijalaBasic> Filijale { get; set; }

        public BankaBasic()
        {
            Racuni = new List<RacunBasic>();
            Uredjaji = new List<UredjajBasic>();
            Filijale = new List<FilijalaBasic>();
        }

        public BankaBasic(int id, string naziv, string email, string adresaCentrale, string webAdresa, string brojTelefona)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Email = email;
            this.AdresaCentrale = adresaCentrale;
            this.WebAdresa = webAdresa;
            this.BrojTelefona = brojTelefona;
        }
    }
    #endregion

    #region Bankomat

    public class BankomatPregled : UredjajPregled
    {
        public decimal MaxIznos;
        public int BrojNovcanica;

        public BankomatPregled() { }

        public BankomatPregled(int idUredjaja, string proizvodjac, string statusRada, DateTime poslednjiServis, DateTime datumInstalacije, string dodatniKomentar,
            string adresa, string gps, FilijalaPregled f, BankaPregled b, decimal maxIznos, int brojNovcanica) : base(idUredjaja, proizvodjac, statusRada, poslednjiServis, datumInstalacije,
                dodatniKomentar, adresa, gps, f, b)
        {
            this.MaxIznos = maxIznos;
            this.BrojNovcanica = brojNovcanica;
        }
    }

    public class BankomatBasic : UredjajBasic
    {
        public decimal MaxIznos;
        public int BrojNovcanica;

        public BankomatBasic() { }

        public BankomatBasic(int idUredjaja, string proizvodjac, string statusRada, DateTime poslednjiServis, DateTime datumInstalacije, string dodatniKomentar,
            string adresa, string gps, FilijalaBasic f, BankaBasic b, decimal maxIznos, int brojNovcanica) : base(idUredjaja, proizvodjac, statusRada, poslednjiServis, datumInstalacije,
                dodatniKomentar, adresa, gps, f, b)
        {
            this.MaxIznos = maxIznos;
            this.BrojNovcanica = brojNovcanica;
        }
    }

    #endregion

    #region BrojTelefona

    public class BrojTelefonaPregled
    {
        public int Id;
        public KlijentPregled Klijent;
        public string Telefon;

        public BrojTelefonaPregled() { }

        public BrojTelefonaPregled(int id, KlijentPregled k, string telefon)
        {
            this.Id = id;
            this.Klijent = k;
            this.Telefon = telefon;
        }
    }

    public class BrojTelefonaBasic
    {
        public int Id;
        public KlijentBasic Klijent;
        public string Telefon;

        public BrojTelefonaBasic() { }

        public BrojTelefonaBasic(int id, KlijentBasic k, string telefon)
        {
            this.Id = id;
            this.Klijent = k;
            this.Telefon = telefon;
        }
    }
    #endregion

    #region Debitna

    public class DebitnaPregled : KarticaPregled
    {
        public decimal DnevniLimit;

        public DebitnaPregled() { }

        public DebitnaPregled(string brojKartice, DateTime datumIsteka, DateTime datumIzdavanja, RacunPregled r, decimal dnevniLimit) : base(brojKartice, datumIsteka,
            datumIzdavanja, r)
        {
            this.DnevniLimit = dnevniLimit;
        }
    }

    public class DebitnaBasic : KarticaBasic
    {
        public decimal DnevniLimit;

        public DebitnaBasic() { }

        public DebitnaBasic(string brojKartice, DateTime datumIsteka, DateTime datumIzdavanja, RacunBasic r, decimal dnevniLimit) : base(brojKartice, datumIsteka,
            datumIzdavanja, r)
        {
            this.DnevniLimit = dnevniLimit;
        }
    }
    #endregion

    #region Filijala

    public class FilijalaPregled
    {
        public int RedniBroj;
        public string Adresa;
        public string RadniDan;
        public string Subota;
        public string Nedelja;
        public BankaPregled Banka;
        public FilijalaPregled() { }

        public FilijalaPregled(int redniBroj, string adresa, string radniDan, string subota, string nedelja, BankaPregled b)
        {
            this.RedniBroj = redniBroj;
            this.Adresa = adresa;
            this.RadniDan = radniDan;
            this.Subota = subota;
            this.Nedelja = nedelja;
            this.Banka = b;
        }

        public FilijalaPregled(int redniBroj)
        {
            this.RedniBroj = redniBroj;
        }
    }

    public class FilijalaBasic
    {
        public int RedniBroj;
        public string Adresa;
        public string RadniDan;
        public string Subota;
        public string Nedelja;
        public BankaBasic Banka;

        public virtual IList<UredjajBasic> Uredjaji { get; set; }
        public virtual IList<TelefonFilijaleBasic> Telefoni { get; set; }

        public FilijalaBasic()
        {
            Uredjaji = new List<UredjajBasic>();
            Telefoni = new List<TelefonFilijaleBasic>();
        }
        public FilijalaBasic(int redniBroj, string adresa, string radniDan, string subota, string nedelja, BankaBasic b)
        {
            this.RedniBroj = redniBroj;
            this.Adresa = adresa;
            this.RadniDan = radniDan;
            this.Subota = subota;
            this.Nedelja = nedelja;
            this.Banka = b;
        }
    }
    #endregion

    #region FizickaLica

    public class FizickaLicaPregled : KlijentPregled
    {
        public string JMBG;

        public string MestoIzdavanja;

        public string Adresa;

        public DateTime DatumRodjenja;

        public string BrojLicneKarte;

        public string LicnoIme;

        public string ImeRoditelja;

        public string Prezime;

        public FizickaLicaPregled() { }

        public FizickaLicaPregled(int idKlijenta, string jbmg, string mestoIzdavanja, string adresa, DateTime datumRodjenja, string brojLicneKarte,
            string licnoIme, string imeRoditelja, string prezime) : base(idKlijenta)
        {
            this.JMBG = jbmg;
            this.MestoIzdavanja = mestoIzdavanja;
            this.Adresa = adresa;
            this.DatumRodjenja = datumRodjenja;
            this.BrojLicneKarte = brojLicneKarte;
            this.LicnoIme = licnoIme;
            this.ImeRoditelja = imeRoditelja;
            this.Prezime = prezime;
        }
    }

    public class FizickaLicaBasic : KlijentBasic
    {
        public string JMBG;

        public string MestoIzdavanja;

        public string Adresa;

        public DateTime DatumRodjenja;

        public string BrojLicneKarte;

        public string LicnoIme;

        public string ImeRoditelja;

        public string Prezime;

        public virtual IList<BrojTelefonaBasic> BrojeviTelefona { get; set; }

        public FizickaLicaBasic()
        {
            BrojeviTelefona = new List<BrojTelefonaBasic>();
        }
        public FizickaLicaBasic(int idKlijenta, string jbmg, string mestoIzdavanja, string adresa, DateTime datumRodjenja, string brojLicneKarte,
            string licnoIme, string imeRoditelja, string prezime) : base(idKlijenta)
        {
            this.JMBG = jbmg;
            this.MestoIzdavanja = mestoIzdavanja;
            this.Adresa = adresa;
            this.DatumRodjenja = datumRodjenja;
            this.BrojLicneKarte = brojLicneKarte;
            this.LicnoIme = licnoIme;
            this.ImeRoditelja = imeRoditelja;
            this.Prezime = prezime;
        }
    }
    #endregion

    #region Kartica

    public class KarticaPregled
    {
        public string BrojKartice;
        public DateTime DatumIsteka;
        public DateTime DatumIzdavanja;
        public RacunPregled Racun;

        public KarticaPregled() { }

        public KarticaPregled(string brojKartice, DateTime datumIsteka, DateTime datumIzdavanja, RacunPregled r)
        {
            this.BrojKartice = brojKartice;
            this.DatumIsteka = datumIsteka;
            this.DatumIzdavanja = datumIzdavanja;
            this.Racun = r;
        }

        public KarticaPregled(string brojKartice)
        {
            this.BrojKartice = brojKartice;
        }
    }

    public class KarticaBasic
    {
        public string BrojKartice;
        public DateTime DatumIsteka;
        public DateTime DatumIzdavanja;
        public RacunBasic Racun;
        public virtual IList<TransakcijaBasic> Transakcije { get; set; }

        public KarticaBasic()
        {
            Transakcije = new List<TransakcijaBasic>();
        }

        public KarticaBasic(string brojKartice, DateTime datumIsteka, DateTime datumIzdavanja, RacunBasic r)
        {
            this.BrojKartice = brojKartice;
            this.DatumIsteka = datumIsteka;
            this.DatumIzdavanja = datumIzdavanja;
            this.Racun = r;
        }
    }
    #endregion

    #region Kiosk

    public class KioskPregled : UredjajPregled
    {
        public string Skener;
        public string Stampac;

        public KioskPregled() { }
        public KioskPregled(int idUredjaja, string proizvodjac, string statusRada, DateTime poslednjiServis, DateTime datumInstalacije, string dodatniKomentar,
            string adresa, string gps, FilijalaPregled f, BankaPregled b, string skener, string stampac) : base(idUredjaja, proizvodjac, statusRada, poslednjiServis, datumInstalacije, dodatniKomentar,
                adresa, gps, f, b)
        {
            this.Skener = skener;
            this.Stampac = stampac;
        }
    }

    public class KioskBasic : UredjajBasic
    {
        public string Skener;
        public string Stampac;

        public KioskBasic() { }

        public KioskBasic(int idUredjaja, string proizvodjac, string statusRada, DateTime poslednjiServis, DateTime datumInstalacije, string dodatniKomentar,
            string adresa, string gps, FilijalaBasic f, BankaBasic b, string skener, string stampac) : base(idUredjaja, proizvodjac, statusRada, poslednjiServis, datumInstalacije, dodatniKomentar,
                adresa, gps, f, b)
        {
            this.Skener = skener;
            this.Stampac = stampac;
        }
    }
    #endregion

    #region Klijent

    public class KlijentPregled
    {
        public int IdKlijenta;

        public KlijentPregled() { }

        public KlijentPregled(int idKlijenta)
        {
            this.IdKlijenta = idKlijenta;
        }
    }

    public class KlijentBasic
    {
        public int IdKlijenta;

        public virtual IList<RacunBasic> Racuni { get; set; }

        public KlijentBasic()
        {
            Racuni = new List<RacunBasic>();
        }

        public KlijentBasic(int idKlijenta)
        {
            this.IdKlijenta = idKlijenta;
        }
    }
    #endregion

    #region Kreditna

    public class KreditnaPregled : KarticaPregled
    {
        public decimal MesecniLimit;
        public int MaxPeriodOtplate;

        public KreditnaPregled() { }

        public KreditnaPregled(string brojKartice, DateTime datumIsteka, DateTime datumIzdavanja, RacunPregled r, decimal mesecniLimit, int maxPeriodOtplate) :
            base(brojKartice, datumIsteka, datumIzdavanja, r)
        {
            this.MesecniLimit = mesecniLimit;
            this.MaxPeriodOtplate = maxPeriodOtplate;
        }
    }

    public class KreditnaBasic : KarticaBasic
    {
        public decimal MesecniLimit;
        public int MaxPeriodOtplate;

        public KreditnaBasic() { }

        public KreditnaBasic(string brojKartice, DateTime datumIsteka, DateTime datumIzdavanja, RacunBasic r, decimal mesecniLimit, int maxPeriodOtplate) :
            base(brojKartice, datumIsteka, datumIzdavanja, r)
        {
            this.MesecniLimit = mesecniLimit;
            this.MaxPeriodOtplate = maxPeriodOtplate;
        }
    }
    #endregion

    #region Organizacije

    public class OrganizacijePregled : KlijentPregled
    {
        public string Registar;
        public string Tip;
        public string Osnivac;
        public string KontaktPodaci;
        public string Adresa;

        public OrganizacijePregled() { }

        public OrganizacijePregled(int idKlijenta, string registar, string tip, string osnivac, string kontaktPodaci, string adresa) : base(idKlijenta)
        {
            this.Registar = registar;
            this.Tip = tip;
            this.Osnivac = osnivac;
            this.KontaktPodaci = kontaktPodaci;
            this.Adresa = adresa;
        }
    }

    public class OrganizacijaBasic : KlijentBasic
    {
        public string Registar;
        public string Tip;
        public string Osnivac;
        public string KontaktPodaci;
        public string Adresa;

        public OrganizacijaBasic() { }

        public OrganizacijaBasic(int idKlijenta, string registar, string tip, string osnivac, string kontaktPodaci, string adresa) : base(idKlijenta)
        {

            this.Registar = registar;
            this.Tip = tip;
            this.Osnivac = osnivac;
            this.KontaktPodaci = kontaktPodaci;
            this.Adresa = adresa;
        }
    }
    #endregion

    #region PodrzaniServisi

    public class PodrzaniServisiPregled
    {
        public int Id;
        public UredjajPregled Uredjaj;
        public string Servis;

        public PodrzaniServisiPregled() { }

        public PodrzaniServisiPregled(int id, UredjajPregled u, string servis)
        {
            this.Id = id;
            this.Uredjaj = u;
            this.Servis = servis;
        }
    }

    public class PodrzaniServisiBasic
    {
        public int Id;
        public UredjajBasic Uredjaj;
        public string Servis;

        public PodrzaniServisiBasic() { }

        public PodrzaniServisiBasic(int id, UredjajBasic u, string servis)
        {
            this.Id = id;
            this.Uredjaj = u;
            this.Servis = servis;
        }
    }
    #endregion

    #region PravnaLicaPregled

    public class PravnaLicaPregled : KlijentPregled
    {
        public string PIB;
        public string NazivFirme;
        public string Kontakt;
        public string MaticniBroj;
        public string Delatnost;
        public string Adresa;
        public string KontaktPodaci;

        public PravnaLicaPregled() { }

        public PravnaLicaPregled(int idKlijenta, string pib, string nazivFirme, string kontakt, string maticniBroj, string delatnost,
            string adresa, string kontaktPodaci) : base(idKlijenta)
        {
            this.PIB = pib;
            this.NazivFirme = nazivFirme;
            this.Kontakt = kontakt;
            this.MaticniBroj = maticniBroj;
            this.Delatnost = delatnost;
            this.Adresa = adresa;
            this.KontaktPodaci = kontaktPodaci;
        }
    }

    public class PravnaLicaBasic : KlijentBasic
    {
        public string PIB;
        public string NazivFirme;
        public string Kontakt;
        public string MaticniBroj;
        public string Delatnost;
        public string Adresa;
        public string KontaktPodaci;

        public PravnaLicaBasic() { }

        public PravnaLicaBasic(int idKlijenta, string pib, string nazivFirme, string kontakt, string maticniBroj, string delatnost,
            string adresa, string kontaktPodaci) : base(idKlijenta)
        {
            this.PIB = pib;
            this.NazivFirme = nazivFirme;
            this.Kontakt = kontakt;
            this.MaticniBroj = maticniBroj;
            this.Delatnost = delatnost;
            this.Adresa = adresa;
            this.KontaktPodaci = kontaktPodaci;
        }
    }
    #endregion

    #region Racun

    public class RacunPregled
    {
        public string BrojRacuna;
        public string Status;
        public string Valuta;
        public DateTime DatumOtvaranja;
        public decimal TrenutniSaldo;
        public KlijentPregled Klijent;
        public BankaPregled Banka;

        public RacunPregled() { }

        public RacunPregled(string brojRacuna, string status, string valuta, DateTime datumOtvaranja, decimal trenutniSaldo, KlijentPregled k, BankaPregled b)
        {
            this.BrojRacuna = brojRacuna;
            this.Status = status;
            this.Valuta = valuta;
            this.DatumOtvaranja = datumOtvaranja;
            this.TrenutniSaldo = trenutniSaldo;
            this.Klijent = k;
            this.Banka = b;
        }

        public RacunPregled(string brojRacuna)
        {
            this.BrojRacuna = brojRacuna;
        }
    }

    public class RacunBasic
    {
        public string BrojRacuna;
        public string Status;
        public string Valuta;
        public DateTime DatumOtvaranja;
        public decimal TrenutniSaldo;
        public KlijentBasic Klijent;
        public BankaBasic Banka;

        public virtual IList<KarticaBasic> Kartice { get; set; }

        public RacunBasic()
        {
            Kartice = new List<KarticaBasic>();
        }

        public RacunBasic(string brojRacuna, string status, string valuta, DateTime datumOtvaranja, decimal trenutniSaldo, KlijentBasic k, BankaBasic b)
        {
            this.BrojRacuna = brojRacuna;
            this.Status = status;
            this.Valuta = valuta;
            this.DatumOtvaranja = datumOtvaranja;
            this.TrenutniSaldo = trenutniSaldo;
            this.Klijent = k;
            this.Banka = b;
        }

        public RacunBasic(string brojRacuna, string status, string valuta,
                  DateTime datumOtvaranja, decimal trenutniSaldo)
        {
            this.BrojRacuna = brojRacuna;
            this.Status = status;
            this.Valuta = valuta;
            this.DatumOtvaranja = datumOtvaranja;
            this.TrenutniSaldo = trenutniSaldo;
            this.Kartice = new List<KarticaBasic>();
        }
    }
    #endregion

    #region TelefonFilijale

    public class TelefonFilijalePregled
    {
        public int Id;
        public FilijalaPregled Filijala;
        public string Telefon;

        public TelefonFilijalePregled() { }

        public TelefonFilijalePregled(int id, FilijalaPregled f, string telefon)
        {
            this.Id = id;
            this.Filijala = f;
            this.Telefon = telefon;
        }
    }

    public class TelefonFilijaleBasic
    {
        public int Id;
        public FilijalaBasic Filijala;
        public string Telefon;

        public TelefonFilijaleBasic() { }

        public TelefonFilijaleBasic(int id, FilijalaBasic f, string telefon)
        {
            this.Id = id;
            this.Filijala = f;
            this.Telefon = telefon;
        }
    }
    #endregion

    #region Transakcija

    public class TransakcijaPregled
    {
        public int IdTransakcije;
        public string Valuta;
        public DateTime Datum;
        public string Status;
        public decimal Iznos;
        public string RazlogNeuspeha;
        public string Vreme;
        public string VrstaTransakcije;
        public KarticaPregled Kartica;
        public UredjajPregled Uredjaj;

        public TransakcijaPregled() { }

        public TransakcijaPregled(int idTransakcije, string valuta, DateTime datum, string status, decimal iznos, string razlogNeuspeha, string vreme,
            string vrstaTransakcije, KarticaPregled k, UredjajPregled u) 
        {
            this.IdTransakcije = idTransakcije;
            this.Valuta = valuta;
            this.Datum = datum;
            this.Status = status;
            this.Iznos = iznos;
            this.RazlogNeuspeha = razlogNeuspeha;
            this.Vreme = vreme;
            this.VrstaTransakcije = vrstaTransakcije;
            this.Kartica = k;
            this.Uredjaj = u;
        }
    }

    public class TransakcijaBasic
    {
        public int IdTransakcije;
        public string Valuta;
        public DateTime Datum;
        public string Status;
        public decimal Iznos;
        public string RazlogNeuspeha;
        public string Vreme;
        public string VrstaTransakcije;
        public KarticaBasic Kartica;
        public UredjajBasic Uredjaj;

        public TransakcijaBasic() { }

        public TransakcijaBasic(int idTransakcije, string valuta, DateTime datum, string status, decimal iznos, string razlogNeuspeha, string vreme,
            string vrstaTransakcije, KarticaBasic k, UredjajBasic u)
        {
            this.IdTransakcije = idTransakcije;
            this.Valuta = valuta;
            this.Datum = datum;
            this.Status = status;
            this.Iznos = iznos;
            this.RazlogNeuspeha = razlogNeuspeha;
            this.Vreme = vreme;
            this.VrstaTransakcije = vrstaTransakcije;
            this.Kartica = k;
            this.Uredjaj = u;
        }
    }
    #endregion

    #region UplatniAutomat

    public class UplatniAutomatPregled : UredjajPregled
    {
        public string VrstaUplate;
        public string Validator;

        public UplatniAutomatPregled() { }

        public UplatniAutomatPregled(int idUredjaja, string proizvodjac, string statusRada, DateTime poslednjiServis, DateTime datumInstalacije,
            string dodatniKomentar, string adresa, string gps, FilijalaPregled f, BankaPregled b, string vrstaUplate, string validator)
             : base(idUredjaja, proizvodjac, statusRada, poslednjiServis, datumInstalacije, dodatniKomentar, adresa, gps, f, b) 
        {
            this.VrstaUplate = vrstaUplate;
            this.Validator = validator;
        }
    }

    public class UplatniAutomatBasic : UredjajBasic
    {
        public string VrstaUplate;
        public string Validator;

        public UplatniAutomatBasic() { }

        public UplatniAutomatBasic(int idUredjaja, string proizvodjac, string statusRada, DateTime poslednjiServis, DateTime datumInstalacije,
            string dodatniKomentar, string adresa, string gps, FilijalaBasic f, BankaBasic b, string vrstaUplate, string validator) 
            : base(idUredjaja, proizvodjac, statusRada, poslednjiServis, datumInstalacije, dodatniKomentar, adresa, gps, f, b)
        {
            this.VrstaUplate = vrstaUplate;
            this.Validator = validator;
        }
    }
    #endregion

    #region Uredjaj

    public class UredjajPregled
    {
        public int IdUredjaja;
        public string Proizvodjac;
        public string StatusRada;
        public DateTime PoslednjiServis;
        public DateTime DatumInstalacije;
        public string DodatniKomentar;
        public string Adresa;
        public string GPS;
        public FilijalaPregled Filijala;
        public BankaPregled Banka;

        public UredjajPregled() { }

        public UredjajPregled(int id, string proizvodjac, string statusRada, DateTime poslednjiServis, DateTime datumInstalacije, string dodatniKomentar,
            string adresa, string gps, FilijalaPregled f, BankaPregled b)
        {
            this.IdUredjaja = id;
            this.Proizvodjac = proizvodjac;
            this.StatusRada = statusRada;
            this.PoslednjiServis = poslednjiServis;
            this.DatumInstalacije = datumInstalacije;
            this.DodatniKomentar = dodatniKomentar;
            this.Adresa = adresa;
            this.GPS = gps;
            this.Filijala = f;
            this.Banka = b;
        }


        public UredjajPregled(int id)
        {
            this.IdUredjaja = id;
            this.Filijala = null;
            this.Banka = null;
        }
    }

    public class UredjajBasic
    {
        public int IdUredjaja;
        public string Proizvodjac;
        public string StatusRada;
        public DateTime PoslednjiServis;
        public DateTime DatumInstalacije;
        public string DodatniKomentar;
        public string Adresa;
        public string GPS;
        public FilijalaBasic Filijala;
        public BankaBasic Banka;

        public virtual IList<TransakcijaBasic> Transakcije { get; set; }

        public virtual IList<PodrzaniServisiBasic> Servisi { get; set; }

        public UredjajBasic() 
        {
            Transakcije = new List<TransakcijaBasic>();
            Servisi = new List<PodrzaniServisiBasic>();
        }

        public UredjajBasic(int id, string proizvodjac, string statusRada, DateTime poslednjiServis, DateTime datumInstalacije, string dodatniKomentar,
            string adresa, string gps, FilijalaBasic f, BankaBasic b)
        {
            this.IdUredjaja = id;
            this.Proizvodjac = proizvodjac;
            this.StatusRada = statusRada;
            this.PoslednjiServis = poslednjiServis;
            this.DatumInstalacije = datumInstalacije;
            this.DodatniKomentar = dodatniKomentar;
            this.Adresa = adresa;
            this.GPS = gps;
            this.Filijala = f;
            this.Banka = b;
        }
    }
    #endregion


}
