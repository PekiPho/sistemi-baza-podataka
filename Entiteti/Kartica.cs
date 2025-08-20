using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class Kartica
    {
        public virtual string BrojKartice { get; set; }

        public virtual DateTime DatumIsteka { get; set; }

        public virtual DateTime DatumIzdavanja { get; set; }

        public virtual Racun Racun { get; set; }

        public virtual IList<Transakcija> Transakcije { get; set; }


        public Kartica()
        {
            Transakcije = new List<Transakcija>();
        }
    }
}
