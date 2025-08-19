using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt
{
    public class DTOManager
    {
        #region Klijent
            
        public static List<KlijentPregled> vratiSveKlijente()
        {
            List<KlijentPregled> klijenti = new List<KlijentPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<proejkt.Entiteti.Klijent> sviKlijenti = s.Query<proejkt.Entiteti.Klijent>();

                foreach(var k in sviKlijenti)
                {
                    klijenti.Add(new KlijentPregled(k.IdKlijenta));
                }

                s.Close();
            }
            catch(Exception ex)
            {

            }

            return klijenti;
        }

        public static KlijentBasic vratiKlijenta(int id)
        {
            KlijentBasic k = new KlijentBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                proejkt.Entiteti.Klijent o = s.Load<proejkt.Entiteti.Klijent>(id);

                k = new KlijentBasic(o.IdKlijenta);

                foreach(var r in o.Racuni)
                {
                    k.Racuni.Add(new RacunBasic(r.BrojRacuna, r.Status, r.Valuta, r.DatumOtvaranja, r.TrenutniSaldo));
                }

                s.Close();
            }
            catch(Exception ex)
            {

            }

            return k;
        }

        public static List<RacunPregled> vratiRacuneZaKlijenta(int idKlijenta)
        {
            List<RacunPregled> racuni = new List<RacunPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var lista = s.Query<proejkt.Entiteti.Racun>()
                                 .Where(r => r.Klijent.IdKlijenta == idKlijenta);

                    foreach (var r in lista)
                    {
                        var klijentPregled = new KlijentPregled(r.Klijent.IdKlijenta);
                        var bankaPregled = new BankaPregled(r.Banka.Id);
                        racuni.Add(new RacunPregled(
                            r.BrojRacuna,
                            r.Status,
                            r.Valuta,
                            r.DatumOtvaranja,
                            r.TrenutniSaldo,
                            klijentPregled,
                            bankaPregled));
                    }
                }
            }
            catch { }

            return racuni;
        }

        public static void dodajKlijenta(KlijentBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                var novi = new proejkt.Entiteti.Klijent();

                s.SaveOrUpdate(novi);
                s.Flush();
                s.Close();

            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiKlijenta(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                var k = s.Get<proejkt.Entiteti.Klijent>(id);

                if (k == null) return;

                s.Delete(k);

                s.Flush();

                s.Close();
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region FizickaLica

        public static List<FizickaLicaPregled> vratiSvaFizickaLica()
        {
            List<FizickaLicaPregled> fizickaLica = new List<FizickaLicaPregled>();
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    IEnumerable<proejkt.Entiteti.FizickaLica> o = s.Query<proejkt.Entiteti.FizickaLica>();

                    foreach(var f in o)
                    {
                        fizickaLica.Add(new FizickaLicaPregled(
                            f.IdKlijenta,
                            f.JMBG,
                            f.MestoIzdavanja,
                            f.Adresa,
                            f.DatumRodjenja,
                            f.BrojLicneKarte,
                            f.LicnoIme,
                            f.ImeRoditelja,
                            f.Prezime));
                    }

                    
                }
            }
            catch(Exception ex)
            {

            }

            return fizickaLica;
        }

        public static FizickaLicaPregled vratiFizickoLice(int id)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var o = s.Load<proejkt.Entiteti.FizickaLica>(id);

                    return new FizickaLicaPregled(
                        o.IdKlijenta,
                        o.JMBG,
                        o.MestoIzdavanja,
                        o.Adresa,
                        o.DatumRodjenja,
                        o.BrojLicneKarte,
                        o.LicnoIme,
                        o.ImeRoditelja,
                        o.Prezime);
                    
                }
            }

            catch(Exception ex)
            {
                return null;
            }
        }

        public static void dodajFizickoLice(FizickaLicaBasic f)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var novo = new proejkt.Entiteti.FizickaLica {
                        JMBG = f.JMBG,
                        MestoIzdavanja = f.MestoIzdavanja,
                        Adresa = f.Adresa,
                        DatumRodjenja = f.DatumRodjenja,
                        BrojLicneKarte = f.BrojLicneKarte,
                        LicnoIme = f.LicnoIme,
                        ImeRoditelja = f.ImeRoditelja,
                        Prezime = f.Prezime
                    };

                    s.SaveOrUpdate(novo);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void azurirajFizickoLice(FizickaLicaBasic f)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var lice = s.Get<proejkt.Entiteti.FizickaLica>(f.IdKlijenta);

                    if (lice == null) return;

                    lice.JMBG = f.JMBG;
                    lice.Adresa = f.Adresa;
                    lice.MestoIzdavanja = f.MestoIzdavanja;
                    lice.DatumRodjenja = f.DatumRodjenja;
                    lice.LicnoIme = f.LicnoIme;
                    lice.ImeRoditelja = f.ImeRoditelja;
                    lice.Prezime = f.Prezime;
                    lice.BrojLicneKarte = f.BrojLicneKarte;

                    s.Update(lice);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiFizickoLice(int id)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var lice = s.Get<proejkt.Entiteti.FizickaLica>(id);

                    if (lice == null) return;

                    s.Delete(lice);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region PravnaLica
        public static List<PravnaLicaPregled> vratiSvaPravnaLica()
        {
            List<PravnaLicaPregled> pravnaLica = new List<PravnaLicaPregled>();

            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    IEnumerable<proejkt.Entiteti.PravnaLica> o = s.Query<proejkt.Entiteti.PravnaLica>();

                    foreach(var p in o)
                    {
                        pravnaLica.Add(new PravnaLicaPregled(
                            p.IdKlijenta,
                            p.PIB,
                            p.NazivFirme,
                            p.Kontakt,
                            p.MaticniBroj,
                            p.Delatnost,
                            p.Adresa,
                            p.KontaktPodaci));
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return pravnaLica;
        }

        public static PravnaLicaPregled vratiPravnoLice(int id)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var o = s.Load<proejkt.Entiteti.PravnaLica>(id);

                    return new PravnaLicaPregled(
                        o.IdKlijenta,
                        o.PIB,
                        o.NazivFirme,
                        o.Kontakt,
                        o.MaticniBroj,
                        o.Delatnost,
                        o.Adresa,
                        o.KontaktPodaci);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static void dodajPravnoLice(PravnaLicaBasic p)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var novo = new proejkt.Entiteti.PravnaLica
                    {
                        PIB = p.PIB,
                        NazivFirme = p.NazivFirme,
                        Kontakt = p.Kontakt,
                        MaticniBroj = p.MaticniBroj,
                        Delatnost = p.Delatnost,
                        Adresa = p.Adresa,
                        KontaktPodaci = p.KontaktPodaci
                    };

                    s.SaveOrUpdate(novo);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void azurirajPravnoLice(PravnaLicaBasic p)
        {
            try
            {
                using(ISession s= DataLayer.GetSession())
                {
                    var lice = s.Get<proejkt.Entiteti.PravnaLica>(p.IdKlijenta);

                    if (lice == null) return;

                    lice.PIB = p.PIB;
                    lice.NazivFirme = p.NazivFirme;
                    lice.Kontakt = p.Kontakt;
                    lice.MaticniBroj = p.MaticniBroj;
                    lice.Delatnost = p.Delatnost;
                    lice.Adresa = p.Adresa;
                    lice.KontaktPodaci = p.KontaktPodaci;

                    s.Update(lice);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiPravnoLice(int id)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var lice = s.Get<proejkt.Entiteti.PravnaLica>(id);

                    if (lice == null) return;

                    s.Delete(lice);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region Organizacije

        public static List<OrganizacijePregled> vratiSveOrganizacije()
        {
            List<OrganizacijePregled> organizacije = new List<OrganizacijePregled>();

            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    IEnumerable<proejkt.Entiteti.Organizacije> o = s.Query<proejkt.Entiteti.Organizacije>();

                    foreach(var org in o)
                    {
                        organizacije.Add(new OrganizacijePregled(
                            org.IdKlijenta,
                            org.Registar,
                            org.Tip,
                            org.Osnivac,
                            org.KontaktPodaci,
                            org.Adresa));
                    }
                }
            }
            catch(Exception ex)
            {
                //return null;
            }

            return organizacije;
        }

        public static OrganizacijePregled vratiOrganizaciju(int id)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var o = s.Load<proejkt.Entiteti.Organizacije>(id);

                    return new OrganizacijePregled(
                        o.IdKlijenta,
                        o.Registar,
                        o.Tip,
                        o.Osnivac,
                        o.KontaktPodaci,
                        o.Adresa);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static void dodajOrganizaciju(OrganizacijaBasic o)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var novo = new proejkt.Entiteti.Organizacije
                    {
                        Registar = o.Registar,
                        Tip = o.Tip,
                        Osnivac = o.Osnivac,
                        KontaktPodaci = o.KontaktPodaci,
                        Adresa = o.Adresa
                    };

                    s.SaveOrUpdate(novo);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void azurirajOrganizaciju(OrganizacijaBasic o)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var org = s.Get<proejkt.Entiteti.Organizacije>(o.IdKlijenta);

                    if (org == null) return;

                    org.Registar = o.Registar;
                    org.Tip = o.Tip;
                    org.Osnivac = o.Osnivac;
                    org.KontaktPodaci = o.KontaktPodaci;
                    org.Adresa = o.Adresa;


                    s.Update(org);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }


        public static void obrisiOrganizaciju(int id)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var org = s.Get<proejkt.Entiteti.Organizacije>(id);

                    if (org == null) return;

                    s.Delete(org);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }


        #endregion

        #region Kartica

        public static List<KarticaPregled> vratiSveKartice()
        {
            List<KarticaPregled> kartice = new List<KarticaPregled>();

            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var sveKartice = s.Query<proejkt.Entiteti.Kartica>();

                    foreach(var k in sveKartice)
                    {
                        var racunPregled = new RacunPregled(k.Racun.BrojRacuna);
                        kartice.Add(new KarticaPregled(k.BrojKartice, k.DatumIsteka, k.DatumIzdavanja, racunPregled));
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return kartice;
        }

        public static KarticaPregled vratiKarticu(string brojKartice)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var k = s.Get<proejkt.Entiteti.Kartica>(brojKartice);

                    if (k == null) return null;

                    var racunPregled = new RacunPregled(k.Racun.BrojRacuna);
                    return new KarticaPregled(k.BrojKartice, k.DatumIsteka, k.DatumIzdavanja, racunPregled);

                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static List<TransakcijaPregled> vratiTransakcijeZaKarticu(string brojKartice)
        {
            List<TransakcijaPregled> transakcije = new List<TransakcijaPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var lista = s.Query<proejkt.Entiteti.Transakcija>()
                                 .Where(t => t.Kartica.BrojKartice == brojKartice);

                    foreach (var t in lista)
                    {
                        var karticaPregled = new KarticaPregled(t.Kartica.BrojKartice);
                        var uredjajPregled = new UredjajPregled(t.Uredjaj.IdUredjaja);

                        transakcije.Add(new TransakcijaPregled(
                            t.IdTransakcije,
                            t.Valuta,
                            t.Datum,
                            t.Status,
                            t.Iznos,
                            t.RazlogNeuspeha,
                            t.Vreme,
                            t.VrstaTransakcije,
                            karticaPregled,
                            uredjajPregled));
                    }
                }
            }
            catch { }

            return transakcije;
        }

        public static RacunPregled vratiRacunZaKarticu(string brojKartice)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var kartica = s.Get<proejkt.Entiteti.Kartica>(brojKartice);
                    if (kartica == null) return null;

                    var r = kartica.Racun;
                    var klijentPregled = new KlijentPregled(r.Klijent.IdKlijenta);
                    var bankaPregled = new BankaPregled(r.Banka.Id);

                    return new RacunPregled(
                        r.BrojRacuna,
                        r.Status,
                        r.Valuta,
                        r.DatumOtvaranja,
                        r.TrenutniSaldo,
                        klijentPregled,
                        bankaPregled);
                }
            }
            catch { return null; }
        }


        public static void dodajKarticu(KarticaBasic k)
        {
            try
            {
                using(ISession s= DataLayer.GetSession())
                {
                    var racun = s.Load<proejkt.Entiteti.Racun>(k.Racun.BrojRacuna);

                    var nova = new proejkt.Entiteti.Kartica
                    {
                        DatumIsteka = k.DatumIsteka,
                        DatumIzdavanja = k.DatumIzdavanja,
                        Racun = racun
                    };

                    s.SaveOrUpdate(nova);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void azurirajKarticu(KarticaBasic k)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var kartica = s.Get<proejkt.Entiteti.Kartica>(k.BrojKartice);

                    if (kartica == null) return;

                    kartica.DatumIsteka = k.DatumIsteka;
                    kartica.DatumIzdavanja = k.DatumIzdavanja;

                    var racun = s.Load<proejkt.Entiteti.Racun>(k.Racun.BrojRacuna);
                    kartica.Racun = racun;

                    s.Update(kartica);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiKarticu(string brojKartice)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var kartica = s.Get<proejkt.Entiteti.Kartica>(brojKartice);

                    if (kartica == null) return;

                    s.Delete(kartica);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        #region Debitna

        public static List<DebitnaPregled> vratiSveDebitneKartice()
        {
            List<DebitnaPregled> debitne = new List<DebitnaPregled>();

            try
            {
                using(ISession s= DataLayer.GetSession())
                {
                    var sveDebitne = s.Query<proejkt.Entiteti.Debitna>();

                    foreach(var d in sveDebitne)
                    {
                        var racunPregled = new RacunPregled(d.Racun.BrojRacuna);
                        debitne.Add(new DebitnaPregled(d.BrojKartice, d.DatumIsteka, d.DatumIzdavanja, racunPregled, d.DnevniLimit));
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return debitne;
        }

        public static DebitnaPregled vratiDebitnuKarticu(string brojKartice)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var d = s.Get<proejkt.Entiteti.Debitna>(brojKartice);

                    if (d == null) return null;

                    var racunPregled = new RacunPregled(d.Racun.BrojRacuna);
                    return new DebitnaPregled(d.BrojKartice, d.DatumIsteka, d.DatumIzdavanja, racunPregled, d.DnevniLimit);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static void dodajDebitnuKarticu(DebitnaBasic d)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var racun = s.Load<proejkt.Entiteti.Racun>(d.Racun.BrojRacuna);

                    var nova = new proejkt.Entiteti.Debitna
                    {
                        DatumIsteka = d.DatumIsteka,
                        DatumIzdavanja = d.DatumIzdavanja,
                        Racun = racun,
                        DnevniLimit = d.DnevniLimit
                    };

                    s.SaveOrUpdate(nova);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void azurirajDebitnuKarticu(DebitnaBasic d)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var kartica = s.Get<proejkt.Entiteti.Debitna>(d.BrojKartice);

                    if (kartica == null) return;

                    kartica.DatumIsteka = d.DatumIsteka;
                    kartica.DatumIzdavanja = d.DatumIzdavanja;
                    kartica.DnevniLimit = d.DnevniLimit;

                    var racun = s.Load<proejkt.Entiteti.Racun>(d.Racun.BrojRacuna);
                    kartica.Racun = racun;

                    s.Update(kartica);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiDebitnuKarticu(string brojKartice)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var kartica = s.Get<proejkt.Entiteti.Debitna>(brojKartice);

                    if (kartica == null) return;

                    s.Delete(kartica);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        #region Kreditna

        public static List<KreditnaPregled> vratiSveKreditneKartice()
        {
            List<KreditnaPregled> kreditne = new List<KreditnaPregled>();
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var sveKreditne = s.Query<proejkt.Entiteti.Kreditna>();

                    foreach (var k in sveKreditne)
                    {
                        var racunPregled = new RacunPregled(k.Racun.BrojRacuna);
                        kreditne.Add(new KreditnaPregled(
                            k.BrojKartice,
                            k.DatumIsteka,
                            k.DatumIzdavanja,
                            racunPregled,
                            k.MesecniLimit,
                            k.MaxPeriodOtplate
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return kreditne;
        }

        public static KreditnaPregled vratiKreditnuKarticu(string brojKartice)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var k = s.Get<proejkt.Entiteti.Kreditna>(brojKartice);

                    if (k == null) return null;

                    var racunPregled = new RacunPregled(k.Racun.BrojRacuna);
                    return new KreditnaPregled(
                        k.BrojKartice,
                        k.DatumIsteka,
                        k.DatumIzdavanja,
                        racunPregled,
                        k.MesecniLimit,
                        k.MaxPeriodOtplate
                    );
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void dodajKreditnuKarticu(KreditnaBasic k)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var racun = s.Load<proejkt.Entiteti.Racun>(k.Racun.BrojRacuna);

                    var nova = new proejkt.Entiteti.Kreditna
                    {
                        DatumIsteka = k.DatumIsteka,
                        DatumIzdavanja = k.DatumIzdavanja,
                        Racun = racun,
                        MesecniLimit = k.MesecniLimit,
                        MaxPeriodOtplate = k.MaxPeriodOtplate
                    };

                    s.SaveOrUpdate(nova);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        public static void azurirajKreditnuKarticu(KreditnaBasic k)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var kartica = s.Get<proejkt.Entiteti.Kreditna>(k.BrojKartice);

                    if (kartica == null) return;

                    kartica.DatumIsteka = k.DatumIsteka;
                    kartica.DatumIzdavanja = k.DatumIzdavanja;
                    kartica.MesecniLimit = k.MesecniLimit;
                    kartica.MaxPeriodOtplate = k.MaxPeriodOtplate;

                    var racun = s.Load<proejkt.Entiteti.Racun>(k.Racun.BrojRacuna);
                    kartica.Racun = racun;

                    s.Update(kartica);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void obrisiKreditnuKarticu(string brojKartice)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var kartica = s.Get<proejkt.Entiteti.Kreditna>(brojKartice);

                    if (kartica == null) return;

                    s.Delete(kartica);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        #endregion

        #region Racun

        public static List<RacunPregled> vratiSveRacune()
        {
            List<RacunPregled> racuni = new List<RacunPregled>();
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var sviRacuni = s.Query<proejkt.Entiteti.Racun>();

                    foreach (var r in sviRacuni)
                    {
                        var klijentPregled = new KlijentPregled(r.Klijent.IdKlijenta);
                        var bankaPregled = new BankaPregled(r.Banka.Id);
                        racuni.Add(new RacunPregled(r.BrojRacuna, r.Status, r.Valuta, r.DatumOtvaranja, r.TrenutniSaldo, klijentPregled, bankaPregled));
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            return racuni;
        }

        public static RacunPregled vratiRacun(int brojRacuna)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var r = s.Get<proejkt.Entiteti.Racun>(brojRacuna);
                    if (r == null) return null;

                    var klijentPregled = new KlijentPregled(r.Klijent.IdKlijenta);
                    var bankaPregled = new BankaPregled(r.Banka.Id);

                    return new RacunPregled(r.BrojRacuna, r.Status, r.Valuta, r.DatumOtvaranja, r.TrenutniSaldo, klijentPregled, bankaPregled);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void dodajRacun(RacunBasic r)
        {
            try
            {   
                using (ISession s = DataLayer.GetSession())
                {
                    var klijent = s.Load<proejkt.Entiteti.Klijent>(r.Klijent.IdKlijenta);
                    var banka = s.Load<proejkt.Entiteti.Banka>(r.Banka.Id);

                    var novi = new proejkt.Entiteti.Racun
                    {
                        Status = r.Status,
                        Valuta = r.Valuta,
                        DatumOtvaranja = r.DatumOtvaranja,
                        TrenutniSaldo = r.TrenutniSaldo,
                        Klijent = klijent,
                        Banka = banka
                    };

                    s.SaveOrUpdate(novi);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void azurirajRacun(RacunBasic r)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var racun = s.Get<proejkt.Entiteti.Racun>(r.BrojRacuna);
                    if (racun == null) return;

                    racun.Status = r.Status;
                    racun.Valuta = r.Valuta;
                    racun.DatumOtvaranja = r.DatumOtvaranja;
                    racun.TrenutniSaldo = r.TrenutniSaldo;

                    var klijent = s.Load<proejkt.Entiteti.Klijent>(r.Klijent.IdKlijenta);
                    var banka = s.Load<proejkt.Entiteti.Banka>(r.Banka.Id);

                    racun.Klijent = klijent;
                    racun.Banka = banka;

                    s.Update(racun);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void obrisiRacun(int brojRacuna)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var racun = s.Get<proejkt.Entiteti.Racun>(brojRacuna);
                    if (racun == null) return;

                    s.Delete(racun);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
              
            }
        }

        #endregion

        #region Uredjaj

        public static List<UredjajPregled> vratiSveUredjaje()
        {
            List<UredjajPregled> uredjaji = new List<UredjajPregled>();

            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var sviUredjaji = s.Query<proejkt.Entiteti.Uredjaj>();

                    foreach(var u in sviUredjaji)
                    {
                        var filijalaPregled = new FilijalaPregled(u.Filijala.RedniBroj);
                        var bankaPregled = new BankaPregled(u.Banka.Id);

                        uredjaji.Add(new UredjajPregled(
                            u.IdUredjaja,
                            u.Proizvodjac,
                            u.StatusRada,
                            u.PoslednjiServis,
                            u.DatumInstalacije,
                            u.DodatniKomentar,
                            u.Adresa,
                            u.GPS,
                            filijalaPregled,
                            bankaPregled));
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return uredjaji;
        }

        public static UredjajPregled vratiUredjaj(int idUredjaja)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var u = s.Get<proejkt.Entiteti.Uredjaj>(idUredjaja);

                    if (u == null) return null;

                    var filijalaPregled = new FilijalaPregled(u.Filijala.RedniBroj);
                    var bankaPregled = new BankaPregled(u.Banka.Id);

                    return new UredjajPregled(u.IdUredjaja, u.Proizvodjac, u.StatusRada, u.PoslednjiServis,
                                u.DatumInstalacije, u.DodatniKomentar, u.Adresa, u.GPS, filijalaPregled, bankaPregled);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static List<TransakcijaPregled> vratiTransakcijeZaUredjaj(int idUredjaja)
        {
            List<TransakcijaPregled> transakcije = new List<TransakcijaPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var lista = s.Query<proejkt.Entiteti.Transakcija>()
                                 .Where(t => t.Uredjaj.IdUredjaja == idUredjaja);

                    foreach (var t in lista)
                    {
                        var karticaPregled = new KarticaPregled(t.Kartica.BrojKartice);
                        var uredjajPregled = new UredjajPregled(t.Uredjaj.IdUredjaja);

                        transakcije.Add(new TransakcijaPregled(
                            t.IdTransakcije,
                            t.Valuta,
                            t.Datum,
                            t.Status,
                            t.Iznos,
                            t.RazlogNeuspeha,
                            t.Vreme,
                            t.VrstaTransakcije,
                            karticaPregled,
                            uredjajPregled));
                    }
                }
            }
            catch { }

            return transakcije;
        }

        public static void dodajUredjaj(UredjajBasic u)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var filijala = s.Load<proejkt.Entiteti.Filijala>(u.Filijala.RedniBroj);
                    var banka = s.Load<proejkt.Entiteti.Banka>(u.Banka.Id);

                    var novi = new proejkt.Entiteti.Uredjaj
                    {
                        Proizvodjac = u.Proizvodjac,
                        StatusRada = u.StatusRada,
                        PoslednjiServis = u.PoslednjiServis,
                        DatumInstalacije = u.DatumInstalacije,
                        DodatniKomentar = u.DodatniKomentar,
                        Adresa = u.Adresa,
                        GPS = u.GPS,
                        Filijala = filijala,
                        Banka = banka
                    };

                    s.SaveOrUpdate(novi);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void azurirajUredjaj(UredjajBasic u)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var uredjaj = s.Get<proejkt.Entiteti.Uredjaj>(u.IdUredjaja);

                    if (uredjaj == null) return;

                    uredjaj.Proizvodjac = u.Proizvodjac;
                    uredjaj.StatusRada = u.StatusRada;
                    uredjaj.PoslednjiServis = u.PoslednjiServis;
                    uredjaj.DatumInstalacije = u.DatumInstalacije;
                    uredjaj.DodatniKomentar = u.DodatniKomentar;
                    uredjaj.Adresa = u.Adresa;
                    uredjaj.GPS = u.GPS;

                    var filijala = s.Load<proejkt.Entiteti.Filijala>(u.Filijala.RedniBroj);
                    var banka = s.Load<proejkt.Entiteti.Banka>(u.Banka.Id);

                    uredjaj.Filijala = filijala;
                    uredjaj.Banka = banka;

                    s.Update(uredjaj);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiUredjaj(int idUredjaja)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var uredjaj = s.Get<proejkt.Entiteti.Uredjaj>(idUredjaja);

                    if (uredjaj == null) return;

                    s.Delete(uredjaj);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        #region UplatniAutomat

        public static List<UplatniAutomatPregled> vratiSveUplatneAutomate()
        {
            List<UplatniAutomatPregled> aparati = new List<UplatniAutomatPregled>();

            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var sviAparati = s.Query<proejkt.Entiteti.UplatniAutomat>();

                    foreach(var u in sviAparati)
                    {
                        var filijalaPregled = new FilijalaPregled(u.Filijala.RedniBroj);
                        var bankaPregled = new BankaPregled(u.Banka.Id);

                        aparati.Add(new UplatniAutomatPregled(
                             u.IdUredjaja,
                            u.Proizvodjac,
                            u.StatusRada,
                            u.PoslednjiServis,
                            u.DatumInstalacije,
                            u.DodatniKomentar,
                            u.Adresa,
                            u.GPS,
                            filijalaPregled,
                            bankaPregled,
                            u.VrstaUplate,
                            u.Validator));
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return aparati;
        }

        public static UplatniAutomatPregled vratiUplatniAutomat(int idUredjaja)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var u = s.Get<proejkt.Entiteti.UplatniAutomat>(idUredjaja);

                    if (u == null) return null;

                    var filijalaPregled = new FilijalaPregled(u.Filijala.RedniBroj);
                    var bankaPregled = new BankaPregled(u.Banka.Id);

                    return new UplatniAutomatPregled(
                        u.IdUredjaja,
                        u.Proizvodjac,
                        u.StatusRada,
                        u.PoslednjiServis,
                        u.DatumInstalacije,
                        u.DodatniKomentar,
                        u.Adresa,
                        u.GPS,
                        filijalaPregled,
                        bankaPregled,
                        u.VrstaUplate,
                        u.Validator);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static void dodajUplatniAutomat(UplatniAutomatBasic u)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var filijala = s.Load<proejkt.Entiteti.Filijala>(u.Filijala.RedniBroj);
                    var banka = s.Load<proejkt.Entiteti.Banka>(u.Banka.Id);

                    var novi = new proejkt.Entiteti.UplatniAutomat
                    {
                        Proizvodjac = u.Proizvodjac,
                        StatusRada = u.StatusRada,
                        PoslednjiServis = u.PoslednjiServis,
                        DatumInstalacije = u.DatumInstalacije,
                        DodatniKomentar = u.DodatniKomentar,
                        Adresa = u.Adresa,
                        GPS = u.GPS,
                        Filijala = filijala,
                        Banka = banka,
                        VrstaUplate = u.VrstaUplate,
                        Validator = u.Validator
                    };

                    s.SaveOrUpdate(novi);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void azurirajUplatniAutomat(UplatniAutomatBasic u)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var automat = s.Get<proejkt.Entiteti.UplatniAutomat>(u.IdUredjaja);

                    if (automat == null) return;

                    automat.Proizvodjac = u.Proizvodjac;
                    automat.StatusRada = u.StatusRada;
                    automat.PoslednjiServis = u.PoslednjiServis;
                    automat.DatumInstalacije = u.DatumInstalacije;
                    automat.DodatniKomentar = u.DodatniKomentar;
                    automat.Adresa = u.Adresa;
                    automat.GPS = u.GPS;
                    automat.VrstaUplate = u.VrstaUplate;
                    automat.Validator = u.Validator;

                    var filijala = s.Load<proejkt.Entiteti.Filijala>(u.Filijala.RedniBroj);
                    var banka = s.Load<proejkt.Entiteti.Banka>(u.Banka.Id);

                    automat.Filijala = filijala;
                    automat.Banka = banka;

                    s.Update(automat);
                    s.Flush();

                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiUplatniAutomat(int idUredjaja)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var automat = s.Get<proejkt.Entiteti.UplatniAutomat>(idUredjaja);

                    if (automat == null) return;

                    s.Delete(automat);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        #region Kiosk
        
        public static List<KioskPregled> vratiSveKioske()
        {
            List<KioskPregled> kiosci = new List<KioskPregled>();

            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var sviKiosci = s.Query<proejkt.Entiteti.Kiosk>();

                    foreach(var k in sviKiosci)
                    {
                        var filijalaPregled = new FilijalaPregled(k.Filijala.RedniBroj);
                        var bankaPregled = new BankaPregled(k.Banka.Id);

                        kiosci.Add(new KioskPregled(
                            k.IdUredjaja,
                            k.Proizvodjac,
                            k.StatusRada,
                            k.PoslednjiServis,
                            k.DatumInstalacije,
                            k.DodatniKomentar,
                            k.Adresa,
                            k.GPS,
                            filijalaPregled,
                            bankaPregled,
                            k.Skener,
                            k.Stampac
                        ));
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return kiosci;
        }


        public static KioskPregled vratiKiosk(int idUredjaja)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var k = s.Get<proejkt.Entiteti.Kiosk>(idUredjaja);

                    if (k == null) return null;

                    var filijalaPregled = new FilijalaPregled(k.Filijala.RedniBroj);
                    var bankaPregled = new BankaPregled(k.Banka.Id);

                    return new KioskPregled(
                        k.IdUredjaja,
                        k.Proizvodjac,
                        k.StatusRada,
                        k.PoslednjiServis,
                        k.DatumInstalacije,
                        k.DodatniKomentar,
                        k.Adresa,
                        k.GPS,
                        filijalaPregled,
                        bankaPregled,
                        k.Skener,
                        k.Stampac);

                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static void dodajKiosk(KioskBasic k)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var filijala = s.Load<proejkt.Entiteti.Filijala>(k.Filijala.RedniBroj);
                    var banka = s.Load<proejkt.Entiteti.Banka>(k.Banka.Id);

                    var novi = new proejkt.Entiteti.Kiosk
                    {
                        Proizvodjac = k.Proizvodjac,
                        StatusRada = k.StatusRada,
                        PoslednjiServis = k.PoslednjiServis,
                        DatumInstalacije = k.DatumInstalacije,
                        DodatniKomentar = k.DodatniKomentar,
                        Adresa = k.Adresa,
                        GPS = k.GPS,
                        Filijala = filijala,
                        Banka = banka,
                        Skener = k.Skener,
                        Stampac = k.Stampac
                    };

                    s.SaveOrUpdate(novi);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void azurirajKiosk(KioskBasic k)
        {
            try
            {
                using(ISession s=DataLayer.GetSession())
                {
                    var kiosk = s.Get<proejkt.Entiteti.Kiosk>(k.IdUredjaja);

                    if (kiosk == null) return;

                    kiosk.Proizvodjac = k.Proizvodjac;
                    kiosk.StatusRada = k.StatusRada;
                    kiosk.PoslednjiServis = k.PoslednjiServis;
                    kiosk.DatumInstalacije = k.DatumInstalacije;
                    kiosk.DodatniKomentar = k.DodatniKomentar;
                    kiosk.Adresa = k.Adresa;
                    kiosk.GPS = k.GPS;
                    kiosk.Skener = k.Skener;
                    kiosk.Stampac = k.Stampac;

                    var filijala = s.Load<proejkt.Entiteti.Filijala>(k.Filijala.RedniBroj);
                    var banka = s.Load<proejkt.Entiteti.Banka>(k.Banka.Id);

                    kiosk.Filijala = filijala;
                    kiosk.Banka = banka;

                    s.Update(kiosk);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiKiosk(int idUredjaja)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var kiosk = s.Get<proejkt.Entiteti.Kiosk>(idUredjaja);

                    if (kiosk == null) return;

                    s.Delete(kiosk);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        #region Bankomat


        public static void dodajBankomat(BankomatBasic b)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var filijala = s.Load<proejkt.Entiteti.Filijala>(b.Filijala.RedniBroj);
                    var banka = s.Load<proejkt.Entiteti.Banka>(b.Banka.Id);

                    var novi = new proejkt.Entiteti.Bankomat
                    {
                        Proizvodjac = b.Proizvodjac,
                        StatusRada = b.StatusRada,
                        PoslednjiServis = b.PoslednjiServis,
                        DatumInstalacije = b.DatumInstalacije,
                        DodatniKomentar = b.DodatniKomentar,
                        Adresa = b.Adresa,
                        GPS = b.GPS,
                        Filijala = filijala,
                        Banka = banka,
                        MaxIznos = b.MaxIznos,
                        BrojNovcanica = b.BrojNovcanica
                    };

                    s.SaveOrUpdate(novi);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska kod dodajBankomat: " + ex.Message);
            }
        }
        public static List<BankomatPregled> vratiSveBankomate()
        {
            List<BankomatPregled> bankomati = new List<BankomatPregled>();

            try
            {
                using(ISession s= DataLayer.GetSession())
                {
                    var sviBankomati = s.Query<proejkt.Entiteti.Bankomat>();

                    foreach(var b in sviBankomati)
                    {
                        var filijalaPregled = new FilijalaPregled(b.Filijala.RedniBroj);
                        var bankaPregled = new BankaPregled(b.Banka.Id);

                        bankomati.Add(new BankomatPregled(
                            b.IdUredjaja,
                            b.Proizvodjac,
                            b.StatusRada,
                            b.PoslednjiServis,
                            b.DatumInstalacije,
                            b.DodatniKomentar,
                            b.Adresa,
                            b.GPS,
                            filijalaPregled,
                            bankaPregled,
                            b.MaxIznos,
                            b.BrojNovcanica
                        ));
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return bankomati;
        }

        public static BankomatPregled vratiBankomat(int idUredjaja)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var b = s.Get<proejkt.Entiteti.Bankomat>(idUredjaja);

                    if (b == null) return null;

                    var filijalaPregled = new FilijalaPregled(b.Filijala.RedniBroj);
                    var bankaPregled = new BankaPregled(b.Banka.Id);

                    return new BankomatPregled(
                        b.IdUredjaja,
                        b.Proizvodjac,
                        b.StatusRada,
                        b.PoslednjiServis,
                        b.DatumInstalacije,
                        b.DodatniKomentar,
                        b.Adresa,
                        b.GPS,
                        filijalaPregled,
                        bankaPregled,
                        b.MaxIznos,
                        b.BrojNovcanica
                    );
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static void azurirajBankomat(BankomatBasic b)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var bankomat = s.Get<proejkt.Entiteti.Bankomat>(b.IdUredjaja);
                    if (bankomat == null) return;

                    bankomat.Proizvodjac = b.Proizvodjac;
                    bankomat.StatusRada = b.StatusRada;
                    bankomat.PoslednjiServis = b.PoslednjiServis;
                    bankomat.DatumInstalacije = b.DatumInstalacije;
                    bankomat.DodatniKomentar = b.DodatniKomentar;
                    bankomat.Adresa = b.Adresa;
                    bankomat.GPS = b.GPS;
                    bankomat.MaxIznos = b.MaxIznos;
                    bankomat.BrojNovcanica = b.BrojNovcanica;

                    var filijala = s.Load<proejkt.Entiteti.Filijala>(b.Filijala.RedniBroj);
                    var banka = s.Load<proejkt.Entiteti.Banka>(b.Banka.Id);

                    bankomat.Filijala = filijala;
                    bankomat.Banka = banka;


                    s.Update(bankomat);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiBankomat(int idUredjaja)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var bankomat = s.Get<proejkt.Entiteti.Bankomat>(idUredjaja);
                    if (bankomat == null) return;

                    s.Delete(bankomat);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        #region Banka

        public static List<BankaPregled> vratiSveBanke()
        {
            List<BankaPregled> banke = new List<BankaPregled>();

            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var sveBanke = s.Query<proejkt.Entiteti.Banka>();
                    foreach (var b in sveBanke)
                    {
                        banke.Add(new BankaPregled(
                            b.Id,
                            b.Naziv,
                            b.Email,
                            b.AdresaCentrale,
                            b.WebAdresa,
                            b.BrojTelefona
                        ));
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return banke;
        }

        public static BankaPregled vratiBanku(int id)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var b = s.Get<proejkt.Entiteti.Banka>(id);

                    if (b == null) return null;

                    return new BankaPregled(
                        b.Id,
                        b.Naziv,
                        b.Email,
                        b.AdresaCentrale,
                        b.WebAdresa,
                        b.BrojTelefona);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static List<FilijalaPregled> vratiFilijaleZaBanku(int bankaId)
        {
            List<FilijalaPregled> filijale = new List<FilijalaPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var sveFilijale = s.Query<proejkt.Entiteti.Filijala>()
                                         .Where(f => f.Banka.Id == bankaId);

                    foreach (var f in sveFilijale)
                    {
                        var bankaPregled = new BankaPregled(f.Banka.Id);
                        filijale.Add(new FilijalaPregled(
                            f.RedniBroj,
                            f.Adresa,
                            f.RadniDan,
                            f.Subota,
                            f.Nedelja,
                            bankaPregled
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return filijale;
        }

        public static List<UredjajPregled> vratiUredjajZaBanku(int idBanke)
        {
            List<UredjajPregled> uredjaji = new List<UredjajPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var lista = s.Query<proejkt.Entiteti.Uredjaj>()
                                 .Where(u => u.Banka.Id == idBanke);

                    foreach (var u in lista)
                    {
                        var filijalaPregled = new FilijalaPregled(u.Filijala.RedniBroj);
                        var bankaPregled = new BankaPregled(u.Banka.Id);

                        uredjaji.Add(new UredjajPregled(
                            u.IdUredjaja,
                            u.Proizvodjac,
                            u.StatusRada,
                            u.PoslednjiServis,
                            u.DatumInstalacije,
                            u.DodatniKomentar,
                            u.Adresa,
                            u.GPS,
                            filijalaPregled,
                            bankaPregled));
                    }
                }
            }
            catch { }

            return uredjaji;
        }

        public static List<RacunPregled> vratiRacuneZaBanku(int idBanke)
        {
            List<RacunPregled> racuni = new List<RacunPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var lista = s.Query<proejkt.Entiteti.Racun>()
                                 .Where(r => r.Banka.Id == idBanke);

                    foreach (var r in lista)
                    {
                        var klijentPregled = new KlijentPregled(r.Klijent.IdKlijenta);
                        var bankaPregled = new BankaPregled(r.Banka.Id);
                        racuni.Add(new RacunPregled(
                            r.BrojRacuna,
                            r.Status,
                            r.Valuta,
                            r.DatumOtvaranja,
                            r.TrenutniSaldo,
                            klijentPregled,
                            bankaPregled));
                    }
                }
            }
            catch { }

            return racuni;
        }

        public static void dodajBanku(BankaBasic b)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var nova = new proejkt.Entiteti.Banka
                    {
                        Naziv = b.Naziv,
                        Email = b.Email,
                        AdresaCentrale = b.AdresaCentrale,
                        WebAdresa = b.WebAdresa,
                        BrojTelefona = b.BrojTelefona
                    };

                    s.SaveOrUpdate(nova);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void azurirajBanku(BankaBasic b)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var banka = s.Get<proejkt.Entiteti.Banka>(b.Id);

                    if (banka == null) return;

                    banka.Naziv = b.Naziv;
                    banka.Email = b.Email;
                    banka.AdresaCentrale = b.AdresaCentrale;
                    banka.WebAdresa = b.WebAdresa;
                    banka.BrojTelefona = b.BrojTelefona;

                    s.Update(banka);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiBanku(int id)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var banka = s.Get<proejkt.Entiteti.Banka>(id);

                    if (banka == null) return;

                    s.Delete(banka);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        #region Filijala

        public static List<FilijalaPregled> vratiSveFilijale()
        {
            List<FilijalaPregled> filijale = new List<FilijalaPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var sveFilijale = s.Query<proejkt.Entiteti.Filijala>();

                    foreach (var f in sveFilijale)
                    {
                        filijale.Add(new FilijalaPregled(
                            f.RedniBroj,
                            f.Adresa,
                            f.RadniDan,
                            f.Subota,
                            f.Nedelja,
                            new BankaPregled(f.Banka.Id)
                        ));
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return filijale;
        }

        public static FilijalaPregled vratiFilijalu(int id)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var f = s.Get<proejkt.Entiteti.Filijala>(id);

                    if (f == null) return null;

                    return new FilijalaPregled(
                        f.RedniBroj,
                        f.Adresa,
                        f.RadniDan,
                        f.Subota,
                        f.Nedelja,
                        new BankaPregled(f.Banka.Id)
                        );
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static List<UredjajPregled> vratiUredjajZaFilijalu(int redniBrojFilijale)
        {
            List<UredjajPregled> uredjaji = new List<UredjajPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var lista = s.Query<proejkt.Entiteti.Uredjaj>()
                                 .Where(u => u.Filijala.RedniBroj == redniBrojFilijale);

                    foreach (var u in lista)
                    {
                        var filijalaPregled = new FilijalaPregled(u.Filijala.RedniBroj);
                        var bankaPregled = new BankaPregled(u.Banka.Id);

                        uredjaji.Add(new UredjajPregled(
                            u.IdUredjaja,
                            u.Proizvodjac,
                            u.StatusRada,
                            u.PoslednjiServis,
                            u.DatumInstalacije,
                            u.DodatniKomentar,
                            u.Adresa,
                            u.GPS,
                            filijalaPregled,
                            bankaPregled));
                    }
                }
            }
            catch { }

            return uredjaji;
        }

        public static void dodajFilijalu(FilijalaBasic f)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var banka = s.Load<proejkt.Entiteti.Banka>(f.Banka.Id);

                    var nova = new proejkt.Entiteti.Filijala
                    {
                        Adresa = f.Adresa,
                        RadniDan = f.RadniDan,
                        Subota = f.Subota,
                        Nedelja = f.Nedelja,
                        Banka = banka
                    };

                    s.SaveOrUpdate(nova);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void azurirajFilijalu(FilijalaBasic f)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var filijala = s.Get<proejkt.Entiteti.Filijala>(f.RedniBroj);

                    if (filijala == null) return;

                    filijala.Adresa = f.Adresa;
                    filijala.RadniDan = f.RadniDan;
                    filijala.Subota = f.Subota;
                    filijala.Nedelja = f.Nedelja;

                    var banka = s.Load<proejkt.Entiteti.Banka>(f.Banka.Id);
                    filijala.Banka = banka;

                    s.Update(filijala);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiFilijalu(int redniBroj)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var filijala = s.Get<proejkt.Entiteti.Filijala>(redniBroj);

                    if (filijala == null) return;

                    s.Delete(filijala);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        #region PodrzaniServisi

        public static List<PodrzaniServisiPregled> vratiSveServise()
        {
            List<PodrzaniServisiPregled> servisi = new List<PodrzaniServisiPregled>();

            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var sviServisi = s.Query<proejkt.Entiteti.PodrzaniServisi>();

                    foreach(var p in sviServisi)
                    {
                        var uredjajPregled = new UredjajPregled(p.Uredjaj.IdUredjaja);

                        servisi.Add(new PodrzaniServisiPregled(
                            p.Id,
                            uredjajPregled,
                            p.Servis));
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return servisi;
        }

        public static PodrzaniServisiPregled vratiServis(int id)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var p = s.Get<proejkt.Entiteti.PodrzaniServisi>(id);

                    if (p == null) return null;

                    var uredjajPregled = new UredjajPregled(p.Uredjaj.IdUredjaja);

                    return new PodrzaniServisiPregled(p.Id, uredjajPregled, p.Servis);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static void dodajServis(PodrzaniServisiBasic p)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var uredjaj = s.Load<proejkt.Entiteti.Uredjaj>(p.Uredjaj.IdUredjaja);

                    var novi = new proejkt.Entiteti.PodrzaniServisi
                    {
                        Servis = p.Servis,
                        Uredjaj = uredjaj
                    };

                    s.SaveOrUpdate(novi);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void azurirajServis(PodrzaniServisiBasic p)
        {
            try
            {
                using(ISession s = DataLayer.GetSession())
                {
                    var servis = s.Get<proejkt.Entiteti.PodrzaniServisi>(p.Id);
                    if (servis == null) return;

                    servis.Servis = p.Servis;
                    var uredjaj = s.Load<proejkt.Entiteti.Uredjaj>(p.Uredjaj.IdUredjaja);
                    servis.Uredjaj = uredjaj;

                    s.Update(servis);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void obrisiServis(int id)
        {
            try
            {
                using(ISession s= DataLayer.GetSession())
                {
                    var servis = s.Get<proejkt.Entiteti.PodrzaniServisi>(id);

                    if (servis == null) return;

                    s.Delete(servis);
                    s.Flush();
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        #region BrojTelefona

        public static List<BrojTelefonaPregled> vratiSveBrojeve()
        {
            List<BrojTelefonaPregled> brojevi = new List<BrojTelefonaPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var sviBrojevi = s.Query<proejkt.Entiteti.BrojTelefona>();
                    foreach (var b in sviBrojevi)
                    {
                        var klijentPregled = new KlijentPregled(b.Klijent.IdKlijenta);

                        brojevi.Add(new BrojTelefonaPregled(
                            b.Id,
                            klijentPregled,
                            b.Telefon
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return brojevi;
        }

        public static BrojTelefonaPregled vratiBroj(int id)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var b = s.Get<proejkt.Entiteti.BrojTelefona>(id);
                    if (b == null) return null;

                    var klijentPregled = new KlijentPregled(b.Klijent.IdKlijenta);

                    return new BrojTelefonaPregled(
                        b.Id,
                        klijentPregled,
                        b.Telefon
                    );
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void dodajBroj(BrojTelefonaBasic b)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var klijent = s.Load<proejkt.Entiteti.Klijent>(b.Klijent.IdKlijenta);

                    var novi = new proejkt.Entiteti.BrojTelefona
                    {
                        Telefon = b.Telefon,
                        Klijent = klijent
                    };

                    s.SaveOrUpdate(novi);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void azurirajBroj(BrojTelefonaBasic b)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var broj = s.Get<proejkt.Entiteti.BrojTelefona>(b.Id);
                    if (broj == null) return;

                    broj.Telefon = b.Telefon;
                    var klijent = s.Load<proejkt.Entiteti.Klijent>(b.Klijent.IdKlijenta);
                    broj.Klijent = klijent;

                    s.Update(broj);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void obrisiBroj(int id)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var broj = s.Get<proejkt.Entiteti.BrojTelefona>(id);
                    if (broj == null) return;

                    s.Delete(broj);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region TelefonFilijala

        public static List<TelefonFilijalePregled> vratiSveTelefoneFilijale()
        {
            List<TelefonFilijalePregled> telefoni = new List<TelefonFilijalePregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var sviTelefoni = s.Query<proejkt.Entiteti.TelefonFilijale>();
                    foreach (var t in sviTelefoni)
                    {
                        var filijalaPregled = new FilijalaPregled(t.Filijala.RedniBroj);

                        telefoni.Add(new TelefonFilijalePregled(
                            t.Id,
                            filijalaPregled,
                            t.Telefon
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return telefoni;
        }

        public static TelefonFilijalePregled vratiTelefonFilijale(int id)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var t = s.Get<proejkt.Entiteti.TelefonFilijale>(id);
                    if (t == null) return null;

                    var filijalaPregled = new FilijalaPregled(t.Filijala.RedniBroj);

                    return new TelefonFilijalePregled(
                        t.Id,
                        filijalaPregled,
                        t.Telefon
                    );
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void dodajTelefonFilijale(TelefonFilijaleBasic t)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var filijala = s.Load<proejkt.Entiteti.Filijala>(t.Filijala.RedniBroj);

                    var novi = new proejkt.Entiteti.TelefonFilijale
                    {
                        Telefon = t.Telefon,
                        Filijala = filijala
                    };

                    s.SaveOrUpdate(novi);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void azurirajTelefonFilijale(TelefonFilijaleBasic t)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var telefon = s.Get<proejkt.Entiteti.TelefonFilijale>(t.Id);
                    if (telefon == null) return;

                    telefon.Telefon = t.Telefon;

                    var filijala = s.Load<proejkt.Entiteti.Filijala>(t.Filijala.RedniBroj);
                    telefon.Filijala = filijala;

                    s.Update(telefon);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void obrisiTelefonFilijale(int id)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var telefon = s.Get<proejkt.Entiteti.TelefonFilijale>(id);
                    if (telefon == null) return;

                    s.Delete(telefon);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Transakcije

        public static List<TransakcijaPregled> vratiSveTransakcije()
        {
            List<TransakcijaPregled> transakcije = new List<TransakcijaPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var sve = s.Query<proejkt.Entiteti.Transakcija>();

                    foreach (var t in sve)
                    {
                        var uredjajPregled = new UredjajPregled(t.Uredjaj.IdUredjaja);
                        var karticaPregled = new KarticaPregled(t.Kartica.BrojKartice);

                        transakcije.Add(new TransakcijaPregled(
                            t.IdTransakcije,
                            t.Valuta,
                            t.Datum,
                            t.Status,
                            t.Iznos,
                            t.RazlogNeuspeha,
                            t.Vreme,
                            t.VrstaTransakcije,
                            karticaPregled,
                            uredjajPregled
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return transakcije;
        }

        public static TransakcijaPregled vratiTransakciju(int idTransakcije)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var t = s.Get<proejkt.Entiteti.Transakcija>(idTransakcije);
                    if (t == null) return null;

                    var karticaPregled = new KarticaPregled(t.Kartica.BrojKartice);
                    var uredjajPregled = new UredjajPregled(t.Uredjaj.IdUredjaja);

                    return new TransakcijaPregled(
                        t.IdTransakcije,
                        t.Valuta,
                        t.Datum,
                        t.Status,
                        t.Iznos,
                        t.RazlogNeuspeha,
                        t.Vreme,
                        t.VrstaTransakcije,
                        karticaPregled,
                        uredjajPregled
                    );
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public static void dodajTransakciju(TransakcijaBasic t)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var kartica = s.Load<proejkt.Entiteti.Kartica>(t.Kartica.BrojKartice);
                    var uredjaj = s.Load<proejkt.Entiteti.Uredjaj>(t.Uredjaj.IdUredjaja);

                    var nova = new proejkt.Entiteti.Transakcija
                    {
                        Valuta = t.Valuta,
                        Datum = t.Datum,
                        Status = t.Status,
                        Iznos = t.Iznos,
                        RazlogNeuspeha = t.RazlogNeuspeha,
                        Vreme = t.Vreme,
                        VrstaTransakcije = t.VrstaTransakcije,
                        Kartica = kartica,
                        Uredjaj = uredjaj
                    };

                    s.SaveOrUpdate(nova);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void azurirajTransakciju(TransakcijaBasic t)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var transakcija = s.Get<proejkt.Entiteti.Transakcija>(t.IdTransakcije);
                    if (transakcija == null) return;

                    transakcija.Valuta = t.Valuta;
                    transakcija.Datum = t.Datum;
                    transakcija.Status = t.Status;
                    transakcija.Iznos = t.Iznos;
                    transakcija.RazlogNeuspeha = t.RazlogNeuspeha;
                    transakcija.Vreme = t.Vreme;
                    transakcija.VrstaTransakcije = t.VrstaTransakcije;

                    var kartica = s.Load<proejkt.Entiteti.Kartica>(t.Kartica.BrojKartice);
                    var uredjaj = s.Load<proejkt.Entiteti.Uredjaj>(t.Uredjaj.IdUredjaja);

                    transakcija.Kartica = kartica;
                    transakcija.Uredjaj = uredjaj;

                    s.Update(transakcija);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }


        public static void obrisiTransakciju(int idTransakcije)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var transakcija = s.Get<proejkt.Entiteti.Transakcija>(idTransakcije);
                    if (transakcija == null) return;

                    s.Delete(transakcija);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

    }
    }
