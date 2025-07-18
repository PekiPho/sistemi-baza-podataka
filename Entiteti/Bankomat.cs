using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class Bankomat:Uredjaj
    {
        public virtual decimal MaxIznos { get; set; }

        public virtual int BrojNovcanica { get; set; }
    }
}
