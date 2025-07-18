using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class BrojTelefona
    {
        public virtual int Id { get; protected set; }

        public virtual Klijent Klijent { get; set; }

        public virtual string Telefon { get; set; }
    }
}
