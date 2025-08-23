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
    public partial class IzmeniPravnaLicaForma : Form
    {
        PravnaLicaBasic plica;
        public IzmeniPravnaLicaForma()
        {
            InitializeComponent();
        }
        public IzmeniPravnaLicaForma(PravnaLicaBasic p)
        {
            InitializeComponent();
            this.plica = p;
        }
        private void IzmeniPravnaLicaForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE PRAVNOG LICA {plica.IdKlijenta.ToString().ToUpper()}";
        }
        public void popuniPodacima()
        {
            textBox1.Text = plica.IdKlijenta.ToString();
            textBox1.Enabled = false;
            textBox2.Text = plica.PIB;
            textBox3.Text = plica.NazivFirme;
            textBox4.Text = plica.Kontakt;
            textBox5.Text = plica.MaticniBroj;
            textBox6.Text = plica.Delatnost;
            textBox7.Text = plica.Adresa;
            textBox8.Text = plica.KontaktPodaci;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene pravnog lica?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                plica.PIB = textBox2.Text;
                plica.NazivFirme = textBox3.Text;
                plica.Kontakt = textBox4.Text;
                plica.MaticniBroj = textBox5.Text;
                plica.Delatnost = textBox6.Text;
                plica.Adresa = textBox7.Text;
                plica.KontaktPodaci = textBox8.Text;
                DTOManager.azurirajPravnoLice(plica);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }
    }
}
