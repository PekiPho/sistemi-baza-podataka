using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class Kiosk:Uredjaj
    {

        public virtual string Skener { get; set; }

        public virtual string Stampac { get; set; }
    }
}
