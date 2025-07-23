using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class FizickaLicaMapiranja : SubclassMap<FizickaLica>
    {
        public FizickaLicaMapiranja()
        {
            Table("FIZICKA_LICA");

            KeyColumn("ID_KLIJENTA");

            Map(el => el.JMBG).Column("JMBG");
            Map(el => el.MestoIzdavanja).Column("MESTO_IZDAVANJA");
            Map(el => el.Adresa).Column("ADRESA");
            Map(el => el.DatumRodjenja).Column("DATUM_RODJENJA");
            Map(el => el.BrojLicneKarte).Column("BROJ_LICNE_KARTE");
            Map(el => el.LicnoIme).Column("LICNO_IME");
            Map(el => el.ImeRoditelja).Column("IME_RODITELJA");
            Map(el => el.Prezime).Column("PREZIME");


            HasMany(el => el.BrojeviTelefona).KeyColumn("ID_KLIJENTA").Cascade.All().Inverse();
        }
    }
}
