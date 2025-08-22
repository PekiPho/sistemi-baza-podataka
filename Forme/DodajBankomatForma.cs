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
    public partial class DodajBankomatForma : Form
    {
        BankomatBasic bankomat;
        public DodajBankomatForma()
        {
            InitializeComponent();
            bankomat = new BankomatBasic();
        }

        private void DodajBankomatForma_Load(object sender, EventArgs e)
        {
            List<FilijalaPregled> filijale = DTOManager.vratiSveFilijale();
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            foreach (var f in filijale) { comboBox1.Items.Add(f.RedniBroj); }
            List<BankaPregled> banke = DTOManager.vratiSveBanke();
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            foreach (var b in banke) { comboBox2.Items.Add(b.Id); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.bankomat.IdUredjaja = int.Parse(textBox1.Text);
            this.bankomat.Proizvodjac = textBox2.Text;
            this.bankomat.StatusRada = textBox3.Text;
            this.bankomat.PoslednjiServis = dateTimePicker1.Value;
            this.bankomat.DatumInstalacije = dateTimePicker2.Value;
            this.bankomat.DodatniKomentar = textBox4.Text;
            this.bankomat.Adresa = textBox5.Text;
            this.bankomat.GPS = textBox6.Text;
            int odabraniBrojFilijale = (int)comboBox1.SelectedItem;
            this.bankomat.Filijala = new FilijalaBasic(odabraniBrojFilijale, "", "", "", "", null);
            int odabraniIdBanke = (int)comboBox2.SelectedItem;
            this.bankomat.Banka = new BankaBasic(odabraniIdBanke, "", "", "", "", "");
            this.bankomat.MaxIznos = decimal.Parse(textBox7.Text);
            this.bankomat.BrojNovcanica = int.Parse(textBox8.Text);
            DTOManager.dodajBankomat(bankomat);
            MessageBox.Show("Uspesno ste dodali novi bankomat!");
            this.Close();
        }
    }
}
