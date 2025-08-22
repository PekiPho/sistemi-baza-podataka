using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class TelefonFilijale
    {
        public virtual int Id { get; set; }
        public virtual Filijala Filijala { get; set; }

        public virtual string Telefon { get; set; }
    }
}
