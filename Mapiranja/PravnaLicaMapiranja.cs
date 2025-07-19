using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using proejkt.Entiteti;

namespace proejkt.Mapiranja
{
    class PravnaLicaMapiranja : SubclassMap<PravnaLica>
    {
        public PravnaLicaMapiranja()
        {
            Table("PRAVNA_LICA");

            KeyColumn("ID_KLIJENTA");

            Map(el => el.PIB).Column("PIB");
            Map(el => el.NazivFirme).Column("NAZIV_FIRME");
            Map(el => el.Kontakt).Column("KONTAKT");
            Map(el => el.MaticniBroj).Column("MATICNI_BROJ");
            Map(el => el.Delatnost).Column("DELATNOST");
            Map(el => el.Adresa).Column("ADRESA");
            Map(el => el.KontaktPodaci).Column("KONTAKT_PODACI");
        }
    }
}
