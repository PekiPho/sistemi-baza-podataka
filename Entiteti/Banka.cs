using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class Banka
    {

        public virtual int Id { get; set; }

        public virtual string Naziv { get; set; }

        public virtual string Email { get; set; }

        public virtual string AdresaCentrale { get; set; }

        public virtual string WebAdresa { get; set; }

        public virtual string BrojTelefona { get; set; }


        public virtual IList<Racun> Racuni { get; set; }

        public virtual IList<Uredjaj> Uredjaji { get; set; }

        public virtual IList<Filijala> Filijale { get; set; }


        public Banka()
        {
            Filijale = new List<Filijala>();
            Racuni = new List<Racun>();
            Uredjaji = new List<Uredjaj>();
        }
    }
}
