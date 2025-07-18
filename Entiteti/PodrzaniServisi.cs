using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class PodrzaniServisi
    {
        public virtual int Id { get; protected set; }

        public virtual Uredjaj Uredjaj { get; set; }

        public virtual string Servis { get; set; }
    }
}
