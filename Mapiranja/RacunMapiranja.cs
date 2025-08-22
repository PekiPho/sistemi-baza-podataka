using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class RacunMapiranja : ClassMap<Racun>
    {
        public RacunMapiranja() 
        {
            Table("RACUN");

            Id(el => el.BrojRacuna).Column("BROJ_RACUNA").GeneratedBy.Assigned();

            Map(el => el.Status).Column("STATUS");
            Map(el => el.Valuta).Column("VALUTA");
            Map(el => el.DatumOtvaranja).Column("DATUM_OTVARANJA");
            Map(el => el.TrenutniSaldo).Column("TRENUTNI_SALDO");

            References(el => el.Klijent).Column("KLIJENTID").LazyLoad();
            References(el => el.Banka).Column("BANKAID").LazyLoad();

            HasMany(el => el.Kartice).KeyColumn("RACUNBR").Cascade.All().Inverse();
        }
    }
}
