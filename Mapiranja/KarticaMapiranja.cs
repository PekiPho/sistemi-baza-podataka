using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class KarticaMapiranja : ClassMap<Kartica>
    {
        public KarticaMapiranja() 
        {
            Table("KARTICA");

            Id(el => el.BrojKartice).Column("BROJ_KARTICE").GeneratedBy.Assigned();

            Map(el => el.DatumIsteka).Column("DATUM_ISTEKA");
            Map(el => el.DatumIzdavanja).Column("DATUM_IZDAVANJA");

            References(el => el.Racun).Column("RACUNBR").LazyLoad();

            HasMany(el => el.Transakcije).KeyColumn("KARTICABR").Cascade.All().Inverse();
        }
    }
}
