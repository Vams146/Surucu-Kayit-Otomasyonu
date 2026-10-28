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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SurucuKayıtOtomasyonu
{
    public partial class Notİslemleri : Form
    {
        public Notİslemleri()
        {
            InitializeComponent();
        }
        private void listele()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            MySqlCommand komut = new MySqlCommand("Select*from notlar", baglanti);
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
            MySqlCommand ara = new MySqlCommand("Select*from notlar where aday_tc like '" + textBox8.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            MySqlDataAdapter kopru = new MySqlDataAdapter(ara);
            kopru.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
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

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand ekle = new MySqlCommand("insert into notlar(aday_tc,aday_ad,aday_soyad,sınav_tarihi,trafik_s_not,motor_s_not,ilk_yardım_s_not)values(@tc,@ad,@sad,@st,@tsn,@msn,@iysn)", baglanti);
            ekle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            ekle.Parameters.AddWithValue("@ad", textBox2.Text);
            ekle.Parameters.AddWithValue("@sad", textBox3.Text);
            ekle.Parameters.AddWithValue("@tsn", textBox4.Text);
            ekle.Parameters.AddWithValue("@msn", textBox5.Text);
            ekle.Parameters.AddWithValue("@iysn", textBox6.Text);
            ekle.Parameters.AddWithValue("@st", dateTimePicker1.Value);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Not Başarıyla Eklendi");
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("Delete from notlar where idnot=@id", baglanti);
            sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idnot"].Value.ToString());
            sil.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Başarıyla Silindi");
            listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand guncelle = new MySqlCommand("update notlar set aday_tc=@tc,aday_ad=@ad,aday_soyad=@sad,sınav_tarihi=@st,trafik_s_not=@tsn,motor_s_not=@msn,ilk_yardım_s_not=@iysn where idnot=@id",baglanti);
            guncelle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@ad", textBox2.Text);
            guncelle.Parameters.AddWithValue("@sad", textBox3.Text);
            guncelle.Parameters.AddWithValue("@tsn", textBox4.Text);
            guncelle.Parameters.AddWithValue("@msn", textBox5.Text);
            guncelle.Parameters.AddWithValue("@iysn", textBox6.Text);
            guncelle.Parameters.AddWithValue("@st", dateTimePicker1.Value);
            guncelle.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idnot"].Value.ToString());
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Güncellendi");
            listele();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form a = new AnaMenu();
            a.Show();
            this.Hide();
        }

        private void Notİslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["aday_tc"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["aday_ad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["aday_soyad"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["trafik_s_not"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["motor_s_not"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["ilk_yardım_s_not"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["sınav_tarihi"].Value.ToString();
        }
    }
}
