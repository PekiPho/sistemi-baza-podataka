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
    public partial class DodajTransakcijuForma : Form
    {
        TransakcijaBasic transakcija;
        public DodajTransakcijuForma()
        {
            InitializeComponent();
            transakcija = new TransakcijaBasic();
        }

        private void DodajTransakcijuForma_Load(object sender, EventArgs e)
        {
            List<KarticaPregled> kartice = DTOManager.vratiSveKartice();

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();

            foreach (var k in kartice)
            {
                comboBox1.Items.Add(k.BrojKartice);
            }

            List<UredjajPregled> uredjaji = DTOManager.vratiSveUredjaje();

            comboBox2.DataSource = null;
            comboBox2.Items.Clear();

            foreach (var u in uredjaji)
            {
                comboBox2.Items.Add(u.IdUredjaja);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.transakcija.IdTransakcije = int.Parse(textBox1.Text);
            this.transakcija.Valuta = textBox2.Text;
            this.transakcija.Datum = dateTimePicker1.Value;
            this.transakcija.Status = textBox3.Text;
            this.transakcija.Iznos = decimal.Parse(textBox4.Text);
            this.transakcija.RazlogNeuspeha = textBox5.Text;
            this.transakcija.Vreme = textBox6.Text;
            this.transakcija.VrstaTransakcije = textBox7.Text;
            string odabraniBrojKartice = comboBox1.SelectedItem.ToString();
            this.transakcija.Kartica = new KarticaBasic(odabraniBrojKartice, DateTime.Now, DateTime.Now, null);
            int odabraniIDUredjaja = (int)comboBox2.SelectedItem;
            this.transakcija.Uredjaj = new UredjajBasic(odabraniIDUredjaja,"","",DateTime.Now,DateTime.Now,"","","",null,null);
            DTOManager.dodajTransakciju(this.transakcija);
            MessageBox.Show("Uspesno ste dodali novu transakciju!");
            this.Close();
        }
    }
}
