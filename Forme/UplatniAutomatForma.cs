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
    public partial class UplatniAutomatForma : Form
    {
        public UplatniAutomatForma()
        {
            InitializeComponent();
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<UplatniAutomatPregled> uAutomat = DTOManager.vratiSveUplatneAutomate();
            foreach (UplatniAutomatPregled u in uAutomat)
            {
                ListViewItem item = new ListViewItem(new string[] { u.IdUredjaja.ToString(), u.VrstaUplate, u.Validator });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DodajAutomatForma nf = new DodajAutomatForma();
            this.Hide();
            nf.ShowDialog();
            this.Hide();
            popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite uplatni automat!");
                return;
            }
            int idAutomata = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrani automat?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                DTOManager.obrisiUplatniAutomat(idAutomata);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite automat!");
                return;
            }
            int idAutomata = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            UplatniAutomatPregled a = DTOManager.vratiUplatniAutomat(idAutomata);

            UplatniAutomatBasic automat = new UplatniAutomatBasic(
                a.IdUredjaja,
                a.Proizvodjac,
                a.StatusRada,
                a.PoslednjiServis,
                a.DatumInstalacije,
                a.DodatniKomentar,
                a.Adresa,
                a.GPS,
                new FilijalaBasic(a.Filijala.RedniBroj, "", "", "", "", null),
                new BankaBasic(a.Banka.Id, "", "", "", "", ""),
                a.VrstaUplate,
                a.Validator);
            IzmeniAutomatForma nf = new IzmeniAutomatForma(automat);
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }
    }
}
