using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class KioskMapiranja : SubclassMap<Kiosk>
    {
        public KioskMapiranja() 
        {
            Table("KIOSK");

            KeyColumn("ID_UREDJAJA");

            Map(el => el.Skener).Column("SKENER");
            Map(el => el.Stampac).Column("STAMPAC");
        }
    }
}
