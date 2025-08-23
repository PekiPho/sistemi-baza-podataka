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
    public partial class PravnaLicaForma : Form
    {
        public PravnaLicaForma()
        {
            InitializeComponent();
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<PravnaLicaPregled> pl = DTOManager.vratiSvaPravnaLica();
            foreach (PravnaLicaPregled p in pl)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                   p.IdKlijenta.ToString(),
                   p.PIB,
                   p.NazivFirme,
                   p.Kontakt,
                   p.MaticniBroj,
                   p.Delatnost,
                   p.Adresa,
                   p.KontaktPodaci
                });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajPravnaLicaForma nf = new DodajPravnaLicaForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite pravno lice!");
                return;
            }
            int idPravnoLice = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrano pravno lice";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                DTOManager.obrisiPravnoLice(idPravnoLice);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite pravno lice!!");
                return;
            }
            int idPravnoLice = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            PravnaLicaPregled pl = DTOManager.vratiPravnoLice(idPravnoLice);

            PravnaLicaBasic plice = new PravnaLicaBasic(
               pl.IdKlijenta,
               pl.PIB,
               pl.NazivFirme,
               pl.Kontakt,
               pl.MaticniBroj,
               pl.Delatnost,
               pl.Adresa,
               pl.KontaktPodaci);
            IzmeniPravnaLicaForma nf = new IzmeniPravnaLicaForma(plice);
            this.Hide();
            nf.ShowDialog();
            this.Show();
            popuniPodacima();
        }
    }
}
