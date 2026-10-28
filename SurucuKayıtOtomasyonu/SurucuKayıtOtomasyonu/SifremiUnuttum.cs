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
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select*from uyelik where k_adi=@kad and guv_soru=@soru and cevap=@cev", baglanti);
            komut.Parameters.AddWithValue("@kad", textBox1.Text);
            komut.Parameters.AddWithValue("@soru", comboBox1.Text);
            komut.Parameters.AddWithValue("@cev", textBox3.Text);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                label2.Visible = true;
                textBox2.Visible = true;
                button2.Visible = true;
            }
        }

        private void SifremiUnuttum_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select guv_soru from guvenlik", baglanti);
            MySqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["guv_soru"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            MySqlCommand guncelle = new MySqlCommand("update uyelik set sifre=@sif where k_adi=@kad and guv_soru=@soru and cevap=@cev", baglanti);
            guncelle.Parameters.AddWithValue("@sif", textBox2.Text);
            guncelle.Parameters.AddWithValue("@kad", textBox1.Text);
            guncelle.Parameters.AddWithValue("@soru", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@cev", textBox3.Text);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Şifreniz Başarıyla Değiştirildi");
            this.Hide();
        }
    }
}

