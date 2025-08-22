using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proejkt.Forme;

namespace proejkt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UredjajForma nf = new UredjajForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransakcijeForma nf = new TransakcijeForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BankaForma nf = new BankaForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FilijaleForma nf = new FilijaleForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RacunForma nf = new RacunForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KarticaForma nf = new KarticaForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            KlijentForma nf = new KlijentForma();
            this.Hide();
            nf.ShowDialog();
            this.Show();
        }
    }
}
