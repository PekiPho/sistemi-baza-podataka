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
    public partial class DodajRacunForma : Form
    {
        RacunBasic racun;
        public DodajRacunForma()
        {
            InitializeComponent();
            racun = new RacunBasic();
        }

        private void DodajRacunForma_Load(object sender, EventArgs e)
        {
            List<KlijentPregled> klijenti = DTOManager.vratiSveKlijente();

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();

            foreach (var k in klijenti)
            {
                comboBox1.Items.Add(k.IdKlijenta);
            }

            List<BankaPregled> banke = DTOManager.vratiSveBanke();

            comboBox2.DataSource = null;
            comboBox2.Items.Clear();

            foreach (var b in banke)
            {
                comboBox2.Items.Add(b.Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.racun.BrojRacuna = textBox1.Text;
            this.racun.Status = textBox2.Text;
            this.racun.Valuta = textBox3.Text;
            this.racun.DatumOtvaranja = dateTimePicker1.Value;
            this.racun.TrenutniSaldo = decimal.Parse(textBox4.Text);
            int odabraniIdKlijenta = (int)comboBox1.SelectedItem;
            this.racun.Klijent = new KlijentBasic(odabraniIdKlijenta);
            int  odabraniIdBanke = (int)comboBox2.SelectedItem;
            this.racun.Banka = new BankaBasic(odabraniIdBanke, "", "", "", "", "");
            DTOManager.dodajRacun(this.racun);
            MessageBox.Show("Uspesno ste dodali novu transakciju!");
            this.Close();
        }
    }
}
