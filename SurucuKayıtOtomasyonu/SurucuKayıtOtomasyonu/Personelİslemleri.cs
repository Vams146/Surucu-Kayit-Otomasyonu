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
    public partial class Personelİslemleri : Form
    {
        public Personelİslemleri()
        {
            InitializeComponent();
        }
        private void listele()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            MySqlCommand komut = new MySqlCommand("Select*from personel", baglanti);
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
            MySqlCommand ara = new MySqlCommand("Select*from personel where per_tc like '" + textBox8.Text + "%'", baglanti);
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
            MySqlCommand ekle = new MySqlCommand("insert into personel(per_tc,per_ad,per_soyad,per_tel,per_adres,per_pos,per_gor)values(@tc,@ad,@sad,@tel,@adr,@pos,@gor)", baglanti);
            ekle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            ekle.Parameters.AddWithValue("@ad", textBox2.Text);
            ekle.Parameters.AddWithValue("@sad", textBox3.Text);
            ekle.Parameters.AddWithValue("@tel", maskedTextBox2.Text);
            ekle.Parameters.AddWithValue("@adr", richTextBox1.Text);
            ekle.Parameters.AddWithValue("@pos", textBox5.Text);
            ekle.Parameters.AddWithValue("@gor", textBox6.Text);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Personel Başarıyla Eklendi");
            listele();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void Personelİslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["per_tc"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["per_ad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["per_soyad"].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells["per_tel"].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells["per_adres"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["per_pos"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["per_gor"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("Delete from personel where idpersonel=@id", baglanti);
            sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idpersonel"].Value.ToString());
            sil.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Başarıyla Silindi");
            listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand guncelle = new MySqlCommand("update personel set per_tc=@tc,per_ad=@ad,per_soyad=@sad,per_tel=@tel,per_adres=@adr,per_pos=@pos,per_gor=@gor where idpersonel=@id", baglanti);
            guncelle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@ad", textBox2.Text);
            guncelle.Parameters.AddWithValue("@sad", textBox3.Text);
            guncelle.Parameters.AddWithValue("@tel", maskedTextBox2.Text);
            guncelle.Parameters.AddWithValue("@adr", richTextBox1.Text);
            guncelle.Parameters.AddWithValue("@pos", textBox5.Text);
            guncelle.Parameters.AddWithValue("@gor", textBox6.Text);
            guncelle.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idpersonel"].Value.ToString());
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Güncellendi");
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
