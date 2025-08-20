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
    public partial class DodajDebitnuForma : Form
    {
        DebitnaBasic debitna;
        public DodajDebitnuForma()
        {
            InitializeComponent();
            debitna = new DebitnaBasic();
        }

        private void DodajDebitnuForma_Load(object sender, EventArgs e)
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
            this.debitna.BrojKartice = textBox1.Text;
            this.debitna.DatumIsteka = dateTimePicker1.Value;
            this.debitna.DatumIzdavanja = dateTimePicker2.Value;
            string odabraniBrojRacuna = comboBox1.SelectedItem.ToString();
            this.debitna.Racun = new RacunBasic(odabraniBrojRacuna, "", "", DateTime.Now, 0);
            this.debitna.DnevniLimit = decimal.Parse(textBox2.Text);
            DTOManager.dodajDebitnuKarticu(this.debitna);
            MessageBox.Show("Uspesno ste dodali novu debitnu karticu!");
            this.Close();
        }
    }
}
