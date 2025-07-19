using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class KreditnaMapiranja : SubclassMap<Kreditna>
    {
        public KreditnaMapiranja() 
        {
            Table("KREDITNA");

            KeyColumn("BROJ_KARTICE");

            Map(el => el.MesecniLimit).Column("MESECNI_LIMIT");
            Map(el => el.MaxPeriodOtplate).Column("MAX_PERIOD_OTPLATE");
        }
    }
}
