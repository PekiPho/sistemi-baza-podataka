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
    public partial class IzmeniTransakcijuForma : Form
    {
        TransakcijaBasic transakcija;
        public IzmeniTransakcijuForma()
        {
            InitializeComponent();
        }
        public IzmeniTransakcijuForma(TransakcijaBasic t)
        {
            InitializeComponent();
            this.transakcija = t;
        }

        private void IzmeniTransakcijuForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE TRANSAKCIJE {transakcija.IdTransakcije.ToString().ToUpper()}";

            List<KarticaPregled> kartice = DTOManager.vratiSveKartice();

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();

            foreach (var k in kartice)
            {
                comboBox1.Items.Add(k.BrojKartice);
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            List<UredjajPregled> uredjaji = DTOManager.vratiSveUredjaje();

            comboBox2.DataSource = null;
            comboBox2.Items.Clear();

            foreach (var u in uredjaji)
            {
                comboBox2.Items.Add(u.IdUredjaja);
            }

            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }
        public void popuniPodacima()
        {
            textBox1.Text = transakcija.IdTransakcije.ToString();
            textBox1.Enabled = false;
            textBox2.Text = transakcija.Valuta;
            dateTimePicker1.Value = transakcija.Datum;
            textBox3.Text = transakcija.Status;
            textBox4.Text = transakcija.Iznos.ToString();
            textBox5.Text = transakcija.RazlogNeuspeha;
            textBox6.Text = transakcija.Vreme;
            textBox7.Text = transakcija.VrstaTransakcije;
            comboBox1.SelectedItem = transakcija.Kartica.BrojKartice;
            comboBox2.SelectedItem = transakcija.Uredjaj.IdUredjaja;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene transakcije?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                transakcija.Valuta = textBox2.Text;
                transakcija.Datum = dateTimePicker1.Value;
                transakcija.Status = textBox3.Text;
                transakcija.Iznos = decimal.Parse(textBox4.Text);
                transakcija.RazlogNeuspeha = textBox5.Text;
                transakcija.Vreme = textBox6.Text;
                transakcija.VrstaTransakcije = textBox7.Text;
                transakcija.Kartica = new KarticaBasic(comboBox1.SelectedItem.ToString(), DateTime.Now, DateTime.Now, null);
                transakcija.Uredjaj = new UredjajBasic((int)comboBox2.SelectedItem, "", "", DateTime.Now, DateTime.Now, "", "", "", null, null);
                DTOManager.azurirajTransakciju(transakcija);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }
    }
}
