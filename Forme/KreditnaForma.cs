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
    public partial class KreditnaForma : Form
    {
        public KreditnaForma()
        {
            InitializeComponent();
        }

        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<KreditnaPregled> kartica = DTOManager.vratiSveKreditneKartice();

            foreach (KreditnaPregled k in kartica)
            {
                ListViewItem item = new ListViewItem(new string[] { k.BrojKartice, k.DatumIsteka.ToString("dd/MM/yyyy"), k.DatumIzdavanja.ToString("dd/MM/yyyy"), k.MesecniLimit.ToString(),k.MaxPeriodOtplate.ToString() });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajKreditnuForma nf = new DodajKreditnuForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kreditnu karticu!");
                return;
            }
            string brojkreditneKartice = listView1.SelectedItems[0].SubItems[0].Text;
            string poruka = "Da li zelite da obrisete izabranu karticu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiKreditnuKarticu(brojkreditneKartice);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kreditnu karticu");
                return;
            }
            string brojkreditneKartice = listView1.SelectedItems[0].SubItems[0].Text;
            KreditnaPregled k = DTOManager.vratiKreditnuKarticu(brojkreditneKartice);

            KreditnaBasic kartica = new KreditnaBasic(
                k.BrojKartice,
                k.DatumIsteka,
                k.DatumIzdavanja,
                new RacunBasic(k.Racun.BrojRacuna, "", "", DateTime.Now, 0),
                k.MesecniLimit,
                k.MaxPeriodOtplate);
            IzmeniKreditnuForma nf = new IzmeniKreditnuForma(kartica);
            this.Hide();
            nf.ShowDialog();
            this.Show();

            this.popuniPodacima();
        }
    }
}
