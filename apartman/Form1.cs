using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace apartman
{
    public partial class GİRİŞ : Form
    {
        public GİRİŞ()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            daireler d = new daireler();
            d.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ödemeler öd = new ödemeler();
            öd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            şikayetler şik = new şikayetler();
            şik.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ayarlar ay = new ayarlar();
            ay.Show();
            this.Hide();
        }
    }
}
