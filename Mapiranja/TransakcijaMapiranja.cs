using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class TransakcijaMapiranja : ClassMap<Transakcija>
    {
        public TransakcijaMapiranja() 
        {
            Table("TRANSAKCIJA");

            Id(el => el.IdTransakcije).Column("ID_TRANSAKCIJE").GeneratedBy.TriggerIdentity();

            Map(el => el.Valuta).Column("VALUTA");
            Map(el => el.Datum).Column("DATUM");
            Map(el => el.Status).Column("STATUS");
            Map(el => el.Iznos).Column("IZNOS");
            Map(el => el.RazlogNeuspeha).Column("RAZLOG_NEUSPEHA");
            Map(el => el.Vreme).Column("VREME");
            Map(el => el.VrstaTransakcije).Column("VRSTA_TRANSAKCIJE");

            References(el => el.Kartica).Column("KARTICABR").LazyLoad();
            References(el => el.Uredjaj).Column("UREDJAJID").LazyLoad();
        }
    }
}
