using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class TelefonFilijaleMapiranja : ClassMap<TelefonFilijale>
    {
        public TelefonFilijaleMapiranja ()
        {
            Table("TELEFON_FILIJALE");

            Id(el => el.Id).Column("ID").GeneratedBy.Assigned();

            Map(el => el.Telefon).Column("TELEFON_FILIJALE");

            References(el => el.Filijala).Column("REDNI_BROJ").LazyLoad();
        }
    }
}
