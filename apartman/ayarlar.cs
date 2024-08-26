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
    public partial class ayarlar : Form
    {
        public ayarlar()
        {
            InitializeComponent();
        }

        OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=apartmann1.accdb");


        public void yenile()
        {

            DataTable table = new DataTable();
            bagla.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * from ayarlar", bagla);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            bagla.Close();

        }

        public int hesap()
        {
           
            
            int ind = Convert.ToInt32(textBox5.Text);
            int ode = Convert.ToInt32(textBox6.Text);
           int  a = Convert.ToInt32(textBox2.Text);
           int  b = Convert.ToInt32(textBox3.Text);
            ode = (a + (a % b)) - ind;
         
            return ode;
        }

        private void ayarlar_Load(object sender, EventArgs e)
        {
            yenile();
            textBox6.Text = "0";
            
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
               int ode = hesap();
                OleDbCommand ekle = new OleDbCommand("INSERT into ayarlar(apartman_ad,adres,aidat,faiz,yönetici_ad,indirim,ödenecek)" +
                    "values('" + textBox1.Text + "','" + richTextBox1.Text + "','" + textBox2.Text + "','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+ode+"')", bagla);
                bagla.Open();
                ekle.ExecuteNonQuery();
                bagla.Close();
                yenile();
                
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                richTextBox1.Text = "";
                
            }
            catch (Exception sorun)
            {
                MessageBox.Show(sorun.Message);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand sil = new OleDbCommand("DELETE FROM ayarlar WHERE adres='" + richTextBox1.Text + "'", bagla);
            bagla.Open();
            sil.ExecuteNonQuery();
            bagla.Close();
            yenile();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            richTextBox1.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int deger = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[deger].Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[deger].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[deger].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[deger].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[deger].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[deger].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.Rows[deger].Cells[7].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
