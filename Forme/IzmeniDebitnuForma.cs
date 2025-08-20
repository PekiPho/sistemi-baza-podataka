using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proejkt.Forme
{
    public partial class IzmeniDebitnuForma : Form
    {
        DebitnaBasic kartica;
        public IzmeniDebitnuForma()
        {
            InitializeComponent();
        }
        public IzmeniDebitnuForma(DebitnaBasic k)
        {
            InitializeComponent();
            this.kartica = k;
        }

        private void IzmeniDebitnuForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE DEBITNE KARTICE {kartica.BrojKartice.ToUpper()}";
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
            textBox1.Enabled= false;
            dateTimePicker1.Value = kartica.DatumIsteka;
            dateTimePicker2.Value = kartica.DatumIzdavanja;
            comboBox1.SelectedItem = kartica.Racun.BrojRacuna;
            textBox2.Text = kartica.DnevniLimit.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene debitne kartice?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                kartica.DatumIsteka = dateTimePicker1.Value;
                kartica.DatumIzdavanja = dateTimePicker2.Value;
                kartica.Racun = new RacunBasic(comboBox1.SelectedItem.ToString(), "", "", DateTime.Now, 0);
                kartica.DnevniLimit = decimal.Parse(textBox2.Text);
                DTOManager.azurirajDebitnuKarticu(kartica);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }
    }
}
