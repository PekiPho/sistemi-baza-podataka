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
    public partial class BankomatForma : Form
    {
        public BankomatForma()
        {
            InitializeComponent();
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<BankomatPregled> bankomat = DTOManager.vratiSveBankomate();
            foreach(BankomatPregled b in bankomat)
            {
                ListViewItem item = new ListViewItem(new string[] {b.IdUredjaja.ToString(), b.MaxIznos.ToString(),
                b.BrojNovcanica.ToString()});
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajBankomatForma nf = new DodajBankomatForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite bankomat!");
                return;
            }
            int idBankomata = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrani bankomat?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                DTOManager.obrisiBankomat(idBankomata);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite bankomat!");
                return;
            }
            int idBankomata = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            BankomatPregled b = DTOManager.vratiBankomat(idBankomata);

            BankomatBasic bankomat = new BankomatBasic(
                b.IdUredjaja,
                b.Proizvodjac,
                b.StatusRada,
                b.PoslednjiServis,
                b.DatumInstalacije,
                b.DodatniKomentar,
                b.Adresa,
                b.GPS,
                new FilijalaBasic(b.Filijala.RedniBroj, "", "", "", "", null),
                new BankaBasic(b.Banka.Id,"","","","",""),
                b.MaxIznos,
                b.BrojNovcanica);
            IzmeniBankomatForma nf = new IzmeniBankomatForma(bankomat);
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }
    }
}
