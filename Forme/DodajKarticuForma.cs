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
    public partial class DodajKarticuForma : Form
    {
        KarticaBasic kartica;
        public DodajKarticuForma()
        {
            InitializeComponent();
            kartica = new KarticaBasic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.kartica.BrojKartice = textBox1.Text;
            this.kartica.DatumIsteka = dateTimePicker1.Value;
            this.kartica.DatumIzdavanja = dateTimePicker2.Value;
            string odabraniBrojRacuna = comboBox1.SelectedItem.ToString();
            this.kartica.Racun = new RacunBasic(odabraniBrojRacuna, "", "", DateTime.Now, 0);
            DTOManager.dodajKarticu(this.kartica);
            MessageBox.Show("Uspesno ste dodali novu karticu!");
            this.Close();
        }

        private void DodajKarticuForma_Load(object sender, EventArgs e)
        {
            List<RacunPregled> racuni = DTOManager.vratiSveRacune();

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();

            foreach (var r in racuni)
            {
                comboBox1.Items.Add(r.BrojRacuna);
            }

        }
    }
}
