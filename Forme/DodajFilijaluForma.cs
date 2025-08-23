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
    public partial class DodajFilijaluForma : Form
    {
        FilijalaBasic filijala;
        public DodajFilijaluForma()
        {
            InitializeComponent();
            filijala = new FilijalaBasic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.filijala.Adresa = textBox1.Text;
            this.filijala.RadniDan = textBox2.Text;
            this.filijala.Subota = textBox3.Text;
            this.filijala.Nedelja = textBox4.Text;
            int idBanke = (int)comboBox1.SelectedItem;
            this.filijala.Banka = new BankaBasic(idBanke, "", "", "", "", "");
            DTOManager.dodajFilijalu(filijala);
            MessageBox.Show("Uspesno ste dodali novu filijalu!");
            this.Close();
        }

        private void DodajFilijaluForma_Load(object sender, EventArgs e)
        {
            List<BankaPregled> banke = DTOManager.vratiSveBanke();
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            foreach(var b in banke)
            {
                comboBox1.Items.Add(b.Id);
            }
        }
    }
}
