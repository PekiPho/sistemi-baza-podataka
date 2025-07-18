using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class UplatniAutomat:Uredjaj
    {
        public virtual string VrstaUplate { get; set; }

        public virtual string Validator { get; set; }
    }
}
