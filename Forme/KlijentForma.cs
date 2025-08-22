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
    public partial class KlijentForma : Form
    {
        public KlijentForma()
        {
            InitializeComponent();
        }

        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<KlijentPregled> klijent = DTOManager.vratiSveKlijente();
            
            foreach(KlijentPregled k in klijent)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    k.IdKlijenta.ToString()
                });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajKlijentaForma nf = new DodajKlijentaForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite klijenta");
                return;
            }
            int idKlijenta = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranog klijenta?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                DTOManager.obrisiKlijenta(idKlijenta);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite klijenta");
                return;
            }
            int idKlijenta = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
