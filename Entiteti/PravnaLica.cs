using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class PravnaLica:Klijent
    {

        public virtual string PIB { get; set; }

        public virtual string NazivFirme { get; set; }

        public virtual string Kontakt { get; set; }

        public virtual string MaticniBroj { get; set; }

        public virtual string Delatnost { get; set; }

        public virtual string Adresa { get; set; }

        public virtual string KontaktPodaci { get; set; }
    }
}
