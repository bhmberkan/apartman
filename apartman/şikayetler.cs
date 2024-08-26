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
    public partial class şikayetler : Form
    {
        public şikayetler()
        {
            InitializeComponent();
        }

        OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=apartmann1.accdb");

        public void yenile()
        {

            DataTable table = new DataTable();
            bagla.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * from sikayet", bagla);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            bagla.Close();

        }
        public void yoket()
        {
            maskedTextBox1.Text = "";
            textBox1.Text = "";
            richTextBox1.Text = "";
        }
      

        private void button3_Click(object sender, EventArgs e)
        {
            GİRİŞ g = new GİRİŞ();
            g.Show();
            this.Close();
        }

        private void şikayetler_Load(object sender, EventArgs e)
        {
            yenile();
            yoket();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand ekle = new OleDbCommand("INSERT into sikayet(tarih,aciklama,maliyet)" +
                    "values('" + maskedTextBox1.Text + "','" + richTextBox1.Text + "','" + textBox1.Text + "')", bagla);
                bagla.Open();
                ekle.ExecuteNonQuery();
                bagla.Close();
                yenile();
                yoket();


            }
            catch (Exception sorun)
            {
                MessageBox.Show(sorun.Message);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
             try
             {
                OleDbCommand sil = new OleDbCommand("DELETE FROM sikayet WHERE aciklama='" + textBox2.Text + "'", bagla);
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
            bagla.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            maskedTextBox1.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[x].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[x].Cells[3].Value.ToString();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tablo = new DataTable();
                bagla.Open();
                OleDbDataAdapter tara = new OleDbDataAdapter("SELECT * FROM sikayet WHERE aciklama LIKE '" + textBox2.Text + "%'", bagla);
                tara.Fill(tablo);
                dataGridView1.DataSource = tablo;
                bagla.Close();
            }
            catch (Exception sorun)
            {
                MessageBox.Show(sorun.Message);
            }
            bagla.Close();
        }
    }
}
