using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace giriss
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection connection = new SqlConnection("Data Source =LAPTOP-FID83MCL; Initial Catalog=model; Integrated Security=TRUE");
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-FID83MCL; Initial Catalog =master; Integrated Security=TRUE");
        public Form1()
        {
            InitializeComponent();
        }

        void cagir()
        {
            anaSayfa ns = new anaSayfa();
            ns.Show();        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adı";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Şifre")
            {
                txtSifre.Text = "";
                txtSifre.ForeColor = Color.White;
                txtSifre.PasswordChar = '*';
            }

        }
        char? bosluk = null;
        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (txtSifre.Text == "")
            {
                txtSifre.Text = "Şifre";
                txtSifre.ForeColor = Color.Silver;
                txtSifre.PasswordChar = Convert.ToChar(bosluk);
            }

        }
        bool isThere;
        public void button2_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string sifre = txtSifre.Text;

            cagir();
            connection.Open();
            SqlCommand yorum = new SqlCommand("Select *from MusteriTablo", connection);
            SqlDataReader reader = yorum.ExecuteReader();

            while (reader.Read())
            {
                if (kullaniciAdi == reader["kullanıcıadı"].ToString().TrimEnd() && sifre == reader["sifre"].ToString().TrimEnd())
                {
                    isThere = true;
                    break;
                }
                else
                {
                    isThere = false;
                }
            }

            connection.Close();
           
            if (isThere)
            {
                MessageBox.Show("Girişiniz Başarılı, " + " Artık Biletlere Çok Yakınsınız !", "Giriş");
                cagir();
               
            }
            else
            {
                MessageBox.Show("Girişiniz Başarısız, " + " Biletlere Bir Hayli Uzaksınız, Yeniden Deneyiniz !", "Giriş");
            }
        }

        public void btnPersonel_Click(object sender, EventArgs e)
        {
             string kullaniciAdi = textBox1.Text;
            string sifre = txtSifre.Text;
            cagir();
            con.Open();
            SqlCommand yorum2 = new SqlCommand("Select *from Personel", con);
            SqlDataReader reader2 = yorum2.ExecuteReader();

            while (reader2.Read())
            {
                if (kullaniciAdi == reader2["kullanıciadi"].ToString().TrimEnd() && sifre == reader2["pass"].ToString().TrimEnd())
                {
                    isThere = true;
                    cagir();
                    break;
                }
                else
                {
                    isThere = false;
                }
            }

            con.Close();
            if (isThere)
            {
                MessageBox.Show("Girişiniz Başarılı, " + " İşlemlerinizi Gerçekleştirebilirsiniz !", "Giriş");

                cagir();
            }
            else
            {
                MessageBox.Show("Girişiniz Başarısız, " + " Yapılacak İşlemler İçin Tekrar Deneyiniz !", "Giriş");
            }
        }
        bool move;
        int mouse_x;
        int mouse_y;

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;


        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
               this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Console.ReadKey();
        }

        
        
    }


}


