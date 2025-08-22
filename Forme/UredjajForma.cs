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
    public partial class UredjajForma : Form
    {
        public UredjajForma()
        {
            InitializeComponent();
            this.popuniPodacima();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<UredjajPregled> uredjaj = DTOManager.vratiSveUredjaje();

            foreach(UredjajPregled u in uredjaj)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    u.IdUredjaja.ToString(),
                    u.Proizvodjac,
                    u.StatusRada,
                    u.PoslednjiServis.ToString("dd/MM/yyyy"),
                    u.DatumInstalacije.ToString("dd/MM/yyyy"),
                    u.DodatniKomentar,
                    u.Adresa,
                    u.GPS
                });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajUredjajForma nf = new DodajUredjajForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite uredjaj");
                return;
            }
            int idUredjaja = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrani uredjaj?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                DTOManager.obrisiUredjaj(idUredjaja);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite uredjaj");
                return;
            }
            int idUredjaja = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            UredjajPregled u = DTOManager.vratiUredjaj(idUredjaja);

            UredjajBasic uredjaj = new UredjajBasic(
                u.IdUredjaja,
                u.Proizvodjac,
                u.StatusRada,
                u.PoslednjiServis,
                u.DatumInstalacije,
                u.DodatniKomentar,
                u.Adresa,
                u.GPS,
                new FilijalaBasic(u.Filijala.RedniBroj,"","","","",null),
                new BankaBasic(u.Banka.Id,"","","","",""));
            IzmeniUredjajForma nf = new IzmeniUredjajForma(uredjaj);
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BankomatForma nf = new BankomatForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KioskForma nf = new KioskForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UplatniAutomatForma nf = new UplatniAutomatForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
        }
    }
}
