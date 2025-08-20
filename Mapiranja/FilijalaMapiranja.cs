using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class FilijalaMapiranja : ClassMap<Filijala>
    {
        public FilijalaMapiranja() 
        {
            Id(el => el.RedniBroj).Column("REDNI_BROJ").GeneratedBy.Assigned();

            Map(el => el.Adresa).Column("ADRESA");
            Map(el => el.RadniDan).Column("RADNI_DAN");
            Map(el => el.Subota).Column("SUBOTA");
            Map(el => el.Nedelja).Column("NEDELJA");

            References(el => el.Banka).Column("BANKAID").LazyLoad();

            HasMany(el => el.Uredjaji).KeyColumn("FILIJALAID").Cascade.All().Inverse();
            HasMany(el => el.Telefoni).KeyColumn("REDNI_BROJ").Cascade.All().Inverse();
        }
    }
}
