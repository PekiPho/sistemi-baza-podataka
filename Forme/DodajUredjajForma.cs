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
    public partial class DodajUredjajForma : Form
    {
        UredjajBasic uredjaj;
        public DodajUredjajForma()
        {
            InitializeComponent();
            uredjaj = new UredjajBasic();
        }

        private void DodajUredjajForma_Load(object sender, EventArgs e)
        {
            List<FilijalaPregled> filijale = DTOManager.vratiSveFilijale();
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            foreach(var f in filijale) { comboBox1.Items.Add(f.RedniBroj); }
            List<BankaPregled> banke = DTOManager.vratiSveBanke();
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            foreach(var b in banke) { comboBox2.Items.Add(b.Id); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.uredjaj.IdUredjaja = int.Parse(textBox1.Text);
            this.uredjaj.Proizvodjac = textBox2.Text;
            this.uredjaj.StatusRada = textBox3.Text;
            this.uredjaj.PoslednjiServis = dateTimePicker1.Value;
            this.uredjaj.DatumInstalacije = dateTimePicker2.Value;
            this.uredjaj.DodatniKomentar = textBox4.Text;
            this.uredjaj.Adresa = textBox5.Text;
            this.uredjaj.GPS = textBox6.Text;
            int odabraniBrojFilijale = (int)comboBox1.SelectedItem;
            this.uredjaj.Filijala = new FilijalaBasic(odabraniBrojFilijale, "", "", "", "", null);
            int odabraniIdBanke = (int)comboBox2.SelectedItem;
            this.uredjaj.Banka = new BankaBasic(odabraniIdBanke, "", "", "", "", "");
            DTOManager.dodajUredjaj(this.uredjaj);
            MessageBox.Show("Uspesno ste dodali novi uredjaj!");
            this.Close();
        }
    }
}
