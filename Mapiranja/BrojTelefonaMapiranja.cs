using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class BrojTelefonaMapiranja : ClassMap<BrojTelefona>
    {
        public BrojTelefonaMapiranja()
        {
            Table("BROJ_TELEFONA");

            Id(el => el.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(el => el.Telefon).Column("BROJ_TELEFONA");

            References(el => el.Klijent).Column("ID_KLIJENTA").LazyLoad();
        } 

    }
}
