using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class Organizacije:Klijent
    {

        public virtual string Registar { get; set; }

        public virtual string Tip { get; set; }

        public virtual string  Osnivac { get; set; }

        public virtual string KontaktPodaci { get; set; }

        public virtual string Adresa { get; set; }
    }
}
