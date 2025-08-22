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
    public partial class DodajKioskForma : Form
    {
        KioskBasic kiosk;
        public DodajKioskForma()
        {
            InitializeComponent();
            kiosk = new KioskBasic();
        }

        private void DodajKioskForma_Load(object sender, EventArgs e)
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
            this.kiosk.IdUredjaja = int.Parse(textBox1.Text);
            this.kiosk.Proizvodjac = textBox2.Text;
            this.kiosk.StatusRada = textBox3.Text;
            this.kiosk.PoslednjiServis = dateTimePicker1.Value;
            this.kiosk.DatumInstalacije = dateTimePicker2.Value;
            this.kiosk.DodatniKomentar = textBox4.Text;
            this.kiosk.Adresa = textBox5.Text;
            this.kiosk.GPS = textBox6.Text;
            int odabraniBrojFilijale = (int)comboBox1.SelectedItem;
            this.kiosk.Filijala = new FilijalaBasic(odabraniBrojFilijale, "", "", "", "", null);
            int odabraniIdBanke = (int)comboBox2.SelectedItem;
            this.kiosk.Banka = new BankaBasic(odabraniIdBanke, "", "", "", "", "");
            this.kiosk.Skener = textBox7.Text;
            this.kiosk.Stampac = textBox8.Text;
            DTOManager.dodajKiosk(kiosk);
            MessageBox.Show("Uspesno ste dodali novi kiosk!");
            this.Close();
        }
    }
}
