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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SurucuKayıtOtomasyonu
{
    public partial class SifreDegistir : Form
    {
        public SifreDegistir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form a = new Uyelikİd();
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=surucukayıt;Uid=root;pwd=root");
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            MySqlCommand guncelle = new MySqlCommand("update uyelik set sifre=@sif where iduyelik=@id", baglanti);
            guncelle.Parameters.AddWithValue("@id", textBox1.Text);
            guncelle.Parameters.AddWithValue("@sif", textBox3.Text);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Şifreniz Başarıyla Değiştirildi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form a = new AnaMenu();
            a.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form a = new SifremiUnuttum();
            a.ShowDialog();
        }
    }
}
