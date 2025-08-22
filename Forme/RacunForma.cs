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
    public partial class RacunForma : Form
    {
        public RacunForma()
        {
            InitializeComponent();
            this.popuniPodacima();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<RacunPregled> racuna = DTOManager.vratiSveRacune();

            foreach (RacunPregled r in racuna)
            {
                ListViewItem item = new ListViewItem(new string[] {
                r.BrojRacuna,
                r.Status,
                r.Valuta,
                r.DatumOtvaranja.ToString("dd/MM/yyyy"),
                r.TrenutniSaldo.ToString()});
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajRacunForma nf = new DodajRacunForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite racun!");
                return;
            }
            string brojRacuna = listView1.SelectedItems[0].SubItems[0].Text;
            string poruka = "Da li zelite da obrisete izabrani racun?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiRacun(brojRacuna);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite racun!");
                return;
            }
            string brojRacuna = listView1.SelectedItems[0].SubItems[0].Text;
            RacunPregled r = DTOManager.vratiRacun(brojRacuna);

            RacunBasic racun = new RacunBasic(
                r.BrojRacuna,
                r.Status,
                r.Valuta,
                r.DatumOtvaranja,
                r.TrenutniSaldo,
                new KlijentBasic(r.Klijent.IdKlijenta),
                new BankaBasic(r.Banka.Id,"","","","",""));
            IzmeniRacunForma nf = new IzmeniRacunForma(racun);
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }
    }
}
