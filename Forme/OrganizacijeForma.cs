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
    public partial class OrganizacijeForma : Form
    {
        public OrganizacijeForma()
        {
            InitializeComponent();
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<OrganizacijePregled> organizacije = DTOManager.vratiSveOrganizacije();
            foreach (OrganizacijePregled o in organizacije)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    o.IdKlijenta.ToString(),
                    o.Registar,
                    o.Tip,
                    o.KontaktPodaci,
                    o.Adresa
                });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajOrganizacijuForma nf = new DodajOrganizacijuForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite organizaciju");
                return;
            }
            int idOrganizacije = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu organizaciju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                DTOManager.obrisiOrganizaciju(idOrganizacije);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite organizaciju!");
                return;
            }
            int idOrganizacije = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            OrganizacijePregled  o = DTOManager.vratiOrganizaciju(idOrganizacije);
            OrganizacijaBasic organizacija = new OrganizacijaBasic(
                o.IdKlijenta,
                o.Registar,
                o.Tip,
                o.Osnivac,
                o.KontaktPodaci,
                o.Adresa);
            IzmeniOrganizacijuForma nf = new IzmeniOrganizacijuForma(organizacija);
            this.Hide();
            nf.ShowDialog();
            this.Show();
            popuniPodacima();
        }
    }
}
