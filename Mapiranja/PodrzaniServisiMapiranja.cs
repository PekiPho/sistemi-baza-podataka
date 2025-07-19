using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class PodrzaniServisiMapiranja : ClassMap<PodrzaniServisi>
    {
        public PodrzaniServisiMapiranja()
        {
            Table("PODRZANI_SERVISI");

            Id(el => el.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(el => el.Servis).Column("SERVIS");

            References(el => el.Uredjaj).Column("ID_UREDJAJA").LazyLoad();
        }
    }
}
