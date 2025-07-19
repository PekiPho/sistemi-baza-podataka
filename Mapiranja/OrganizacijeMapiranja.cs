using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class OrganizacijeMapiranja : SubclassMap<Organizacije>
    {
        public OrganizacijeMapiranja() 
        {
            Table("ORGANIZACIJE");

            KeyColumn("ID_KLIJENTA");

            Map(el => el.Registar).Column("REGISTAR");
            Map(el => el.Tip).Column("TIP");
            Map(el => el.Osnivac).Column("OSNIVAC");
            Map(el => el.KontaktPodaci).Column("KONTAKT_PODACI");
            Map(el => el.Adresa).Column("ADRESA");
        }
    }
}
