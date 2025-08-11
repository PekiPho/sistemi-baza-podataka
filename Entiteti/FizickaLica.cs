using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    class FizickaLica:Klijent
    {

        public virtual string JMBG { get; set; }

        public virtual string MestoIzdavanja { get; set; }

        public virtual string Adresa { get; set; }

        public virtual DateTime DatumRodjenja { get; set; }

        public virtual string BrojLicneKarte { get; set; }

        public virtual string LicnoIme { get; set; }

        public virtual string ImeRoditelja { get; set; }

        public virtual string Prezime { get; set; }

        public virtual IList<BrojTelefona> BrojeviTelefona { get; set; }


        public FizickaLica()
        {
            BrojeviTelefona = new List<BrojTelefona>();
        }
    }
}
