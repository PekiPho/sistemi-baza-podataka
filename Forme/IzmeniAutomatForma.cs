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
    public partial class IzmeniAutomatForma : Form
    {
        UplatniAutomatBasic automat;
        public IzmeniAutomatForma()
        {
            InitializeComponent();
        }
        public IzmeniAutomatForma(UplatniAutomatBasic a)
        {
            InitializeComponent();
            this.automat = a;
        }
        public void popuniPodacima()
        {
            textBox1.Text = automat.IdUredjaja.ToString();
            textBox1.Enabled = false;
            textBox2.Text = automat.Proizvodjac;
            textBox3.Text = automat.StatusRada;
            dateTimePicker1.Value = automat.PoslednjiServis;
            dateTimePicker2.Value = automat.DatumInstalacije;
            textBox4.Text = automat.DodatniKomentar;
            textBox5.Text = automat.Adresa;
            textBox6.Text = automat.GPS;
            comboBox1.SelectedItem = automat.Filijala.RedniBroj;
            comboBox2.SelectedItem = automat.Banka.Id;
            textBox7.Text = automat.VrstaUplate;
            textBox8.Text = automat.Validator;
        }

        private void IzmeniAutomatForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE AUTOMATA {automat.IdUredjaja.ToString().ToUpper()}";
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
            string poruka = "Da li zelite da izvrsite izmene automata?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                automat.Proizvodjac = textBox2.Text;
                automat.StatusRada = textBox3.Text;
                automat.PoslednjiServis = dateTimePicker1.Value;
                automat.DatumInstalacije = dateTimePicker2.Value;
                automat.DodatniKomentar = textBox4.Text;
                automat.Adresa = textBox5.Text;
                automat.GPS = textBox6.Text;
                automat.Filijala = new FilijalaBasic((int)comboBox1.SelectedItem, "", "", "", "", null);
                automat.Banka = new BankaBasic((int)comboBox2.SelectedItem, "", "", "", "", "");
                automat.VrstaUplate = textBox7.Text;
                automat.Validator = textBox8.Text;
                DTOManager.azurirajUplatniAutomat(automat);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }
    }
}
