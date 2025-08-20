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
    public partial class IzmeniRacunForma : Form
    {
        RacunBasic racun;
        public IzmeniRacunForma()
        {
            InitializeComponent();
        }
        public IzmeniRacunForma(RacunBasic r)
        {
            InitializeComponent();
            this.racun = r;
        }

        private void IzmeniRacunForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE RACUNA {racun.BrojRacuna.ToUpper()}";

            List<KlijentPregled> klijenti = DTOManager.vratiSveKlijente();

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();

            foreach (var k in klijenti)
            {
                comboBox1.Items.Add(k.IdKlijenta);
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            List<BankaPregled> banke = DTOManager.vratiSveBanke();

            comboBox2.DataSource = null;
            comboBox2.Items.Clear();

            foreach (var b in banke)
            {
                comboBox2.Items.Add(b.Id);
            }

            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }
        public void popuniPodacima()
        {
            textBox1.Text = racun.BrojRacuna;
            textBox1.Enabled = false;
            textBox2.Text = racun.Status;
            textBox3.Text = racun.Valuta;
            dateTimePicker1.Value = racun.DatumOtvaranja;
            textBox4.Text = racun.TrenutniSaldo.ToString();
            comboBox1.SelectedItem = racun.Klijent.IdKlijenta;
            comboBox2.SelectedItem = racun.Banka.Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene racuna?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                racun.Status = textBox2.Text;
                racun.Valuta = textBox3.Text;
                racun.DatumOtvaranja = dateTimePicker1.Value;
                racun.TrenutniSaldo = decimal.Parse(textBox4.Text);
                racun.Klijent = new KlijentBasic((int)comboBox1.SelectedItem);
                racun.Banka = new BankaBasic((int)comboBox2.SelectedItem,"","","","","");
                DTOManager.azurirajRacun(racun);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }
    }
}
