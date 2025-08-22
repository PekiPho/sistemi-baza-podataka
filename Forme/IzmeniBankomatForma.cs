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
    public partial class IzmeniBankomatForma : Form
    {
        BankomatBasic bankomat;
        public IzmeniBankomatForma()
        {
            InitializeComponent();
        }
        public IzmeniBankomatForma(BankomatBasic b)
        {
            InitializeComponent();
            this.bankomat = b;
        }
        public void popuniPodacima()
        {
            textBox1.Text = bankomat.IdUredjaja.ToString();
            textBox1.Enabled = false;
            textBox2.Text = bankomat.Proizvodjac;
            textBox3.Text = bankomat.StatusRada;
            dateTimePicker1.Value = bankomat.PoslednjiServis;
            dateTimePicker2.Value = bankomat.DatumInstalacije;
            textBox4.Text = bankomat.DodatniKomentar;
            textBox5.Text = bankomat.Adresa;
            textBox6.Text = bankomat.GPS;
            comboBox1.SelectedItem = bankomat.Filijala.RedniBroj;
            comboBox2.SelectedItem = bankomat.Banka.Id;
            textBox7.Text = bankomat.MaxIznos.ToString();
            textBox8.Text = bankomat.BrojNovcanica.ToString();
        }

        private void IzmeniBankomatForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE BANKOMATA {bankomat.IdUredjaja.ToString().ToUpper()}";
            List<FilijalaPregled> filijala = DTOManager.vratiSveFilijale();
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            foreach (var f in filijala) { comboBox1.Items.Add(f.RedniBroj); }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            List<BankaPregled> banke = DTOManager.vratiSveBanke();
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            foreach (var b in banke) { comboBox2.Items.Add(b.Id); }
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene bankomata?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                bankomat.Proizvodjac = textBox2.Text;
                bankomat.StatusRada = textBox3.Text;
                bankomat.PoslednjiServis = dateTimePicker1.Value;
                bankomat.DatumInstalacije = dateTimePicker2.Value;
                bankomat.DodatniKomentar = textBox4.Text;
                bankomat.Adresa = textBox5.Text;
                bankomat.GPS = textBox6.Text;
                bankomat.Filijala = new FilijalaBasic((int)comboBox1.SelectedItem, "", "", "", "", null);
                bankomat.Banka = new BankaBasic((int)comboBox2.SelectedItem, "", "", "", "", "");
                bankomat.MaxIznos = decimal.Parse(textBox7.Text);
                bankomat.BrojNovcanica = int.Parse(textBox8.Text);
                DTOManager.azurirajBankomat(bankomat);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }
    }
}
