using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class Uredjaj
    {
        public virtual int IdUredjaja { get; set; }

        public virtual string Proizvodjac { get; set; }

        public virtual string StatusRada { get; set; }

        public virtual DateTime PoslednjiServis { get; set; }

        public virtual DateTime DatumInstalacije { get; set; }

        public virtual string DodatniKomentar { get; set; }

        public virtual string Adresa { get; set; }

        public virtual string GPS { get; set; }


        public virtual Filijala Filijala { get; set; }

        public virtual Banka Banka { get; set; }

        public virtual IList<Transakcija> Transakcije { get; set; }

        public virtual IList<PodrzaniServisi> Servisi { get; set; }


        public Uredjaj()
        {
            Transakcije = new List<Transakcija>();
            Servisi = new List<PodrzaniServisi>();
        }

    }
}
