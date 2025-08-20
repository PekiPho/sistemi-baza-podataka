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
    public partial class TransakcijeForma : Form
    {
        public TransakcijeForma()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<TransakcijaPregled> transakcija = DTOManager.vratiSveTransakcije();

            foreach(TransakcijaPregled t in transakcija)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    t.IdTransakcije.ToString(),
                    t.Valuta,
                    t.Datum.ToString("dd/MM/yyyy"),
                    t.Vreme,
                    t.Status,
                    t.Iznos.ToString(),
                    t.RazlogNeuspeha,
                    t.Vreme,
                    t.VrstaTransakcije
                });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite transakciju");
                return;
            }
            int IdTransakcije = int.Parse(listView1.SelectedItems[0].SubItems[0].Text); 
            string poruka = "Da li zelite da obrisete izabranu transakciju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                DTOManager.obrisiTransakciju(IdTransakcije);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajTransakcijuForma nf = new DodajTransakcijuForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite transakciju");
                return;
            }
            int brojTransakcije = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TransakcijaPregled t = DTOManager.vratiTransakciju(brojTransakcije);

            TransakcijaBasic transakcija = new TransakcijaBasic(
                t.IdTransakcije,
                t.Valuta,
                t.Datum,
                t.Status,
                t.Iznos,
                t.RazlogNeuspeha,
                t.Vreme,
                t.VrstaTransakcije,
                new KarticaBasic(t.Kartica.BrojKartice, DateTime.Now, DateTime.Now, null),
                new UredjajBasic(t.Uredjaj.IdUredjaja, "", "", DateTime.Now, DateTime.Now, "", "", "", null, null));
            IzmeniTransakcijuForma nf = new IzmeniTransakcijuForma(transakcija);
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }
    }
}
