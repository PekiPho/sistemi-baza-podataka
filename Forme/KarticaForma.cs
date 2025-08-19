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
    public partial class KarticaForma : Form
    {
        public KarticaForma()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<KarticaPregled> kartica = DTOManager.vratiSveKartice();

            foreach(KarticaPregled k in kartica)
            {
                ListViewItem item = new ListViewItem(new string[] { k.BrojKartice, k.DatumIsteka.ToString("dd/MM/yyyy"), k.DatumIzdavanja.ToString("dd/MM/yyyy") });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajKarticuForma nf = new DodajKarticuForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite karticu");
                return;
            }
            string brojKartice = listView1.SelectedItems[0].SubItems[0].Text;
            string poruka = "Da li zelite da obrisete izabranu karticu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if(result == DialogResult.OK)
            {
                DTOManager.obrisiKarticu(brojKartice);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }
    }
}
