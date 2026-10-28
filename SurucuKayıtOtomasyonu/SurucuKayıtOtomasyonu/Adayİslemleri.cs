using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurucuKayıtOtomasyonu
{
    public partial class Adayİslemleri : Form
    {
        public Adayİslemleri()
        {
            InitializeComponent();
        }
        private void listele()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            MySqlCommand komut = new MySqlCommand("Select*from adaylar", baglanti);
            DataSet ds = new DataSet();
            MySqlDataAdapter kopru = new MySqlDataAdapter(komut);
            kopru.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        public void arama()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            MySqlCommand ara = new MySqlCommand("Select*from adaylar where aday_tc like '" + textBox8.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            MySqlDataAdapter kopru = new MySqlDataAdapter(ara);
            kopru.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.White;
            groupBox2.BackColor = Color.White;
            groupBox3.BackColor = Color.White;
            groupBox4.BackColor = Color.White;
            groupBox1.ForeColor = Color.Black;
            groupBox2.ForeColor = Color.Black;
            groupBox3.ForeColor = Color.Black;
            groupBox4.ForeColor = Color.Black;
            button8.BackColor = Color.White;
            button8.ForeColor = Color.Black;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.Gray;
            groupBox2.BackColor = Color.Gray;
            groupBox3.BackColor = Color.Gray;
            groupBox4.BackColor = Color.Gray;
            groupBox1.ForeColor = Color.White;
            groupBox2.ForeColor = Color.White;
            groupBox3.ForeColor = Color.White;
            groupBox4.ForeColor = Color.White;
            button8.BackColor = Color.Gray;
            button8.ForeColor = Color.White;
            button3.BackColor = Color.Gray;
            button4.BackColor = Color.Gray;
            button5.BackColor = Color.Gray;
            button6.BackColor = Color.Gray;
            button7.BackColor = Color.Gray;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.Black;
            groupBox2.BackColor = Color.Black;
            groupBox3.BackColor = Color.Black;
            groupBox4.BackColor = Color.Black;
            groupBox1.ForeColor = Color.White;
            groupBox2.ForeColor = Color.White;
            groupBox3.ForeColor = Color.White;
            groupBox4.ForeColor = Color.White;
            button8.BackColor = Color.Black;
            button8.ForeColor= Color.White;
            button3.BackColor = Color.Black;
            button4.BackColor = Color.Black;
            button5.BackColor = Color.Black;
            button6.BackColor = Color.Black;
            button7.BackColor = Color.Black;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand ekle = new MySqlCommand("insert into adaylar(aday_tc,aday_ad,aday_soyad,aday_yas,aday_od,aday_tel,aday_sr,aday_ab,aday_kt,aday_e_s,aday_res,aday_k_s)values(@tc,@ad,@sad,@yas,@od,@tel,@sr,@ab,@kt,@es,@res,@ks)", baglanti);
            ekle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            ekle.Parameters.AddWithValue("@tel", maskedTextBox2.Text);
            ekle.Parameters.AddWithValue("@ad", textBox3.Text);
            ekle.Parameters.AddWithValue("@sad", textBox4.Text);
            ekle.Parameters.AddWithValue("@yas", textBox5.Text);
            ekle.Parameters.AddWithValue("@res", textBox6.Text);
            ekle.Parameters.AddWithValue("@od", comboBox1.Text);
            ekle.Parameters.AddWithValue("@es", comboBox2.Text);
            ekle.Parameters.AddWithValue("@sr", comboBox3.Text);
            ekle.Parameters.AddWithValue("@ab", comboBox4.Text);
            ekle.Parameters.AddWithValue("@kt", dateTimePicker1.Text);
            ekle.Parameters.AddWithValue("@ks", textBox7.Text);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Aday Başarıyla Eklendi");
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["aday_tc"].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells["aday_tel"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["aday_ad"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["aday_soyad"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["aday_yas"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["aday_od"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["aday_e_s"].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells["aday_sr"].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells["aday_ab"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["aday_kt"].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells["aday_res"].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells["aday_k_s"].Value.ToString();
        }

        private void Adayİslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand guncelle = new MySqlCommand("update adaylar set aday_tc=@tc,aday_ad=@ad,aday_soyad=@sad,aday_yas=@yas,aday_od=@od,aday_e_s=@es,aday_sr=@sr,aday_ab=@ab,aday_kt=@kt where idadaylar=@id", baglanti);
            guncelle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@tel", maskedTextBox2.Text);
            guncelle.Parameters.AddWithValue("@ad", textBox3.Text);
            guncelle.Parameters.AddWithValue("@sad", textBox4.Text);
            guncelle.Parameters.AddWithValue("@yas", textBox5.Text);
            guncelle.Parameters.AddWithValue("@od", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@es", comboBox2.Text);
            guncelle.Parameters.AddWithValue("@sr", comboBox3.Text);
            guncelle.Parameters.AddWithValue("@ab", comboBox4.Text);
            guncelle.Parameters.AddWithValue("@kt", dateTimePicker1.Text);
            guncelle.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idadaylar"].Value.ToString());
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Güncellendi");
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("Delete from adaylar where idadaylar=@id", baglanti);
            sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idadaylar"].Value.ToString());
            sil.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Başarıyla Silindi");
            listele();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form a=new AnaMenu();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox6.Text = openFileDialog1.FileName;
        }
    }
}
