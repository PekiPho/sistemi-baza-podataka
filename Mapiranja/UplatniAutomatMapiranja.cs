using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class UplatniAutomatMapiranja : SubclassMap<UplatniAutomat>
    {
        public UplatniAutomatMapiranja()
        {
            Table("UPLATNI_AUTOMAT");

            KeyColumn("ID_UREDJAJA");

            Map(el => el.VrstaUplate).Column("VRSTA_UPLATE");
            Map(el => el.Validator).Column("VALIDATOR");
        }
    }
}
