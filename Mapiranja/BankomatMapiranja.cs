using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class BankomatMapiranja : SubclassMap<Bankomat>
    {
        public BankomatMapiranja()
        {
            Table("BANKOMAT");

            KeyColumn("ID_UREDJAJA");

            Map(el => el.MaxIznos).Column("MAX_IZNOS");
            Map(el => el.BrojNovcanica).Column("BROJ_NOVCANICA");
        }
    }
}
