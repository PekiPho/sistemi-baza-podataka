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
    public partial class IzmeniUredjajForma : Form
    {
        UredjajBasic uredjaj;
        public IzmeniUredjajForma()
        {
            InitializeComponent();
        }
        public IzmeniUredjajForma(UredjajBasic u)
        {
            InitializeComponent();
            this.uredjaj = u;
        }

        private void IzmeniUredjajForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE UREDJAJA {uredjaj.IdUredjaja.ToString().ToUpper()}";

            List<FilijalaPregled> filijala = DTOManager.vratiSveFilijale();
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            foreach(var f in filijala) { comboBox1.Items.Add(f.RedniBroj); }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            List<BankaPregled> banke = DTOManager.vratiSveBanke();
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            foreach(var b in banke) { comboBox2.Items.Add(b.Id); }
            if(comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }
        public void popuniPodacima()
        {
            textBox1.Text = uredjaj.IdUredjaja.ToString();
            textBox1.Enabled = false;
            textBox2.Text = uredjaj.Proizvodjac;
            textBox3.Text = uredjaj.StatusRada;
            dateTimePicker1.Value = uredjaj.PoslednjiServis;
            dateTimePicker2.Value = uredjaj.DatumInstalacije;
            textBox4.Text = uredjaj.DodatniKomentar;
            textBox5.Text = uredjaj.Adresa;
            textBox6.Text = uredjaj.GPS;
            comboBox1.SelectedItem = uredjaj.Filijala.RedniBroj;
            comboBox2.SelectedItem = uredjaj.Banka.Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene uredjaja?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                uredjaj.Proizvodjac = textBox2.Text;
                uredjaj.StatusRada = textBox3.Text;
                uredjaj.PoslednjiServis = dateTimePicker1.Value;
                uredjaj.DatumInstalacije = dateTimePicker2.Value;
                uredjaj.DodatniKomentar = textBox4.Text;
                uredjaj.Adresa = textBox5.Text;
                uredjaj.GPS = textBox6.Text;
                uredjaj.Filijala = new FilijalaBasic((int)comboBox1.SelectedItem, "", "", "", "", null);
                uredjaj.Banka = new BankaBasic((int)comboBox2.SelectedItem, "", "", "", "", "");
                DTOManager.azurirajUredjaj(uredjaj);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }
    }
}
