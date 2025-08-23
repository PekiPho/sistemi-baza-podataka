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
    public partial class DodajKlijentaForma : Form
    {
        KlijentBasic klijent;
        public DodajKlijentaForma()
        {
            InitializeComponent();
            klijent = new KlijentBasic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.klijent.IdKlijenta = int.Parse(textBox1.Text);
            DTOManager.dodajKlijenta(klijent);
            MessageBox.Show("Uspesno ste dodali novog klijenta!");
            this.Close();
        }
    }
}
