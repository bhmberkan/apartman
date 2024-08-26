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
    public partial class daireler : Form
    {
        public daireler()
        {
            InitializeComponent();
        }
        OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=apartmann1.accdb");

        private void button4_Click(object sender, EventArgs e)
        {
            GİRİŞ g = new GİRİŞ();
            g.Show();
            this.Close();
        }

        public void yenile()
        {

            DataTable table = new DataTable();
            bagla.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * from daireler", bagla);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            bagla.Close();

        }
        public void yoket()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text= "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            
        }

        private void daireler_Load(object sender, EventArgs e)
        {
            yenile();
            comboBox1.Items.Add("boş");
            comboBox1.Items.Add("dolu");
            comboBox2.Items.Add("kiraci");
            comboBox2.Items.Add("ev sahibi");
            comboBox2.Items.Add("emlakçı");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand ekle = new OleDbCommand("INSERT into daireler(kontrol,bina_ad,daire_no,ad,soyad,tc,tel,email,durum)" +
                    "values('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + maskedTextBox1.Text + "','" + maskedTextBox2.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "')", bagla);
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
            bagla.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                OleDbCommand sil = new OleDbCommand("DELETE FROM daireler WHERE tc='" + textBox6.Text + "'", bagla);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand güncelle = new OleDbCommand("UPDATE daireler set kontrol='" + comboBox1.Text + "',bina_ad='" + textBox1.Text + "',daire_no='" + textBox2.Text + "',ad='" + textBox3.Text + "',soyad='" + textBox4.Text + "',tc='" + maskedTextBox1.Text + "',tel='" + maskedTextBox2.Text + "',email='" + textBox5.Text + "',durum='" + comboBox2.Text + "' WHERE tc='" + textBox6.Text + "'", bagla);
                bagla.Open();
                güncelle.ExecuteNonQuery();
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            bagla.Open();
            OleDbDataAdapter tara = new OleDbDataAdapter("SELECT * FROM daireler WHERE tc LIKE '" + textBox6.Text + "%'", bagla);
            tara.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bagla.Close();
        }
    }
}
