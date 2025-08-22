using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proejkt.Forme
{
    public partial class IzmeniKlijentaForma : Form
    {
        KlijentBasic klijent;
        public IzmeniKlijentaForma()
        {
            InitializeComponent();
        }
        public IzmeniKlijentaForma(KlijentBasic k)
        {
            InitializeComponent();
            this.klijent = k;
        }
    }
}
