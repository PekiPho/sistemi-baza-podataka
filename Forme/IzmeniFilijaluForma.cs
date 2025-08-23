using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proejkt.Entiteti;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proejkt.Forme
{
    public partial class IzmeniFilijaluForma : Form
    {
        FilijalaBasic filijala;
        public IzmeniFilijaluForma()
        {
            InitializeComponent();
        }
        public IzmeniFilijaluForma(FilijalaBasic f)
        {
            InitializeComponent();
            this.filijala = f;
        }

        public void popuniPodacima()
        {
            textBox1.Text = filijala.Adresa;
            textBox2.Text = filijala.RadniDan;
            textBox3.Text = filijala.Subota;
            textBox4.Text = filijala.Nedelja;
            comboBox1.SelectedItem = filijala.Banka.Id;
        }
        private void IzmeniFilijaluForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE FILIJALE {filijala.RedniBroj.ToString().ToUpper()}";

            List<BankaPregled> banke = DTOManager.vratiSveBanke();
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            foreach (var b in banke)
            {
                comboBox1.Items.Add(b.Id);
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmenu filijale?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                filijala.Adresa = textBox1.Text;
                filijala.RadniDan = textBox2.Text;
                filijala.Subota = textBox3.Text;
                filijala.Nedelja = textBox4.Text;
                filijala.Banka = new BankaBasic((int)comboBox1.SelectedItem,"","","","","");
                DTOManager.azurirajFilijalu(filijala);
                MessageBox.Show("Azuriranje uspesno!");
                this.Close();
            }
        }
    }
}
