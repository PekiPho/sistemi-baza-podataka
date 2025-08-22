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
    public partial class KioskForma : Form
    {
        public KioskForma()
        {
            InitializeComponent();
            popuniPodacima();
        }
        
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<KioskPregled> kiosk = DTOManager.vratiSveKioske();
            foreach (KioskPregled k in kiosk)
            {
                ListViewItem item = new ListViewItem(new string[] {k.IdUredjaja.ToString(),k.Skener, k.Stampac});
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DodajKioskForma nf = new DodajKioskForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kiosk!");
                return;
            }
            int idKioska = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrani kiosk?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                DTOManager.obrisiKiosk(idKioska);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kiosk!");
                return;
            }
            int idKioska = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            KioskPregled k = DTOManager.vratiKiosk(idKioska);

            KioskBasic kiosk = new KioskBasic(
                k.IdUredjaja,
                k.Proizvodjac,
                k.StatusRada,
                k.PoslednjiServis,
                k.DatumInstalacije,
                k.DodatniKomentar,
                k.Adresa,
                k.GPS,
                new FilijalaBasic(k.Filijala.RedniBroj, "", "", "", "", null),
                new BankaBasic(k.Banka.Id, "", "", "", "", ""),
                k.Skener,
                k.Stampac);
            IzmeniKioskForma nf = new IzmeniKioskForma(kiosk);
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }
    }
}
