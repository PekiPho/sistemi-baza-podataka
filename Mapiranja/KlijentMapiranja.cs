using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class KlijentMapiranja : ClassMap<Klijent>
    {
        public KlijentMapiranja() 
        {
            Table("KLIJENT");

            Id(el => el.IdKlijenta).Column("ID_KLIJENTA").GeneratedBy.Assigned();

            HasMany(el => el.Racuni).KeyColumn("KLIJENTID").Cascade.All().Inverse();
        }
    }
}
