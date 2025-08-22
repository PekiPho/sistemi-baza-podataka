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
    public partial class DebitnaForma : Form
    {
        public DebitnaForma()
        {
            InitializeComponent();
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<DebitnaPregled> kartica = DTOManager.vratiSveDebitneKartice();

            foreach (DebitnaPregled k in kartica)
            {
                ListViewItem item = new ListViewItem(new string[] { k.BrojKartice,k.DnevniLimit.ToString()});
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite debitnu karticu!");
                return;
            }
            string brojdebitneKartice = listView1.SelectedItems[0].SubItems[0].Text;
            string poruka = "Da li zelite da obrisete izabranu karticu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiDebitnuKarticu(brojdebitneKartice);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajDebitnuForma nf = new DodajDebitnuForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite debitnu karticu");
                return;
            }
            string brojdebitneKartice = listView1.SelectedItems[0].SubItems[0].Text;
            DebitnaPregled k = DTOManager.vratiDebitnuKarticu(brojdebitneKartice);

            DebitnaBasic kartica = new DebitnaBasic(
                k.BrojKartice,
                k.DatumIsteka,
                k.DatumIzdavanja,
                new RacunBasic(k.Racun.BrojRacuna, "", "", DateTime.Now, 0),
                k.DnevniLimit);
            IzmeniDebitnuForma nf = new IzmeniDebitnuForma(kartica);
            this.Hide();
            nf.ShowDialog();
            this.Show();

            this.popuniPodacima();
        }
    }
}
