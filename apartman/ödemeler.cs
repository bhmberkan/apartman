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
    public partial class ödemeler : Form
    {
        public ödemeler()
        {
            InitializeComponent();
        }

        OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=apartmann1.accdb");

        public void yenile()
        {

            DataTable table = new DataTable();
            bagla.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * from ödemeler", bagla);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            bagla.Close();
        }
        public void yoket()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            richTextBox1.Text = "";
            maskedTextBox1.Text="";

        }
        public void toplam()
        {
            int para = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                para += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            textBox3.Text = para.ToString();
        }

        private void ödemeler_Load(object sender, EventArgs e)
        {
            yenile();
            toplam();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GİRİŞ g = new GİRİŞ();
            g.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand ekle = new OleDbCommand("INSERT into ödemeler(ad_soyad,tutar,açıklama,tarih,durum)" +
                    "values('" + textBox1.Text + "','" + textBox2.Text + "','" + richTextBox1.Text + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "')", bagla);
                bagla.Open();
                ekle.ExecuteNonQuery();
                bagla.Close();
                yenile();
                


            }
            catch (Exception sorun)
            {
                MessageBox.Show(sorun.Message);

            }
            toplam();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int x= dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[x].Cells[2].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[x].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[x].Cells[4].Value.ToString();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Ödemeniz Gerçekleşecektir emin misiniz!..", "Ödeme", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                     try
            {
                OleDbCommand sil = new OleDbCommand("DELETE FROM ödemeler WHERE ad_soyad='" + textBox1.Text + "'", bagla);
                bagla.Open();
                sil.ExecuteNonQuery();
                bagla.Close();
                yenile();
                yoket();


            }
            catch (Exception sorun)
            {
                MessageBox.Show(sorun.Message);

            }

            }
            yenile();
            toplam();
        }
    }
}
