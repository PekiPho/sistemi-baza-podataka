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
    public partial class DodajBankuForma : Form
    {
        BankaBasic banka;
        public DodajBankuForma()
        {
            InitializeComponent();
            banka = new BankaBasic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.banka.Id = int.Parse(textBox1.Text);
            this.banka.Naziv = textBox2.Text;
            this.banka.Email = textBox3.Text;
            this.banka.AdresaCentrale = textBox4.Text;
            this.banka.WebAdresa = textBox5.Text;
            this.banka.BrojTelefona = textBox6.Text;
            DTOManager.dodajBanku(this.banka);
            MessageBox.Show("Uspesno ste dodali novu banku!");
            this.Close();
        }
    }
}
