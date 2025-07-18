using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class Racun
    {

        public virtual string BrojRacuna { get; protected set; }

        public virtual string Status { get; set; }

        public virtual string Valuta { get; set; }

        public virtual DateTime DatumOtvaranja { get; set; }

        public virtual decimal TrenutniSaldo { get; set; }


        public virtual IList<Kartica> Kartice { get; set; }

        public virtual Klijent Klijent { get; set; }

        public virtual Banka Banka { get; set; }

        public Racun()
        {
            Kartice = new List<Kartica>();
        }

    }
}
