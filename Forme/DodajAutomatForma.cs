using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentNHibernate.Automapping;
using proejkt.Entiteti;

namespace proejkt.Forme
{
    public partial class DodajAutomatForma : Form
    {
        UplatniAutomatBasic automat;
        public DodajAutomatForma()
        {
            InitializeComponent();
            automat = new UplatniAutomatBasic();
        }

        private void DodajAutomatForma_Load(object sender, EventArgs e)
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
            this.automat.IdUredjaja = int.Parse(textBox1.Text);
            this.automat.Proizvodjac = textBox2.Text;
            this.automat.StatusRada = textBox3.Text;
            this.automat.PoslednjiServis = dateTimePicker1.Value;
            this.automat.DatumInstalacije = dateTimePicker2.Value;
            this.automat.DodatniKomentar = textBox4.Text;
            this.automat.Adresa = textBox5.Text;
            this.automat.GPS = textBox6.Text;
            int odabraniBrojFilijale = (int)comboBox1.SelectedItem;
            this.automat.Filijala = new FilijalaBasic(odabraniBrojFilijale, "", "", "", "", null);
            int odabraniIdBanke = (int)comboBox2.SelectedItem;
            this.automat.Banka = new BankaBasic(odabraniIdBanke, "", "", "", "", "");
            this.automat.VrstaUplate = textBox7.Text;
            this.automat.Validator = textBox8.Text;
            DTOManager.dodajUplatniAutomat(automat);
            MessageBox.Show("Uspesno ste dodali novi automat!");
            this.Close();
        }
    }
}
