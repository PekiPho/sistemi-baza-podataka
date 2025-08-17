using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace proejkt.Forme
{
    public partial class DodajKlijentaForma : Form
    {
        public DodajKlijentaForma()
        {
            comboBox1.SelectedIndex = 0;
        }

        private void DodajKlijentaForma_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = (comboBox1.SelectedIndex == 0);
            panel2.Visible = (comboBox1.SelectedIndex == 1);
            panel3.Visible = (comboBox1.SelectedIndex == 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    var f = new FizickaLicaBasic
                    {
                        JMBG = txtJmbg.Text,
                        MestoIzdavanja = txtMestoIzdavanja.Text,
                        Adresa = txtAdresaF.Text,
                        BrojLicneKarte = txtLicnaKarta.Text,
                        LicnoIme = txtIme.Text,
                        ImeRoditelja = txtImeRoditelja.Text,
                        Prezime = txtPrezime.Text
                    };

                    DTOManager.dodajFizickoLice(f);
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    var p = new PravnaLicaBasic
                    {
                        PIB = txtPIB.Text,
                        NazivFirme = txtNazivFirme.Text,
                        Kontakt = txtKontakt.Text,
                        MaticniBroj = txtMaticniBroj.Text,
                        Delatnost = txtDelatnost.Text,
                        Adresa = txtAdresaP.Text,
                        KontaktPodaci = txtKontaktPodaciP.Text
                    };

                    DTOManager.dodajPravnoLice(p);
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    var o = new OrganizacijaBasic
                    {
                        Registar = txtRegistar.Text,
                        Tip = txtTipOrg.Text,
                        Osnivac = txtOsnivac.Text,
                        KontaktPodaci = txtKontaktOrg.Text,
                        Adresa = txtAdresaO.Text
                    };

                    DTOManager.dodajOrganizaciju(o);
                }

                MessageBox.Show("Klijent uspešno dodat!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
