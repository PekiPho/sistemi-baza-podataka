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

namespace proejkt.Forme
{
    public partial class IzmeniBankuForma : Form
    {
        BankaBasic banka;
        public IzmeniBankuForma()
        {
            InitializeComponent();
        }
        public IzmeniBankuForma(BankaBasic b)
        {
            InitializeComponent();
            this.banka = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene banke?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                banka.Naziv = textBox2.Text;
                banka.Email = textBox3.Text;
                banka.AdresaCentrale = textBox4.Text;
                banka.WebAdresa = textBox5.Text;
                banka.BrojTelefona = textBox6.Text;
                DTOManager.azurirajBanku(banka);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }

        private void IzmeniBankuForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE BANKE {banka.Id.ToString().ToUpper()}";
        }
        
        public void popuniPodacima()
        {
            textBox1.Text = banka.Id.ToString();
            textBox1.Enabled = false;
            textBox2.Text = banka.Naziv;
            textBox3.Text = banka.Email;
            textBox4.Text = banka.AdresaCentrale;
            textBox5.Text = banka.WebAdresa;
            textBox6.Text = banka.BrojTelefona;
        }
    }
}
