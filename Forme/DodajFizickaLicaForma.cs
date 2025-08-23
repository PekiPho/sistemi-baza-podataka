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
    public partial class DodajFizickaLicaForma : Form
    {
        FizickaLicaBasic flica;
        public DodajFizickaLicaForma()
        {
            InitializeComponent();
            flica = new FizickaLicaBasic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.flica.IdKlijenta = int.Parse(textBox1.Text);
            this.flica.JMBG = textBox2.Text;
            this.flica.MestoIzdavanja = textBox3.Text;
            this.flica.Adresa = textBox4.Text;
            this.flica.DatumRodjenja = dateTimePicker1.Value;
            this.flica.BrojLicneKarte = textBox5.Text;
            this.flica.LicnoIme = textBox6.Text;
            this.flica.ImeRoditelja = textBox7.Text;
            this.flica.Prezime = textBox8.Text;
            DTOManager.dodajFizickoLice(flica);
            MessageBox.Show("Uspesno ste dodali novo fizicko lice!");
            this.Close();
        }
    }
}
