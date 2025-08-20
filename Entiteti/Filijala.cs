using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class Filijala
    {
        public virtual int RedniBroj { get; set; }

        public virtual string Adresa { get; set; }

        public virtual string RadniDan { get; set; }

        public virtual string Subota { get; set; }

        public virtual string Nedelja { get; set; }

        public virtual Banka Banka { get; set; }

        public virtual IList<Uredjaj> Uredjaji { get; set; }

        public virtual IList<TelefonFilijale> Telefoni { get; set; }

        public Filijala()
        {
            Uredjaji = new List<Uredjaj>();
            Telefoni = new List<TelefonFilijale>();
        }
    }
}
