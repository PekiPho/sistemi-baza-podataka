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
    public partial class IzmeniKarticuForma : Form
    {
        KarticaBasic kartica;
        public IzmeniKarticuForma()
        {
            InitializeComponent();
        }
        public IzmeniKarticuForma(KarticaBasic k)
        {
            InitializeComponent();
            this.kartica = k;
        }

        private void IzmeniKarticuForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE KARTICE {kartica.BrojKartice.ToUpper()}";

            List<RacunPregled> racuni = DTOManager.vratiSveRacune();

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();

            foreach (var r in racuni)
            {
                comboBox1.Items.Add(r.BrojRacuna);
            }
        }
        public void popuniPodacima()
        {
            textBox1.Text = kartica.BrojKartice;
            textBox1.Enabled = false;
            dateTimePicker1.Value = kartica.DatumIsteka;
            dateTimePicker2.Value = kartica.DatumIzdavanja;
            comboBox1.SelectedItem = kartica.Racun.BrojRacuna;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene kartice?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if(result == DialogResult.OK)
            {
                kartica.DatumIsteka = dateTimePicker1.Value;
                kartica.DatumIzdavanja = dateTimePicker2.Value;
                kartica.Racun = new RacunBasic(comboBox1.SelectedItem.ToString(),"","",DateTime.Now,0);
                DTOManager.azurirajKarticu(kartica);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }

        }
    }
}
