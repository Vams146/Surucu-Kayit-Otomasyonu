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
    public partial class YeniUyelik : Form
    {
        public YeniUyelik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("insert into uyelik(ad,soyad,e_posta,k_adi,sifre,guv_soru,cevap)values(@ad,@sad,@pos,@kad,@sifre,@guv,@cev)", baglanti);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@sad", textBox2.Text);
            komut.Parameters.AddWithValue("@pos", textBox3.Text);
            komut.Parameters.AddWithValue("@kad", textBox4.Text);
            komut.Parameters.AddWithValue("@sifre", textBox5.Text);
            komut.Parameters.AddWithValue("@guv", comboBox1.Text);
            komut.Parameters.AddWithValue("@cev", textBox6.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Tamamlandı");
            this.Hide();
        }

        private void YeniUyelik_Load(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select guv_soru from guvenlik", baglanti);
            MySqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["guv_soru"].ToString());
            }
            baglanti.Close();
        }
    }
}
