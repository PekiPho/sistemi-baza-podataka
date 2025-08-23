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
    public partial class FizickaLicaForma : Form
    {
        public FizickaLicaForma()
        {
            InitializeComponent();
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<FizickaLicaPregled> fl = DTOManager.vratiSvaFizickaLica();
            foreach(FizickaLicaPregled f in fl)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    f.IdKlijenta.ToString(),
                    f.JMBG,
                    f.MestoIzdavanja,
                    f.Adresa,
                    f.DatumRodjenja.ToString("dd/MM/yyyy"),
                    f.BrojLicneKarte,
                    f.LicnoIme,
                    f.ImeRoditelja,
                    f.Prezime
                });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DodajFizickaLicaForma nf = new DodajFizickaLicaForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
            this.popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite fizicko lice!");
                return;
            }
            int idFizickoLice = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrano fizicko lice?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                DTOManager.obrisiFizickoLice(idFizickoLice);
                MessageBox.Show("Uspesno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite fizicko lice!!");
                return;
            }
            int idFizickoLice = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            FizickaLicaPregled fl = DTOManager.vratiFizickoLice(idFizickoLice);

            FizickaLicaBasic flice = new FizickaLicaBasic(
                fl.IdKlijenta,
                fl.JMBG,
                fl.MestoIzdavanja,
                fl.Adresa,
                fl.DatumRodjenja,
                fl.BrojLicneKarte,
                fl.LicnoIme,
                fl.ImeRoditelja,
                fl.Prezime);
            IzmeniFizickaLicaForma nf = new IzmeniFizickaLicaForma(flice);
            this.Hide();
            nf.ShowDialog();
            this.Show();
            popuniPodacima();
        }
    }
}
