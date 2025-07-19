using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class DebitnaMapiranja : SubclassMap<Debitna>
    {
        public DebitnaMapiranja() 
        {
            Table("DEBITNA");

            KeyColumn("BROJ_KARTICE");

            Map(el => el.DnevniLimit).Column("DNEVNI_LIMIT");
        }
    }
}
