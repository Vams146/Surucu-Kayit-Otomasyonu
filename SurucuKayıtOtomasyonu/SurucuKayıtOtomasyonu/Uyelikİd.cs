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
    public partial class Uyelikİd : Form
    {
        public Uyelikİd()
        {
            InitializeComponent();
        }

        private void Uyelikİd_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select iduyelik from uyelik where k_adi=@kad and guv_soru=@gs and cevap=@cvp", baglanti);
            komut.Parameters.AddWithValue("@kad", textBox1.Text);
            komut.Parameters.AddWithValue("@gs", comboBox1.Text);
            komut.Parameters.AddWithValue("@cvp", textBox2.Text);
            MySqlDataReader oku=komut.ExecuteReader();
            while(oku.Read())
                label5.Text = oku["iduyelik"].ToString();
        }
    }
}
