using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SurucuKayıtOtomasyonu
{
    public partial class Kimlikİslemleri : Form
    {
        public Kimlikİslemleri()
        {
            InitializeComponent();
        }
        private void listele()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            MySqlCommand komut = new MySqlCommand("Select*from kimlik", baglanti);
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
            MySqlCommand ara = new MySqlCommand("Select*from kimlik where tc like '" + textBox8.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            MySqlDataAdapter kopru = new MySqlDataAdapter(ara);
            kopru.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button8_Click(object sender, EventArgs e)
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
            button8.ForeColor = Color.White;
            button3.BackColor = Color.Black;
            button4.BackColor = Color.Black;
            button5.BackColor = Color.Black;
            button6.BackColor = Color.Black;
            button7.BackColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand ekle = new MySqlCommand("insert into kimlik(tc,soyad,ad,dogum_tarihi,seri_no,cinsiyet,anne_ad,baba_ad)values(@tc,@sad,@ad,@dt,@sn,@ct,@aa,@ba)", baglanti);
            ekle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            ekle.Parameters.AddWithValue("@sn", textBox1.Text);
            ekle.Parameters.AddWithValue("@sad", textBox2.Text);
            ekle.Parameters.AddWithValue("@ad", textBox3.Text);
            ekle.Parameters.AddWithValue("@aa", textBox5.Text);
            ekle.Parameters.AddWithValue("@ba", textBox6.Text);
            ekle.Parameters.AddWithValue("@ct", comboBox1.Text);
            ekle.Parameters.AddWithValue("@dt", dateTimePicker1.Text);
            ekle.Parameters.AddWithValue("@res", textBox6.Text);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Kimlik Başarıyla Eklendi");
            listele();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("Delete from kimlik where idkimlik=@id", baglanti);
            sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idkimlik"].Value.ToString());
            sil.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Başarıyla Silindi");
            listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand guncelle = new MySqlCommand("update kimlik set tc=@tc,soyad=@sad,ad=@ad,dogum_tarihi=@dt,seri_no=@sn,cinsiyet=@ct,anne_ad=@aa,baba_ad=@ba where idkimlik=@id",baglanti);
            guncelle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@sn", textBox1.Text);
            guncelle.Parameters.AddWithValue("@sad", textBox2.Text);
            guncelle.Parameters.AddWithValue("@ad", textBox3.Text);
            guncelle.Parameters.AddWithValue("@aa", textBox5.Text);
            guncelle.Parameters.AddWithValue("@ba", textBox6.Text);
            guncelle.Parameters.AddWithValue("@ct", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@dt", dateTimePicker1.Value);
            guncelle.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idkimlik"].Value.ToString());
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Güncellendi");
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["seri_no"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["soyad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["ad"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["dogum_tarihi"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["anne_ad"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["baba_ad"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["cinsiyet"].Value.ToString();
        }

        private void Kimlikİslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form a = new AnaMenu();
            a.Show();
            this.Hide();
        }
    }
}
