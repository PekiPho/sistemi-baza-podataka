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
    public partial class DodajKreditnuForma : Form
    {
        KreditnaBasic kreditna;
        public DodajKreditnuForma()
        {
            InitializeComponent();
            kreditna = new KreditnaBasic();
        }

        private void DodajKreditnuForma_Load(object sender, EventArgs e)
        {
            List<RacunPregled> racuni = DTOManager.vratiSveRacune();

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();

            foreach (var r in racuni)
            {
                comboBox1.Items.Add(r.BrojRacuna);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.kreditna.BrojKartice = textBox1.Text;
            this.kreditna.DatumIsteka = dateTimePicker1.Value;
            this.kreditna.DatumIzdavanja = dateTimePicker2.Value;
            string odabraniBrojRacuna = comboBox1.SelectedItem.ToString();
            this.kreditna.Racun = new RacunBasic(odabraniBrojRacuna, "", "", DateTime.Now, 0);
            this.kreditna.MesecniLimit = decimal.Parse(textBox2.Text);
            this.kreditna.MaxPeriodOtplate = int.Parse(textBox3.Text);
            DTOManager.dodajKreditnuKarticu(kreditna);
            MessageBox.Show("Uspesno ste dodali novu debitnu karticu!");
            this.Close();
        }
    }
}
