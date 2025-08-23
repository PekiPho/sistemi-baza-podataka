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
    public partial class IzmeniFizickaLicaForma : Form
    {
        FizickaLicaBasic flica;
        public IzmeniFizickaLicaForma()
        {
            InitializeComponent();
        }
        public IzmeniFizickaLicaForma(FizickaLicaBasic f)
        {
            InitializeComponent();
            this.flica = f;
        }
        public void popuniPodacima()
        {
            textBox1.Text = flica.IdKlijenta.ToString();
            textBox1.Enabled = false;
            textBox2.Text = flica.JMBG;
            textBox3.Text = flica.MestoIzdavanja;
            textBox4.Text = flica.Adresa;
            dateTimePicker1.Value = flica.DatumRodjenja;
            textBox5.Text = flica.BrojLicneKarte;
            textBox6.Text = flica.LicnoIme;
            textBox7.Text = flica.ImeRoditelja;
            textBox8.Text = flica.Prezime;
        }
        private void IzmeniFizickaLicaForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE FIZICKOG LICA {flica.IdKlijenta.ToString().ToUpper()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene fizicog lica?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                flica.JMBG = textBox2.Text;
                flica.MestoIzdavanja = textBox3.Text;
                flica.Adresa = textBox4.Text;
                flica.DatumRodjenja = dateTimePicker1.Value;
                flica.BrojLicneKarte = textBox5.Text;
                flica.LicnoIme = textBox6.Text;
                flica.ImeRoditelja = textBox7.Text;
                flica.Prezime = textBox8.Text;
                DTOManager.azurirajFizickoLice(flica);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }
    }
}
