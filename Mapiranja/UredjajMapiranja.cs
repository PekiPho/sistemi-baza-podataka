using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proejkt.Entiteti;
using FluentNHibernate.Mapping;

namespace proejkt.Mapiranja
{
    class UredjajMapiranja : ClassMap<Uredjaj>
    {
        public UredjajMapiranja()
        {
            Table("UREDJAJ");

            Id(el => el.IdUredjaja).Column("ID_UREDJAJA").GeneratedBy.TriggerIdentity();

            Map(el => el.Proizvodjac).Column("PROIZVODJAC");
            Map(el => el.StatusRada).Column("STATUS_RADA");
            Map(el => el.PoslednjiServis).Column("POSLEDNJI_SERVIS");
            Map(el => el.DatumInstalacije).Column("DATUM_INSTALACIJE");
            Map(el => el.DodatniKomentar).Column("DODATNI_KOMENTAR");
            Map(el => el.Adresa).Column("ADRESA");
            Map(el => el.GPS).Column("GPS");

            References(el => el.Filijala).Column("FILIJALAID").LazyLoad();
            References(el => el.Banka).Column("BANKAID").LazyLoad();

            HasMany(el => el.Transakcije).KeyColumn("UREDJAJID").Cascade.All().Inverse();
        }
    }
}
