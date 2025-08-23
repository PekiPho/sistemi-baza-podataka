using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proejkt.Entiteti;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proejkt.Forme
{
    public partial class IzmeniOrganizacijuForma : Form
    {
        OrganizacijaBasic organizacija;
        public IzmeniOrganizacijuForma()
        {
            InitializeComponent();
        }

        public IzmeniOrganizacijuForma(OrganizacijaBasic o)
        {
            InitializeComponent();
            this.organizacija = o;
        }
        public void popuniPodacima()
        {
            textBox1.Text = organizacija.IdKlijenta.ToString();
            textBox1.Enabled = false;
            textBox2.Text = organizacija.Registar;
            textBox3.Text = organizacija.Tip;
            textBox4.Text = organizacija.Osnivac;
            textBox5.Text = organizacija.KontaktPodaci;
            textBox6.Text = organizacija.Adresa;
        }
        private void IzmeniOrganizacijuForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE ORGANIZACIJE {organizacija.IdKlijenta.ToString().ToUpper()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene organizacije?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                organizacija.Registar = textBox2.Text;
                organizacija.Tip = textBox3.Text;
                organizacija.Osnivac = textBox4.Text;
                organizacija.KontaktPodaci = textBox5.Text;
                organizacija.Adresa = textBox6.Text;
                DTOManager.azurirajOrganizaciju(organizacija);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }
    }
}
