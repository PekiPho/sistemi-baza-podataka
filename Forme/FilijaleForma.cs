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
    public partial class FilijaleForma : Form
    {
        public FilijaleForma()
        {
            InitializeComponent();
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<FilijalaPregled> filijala = DTOManager.vratiSveFilijale();

            foreach (FilijalaPregled f in filijala)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    f.RedniBroj.ToString(),
                    f.Adresa,
                    f.RadniDan,
                    f.Subota,
                    f.Nedelja
                });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajFilijaluForma nf = new DodajFilijaluForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite filijalu");
                return;
            }
            int redniBrojFilijale = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu filijalu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                DTOManager.obrisiFilijalu(redniBrojFilijale);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite filijalu");
                return;
            }
            int redniBrojFilijale = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            FilijalaPregled f = DTOManager.vratiFilijalu(redniBrojFilijale);

            FilijalaBasic filijala = new FilijalaBasic(
                f.RedniBroj,
                f.Adresa,
                f.RadniDan,
                f.Subota,
                f.Nedelja,
                new BankaBasic(f.Banka.Id, "", "", "", "", "")
                );
            IzmeniFilijaluForma nf = new IzmeniFilijaluForma(filijala);
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }
    }
}
