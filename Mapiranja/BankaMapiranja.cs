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
    class BankaMapiranje : ClassMap<Banka>
    {
        public BankaMapiranje() 
        {
            Table("BANKA");

            Id(el => el.Id, "ID_BANKE").GeneratedBy.TriggerIdentity();

            Map(el => el.Naziv, "NAZIV");
            Map(el => el.Email, "EMAIL");
            Map(el => el.AdresaCentrale, "ADRESA_CENTRALE");
            Map(el => el.WebAdresa, "WEB_ADRESA");
            Map(el => el.BrojTelefona, "BROJ_TELEFONA");
        }
    }
}
