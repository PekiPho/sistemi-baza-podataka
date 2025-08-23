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
    public partial class DodajPravnaLicaForma : Form
    {
        PravnaLicaBasic plica;
        public DodajPravnaLicaForma()
        {
            InitializeComponent();
            plica = new PravnaLicaBasic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.plica.IdKlijenta = int.Parse(textBox1.Text);
            this.plica.PIB = textBox2.Text;
            this.plica.NazivFirme = textBox3.Text;
            this.plica.Kontakt = textBox4.Text;
            this.plica.MaticniBroj = textBox5.Text;
            this.plica.Delatnost = textBox6.Text;
            this.plica.Adresa = textBox7.Text;
            this.plica.KontaktPodaci = textBox8.Text;
            DTOManager.dodajPravnoLice(plica);
            MessageBox.Show("Uspesno ste dodali novo pravno lice!");
            this.Close();
        }
    }
}
