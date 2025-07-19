using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg.XmlHbmBinding;
using proejkt.Entiteti;
using FluentNHibernate.Mapping;

namespace proejkt.Mapiranje
{
    class BankaMapiranja : ClassMap<Banka>
    {
        public BankaMapiranja() 
        {
            Table("BANKA");

            Id(el => el.Id).Column("ID_BANKE").GeneratedBy.TriggerIdentity();

            Map(el => el.Naziv).Column("NAZIV");
            Map(el => el.Email).Column("EMAIL");
            Map(el => el.AdresaCentrale).Column("ADRESA_CENTRALE");
            Map(el => el.WebAdresa).Column("WEB_ADRESA");
            Map(el => el.BrojTelefona).Column("BROJ_TELEFONA");

            HasMany(el => el.Racuni).KeyColumn("BANKAID").Cascade.All().Inverse();

            HasMany(el => el.Uredjaji).KeyColumn("BANKAID").Cascade.All().Inverse();

            HasMany(el => el.Filijale).KeyColumn("BANKAID").Cascade.All().Inverse();
        }
    }
}
