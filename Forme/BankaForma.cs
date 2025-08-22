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
    public partial class BankaForma : Form
    {
        public BankaForma()
        {
            InitializeComponent();
            this.popuniPodacima();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<BankaPregled> banka = DTOManager.vratiSveBanke();

            foreach (BankaPregled b in banka)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    b.Id.ToString(),
                    b.Naziv,
                    b.Email,
                    b.AdresaCentrale,
                    b.WebAdresa,
                    b.BrojTelefona
                });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DodajBankuForma nf = new DodajBankuForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite banku!");
                return;
            }
            int idBanke = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu banku?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons); 
            if (result == DialogResult.OK)
            {
                DTOManager.obrisiBanku(idBanke);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite banku!");
                return;
            }
            int idBanke = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            BankaPregled b = DTOManager.vratiBanku(idBanke);

            BankaBasic banka = new BankaBasic(
                b.Id,
                b.Naziv,
                b.Email,
                b.AdresaCentrale,
                b.WebAdresa,
                b.BrojTelefona
                );
            IzmeniBankuForma nf = new IzmeniBankuForma(banka);
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }
    }
}