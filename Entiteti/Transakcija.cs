using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class Transakcija
    {
        public virtual int IdTransakcije { get; set; }

        public virtual string  Valuta { get; set; }

        public virtual DateTime Datum { get; set; }

        public virtual string Status { get; set; }

        public virtual decimal Iznos { get; set; }

        public virtual string RazlogNeuspeha { get; set; }

        public virtual string Vreme { get; set; }

        public virtual string VrstaTransakcije { get; set; }


        public virtual Kartica Kartica { get; set; }

        public virtual Uredjaj Uredjaj { get; set; }


    }
}
