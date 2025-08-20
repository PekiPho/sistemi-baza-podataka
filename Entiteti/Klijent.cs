using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class Klijent
    {
        public virtual int IdKlijenta { get; set; }

        public virtual IList<Racun> Racuni { get; set; }

        public Klijent()
        {
            Racuni = new List<Racun>();
        }
    }
}
