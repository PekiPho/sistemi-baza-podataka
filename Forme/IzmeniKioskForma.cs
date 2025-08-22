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
    public partial class IzmeniKioskForma : Form
    {
        KioskBasic kiosk;
        public IzmeniKioskForma()
        {
            InitializeComponent();
        }
        public IzmeniKioskForma(KioskBasic k)
        {
            InitializeComponent();
            this.kiosk = k;
        }
        public void popuniPodacima()
        {
            textBox1.Text = kiosk.IdUredjaja.ToString();
            textBox1.Enabled = false;
            textBox2.Text = kiosk.Proizvodjac;
            textBox3.Text = kiosk.StatusRada;
            dateTimePicker1.Value = kiosk.PoslednjiServis;
            dateTimePicker2.Value = kiosk.DatumInstalacije;
            textBox4.Text = kiosk.DodatniKomentar;
            textBox5.Text = kiosk.Adresa;
            textBox6.Text = kiosk.GPS;
            comboBox1.SelectedItem = kiosk.Filijala.RedniBroj;
            comboBox2.SelectedItem = kiosk.Banka.Id;
            textBox7.Text = kiosk.Skener;
            textBox8.Text = kiosk.Stampac;
        }

        private void IzmeniKioskForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE KIOSKA {kiosk.IdUredjaja.ToString().ToUpper()}";
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
            string poruka = "Da li zelite da izvrsite izmene kioska?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                kiosk.Proizvodjac = textBox2.Text;
                kiosk.StatusRada = textBox3.Text;
                kiosk.PoslednjiServis = dateTimePicker1.Value;
                kiosk.DatumInstalacije = dateTimePicker2.Value;
                kiosk.DodatniKomentar = textBox4.Text;
                kiosk.Adresa = textBox5.Text;
                kiosk.GPS = textBox6.Text;
                kiosk.Filijala = new FilijalaBasic((int)comboBox1.SelectedItem, "", "", "", "", null);
                kiosk.Banka = new BankaBasic((int)comboBox2.SelectedItem, "", "", "", "", "");
                kiosk.Skener = textBox7.Text;
                kiosk.Stampac = textBox8.Text;
                DTOManager.azurirajKiosk(kiosk);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }
    }
}
