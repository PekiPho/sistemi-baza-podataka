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
    public partial class DodajOrganizacijuForma : Form
    {
        OrganizacijaBasic organizacija;
        public DodajOrganizacijuForma()
        {
            InitializeComponent();
            organizacija = new OrganizacijaBasic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.organizacija.IdKlijenta = int.Parse(textBox1.Text);
            this.organizacija.Registar = textBox2.Text;
            this.organizacija.Tip = textBox3.Text;
            this.organizacija.Osnivac = textBox4.Text;
            this.organizacija.KontaktPodaci = textBox5.Text;
            this.organizacija.Adresa = textBox6.Text;
            DTOManager.dodajOrganizaciju(organizacija);
            MessageBox.Show("Uspesno ste dodali novu organizaciju!");
            this.Close();
        }
    }
}
