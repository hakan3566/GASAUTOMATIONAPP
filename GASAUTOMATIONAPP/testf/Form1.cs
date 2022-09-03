using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace testf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Data Source=.;Initial Catalog=TestBenzin;Integrated Security=True

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=TestBenzin;Integrated Security=True");

        void listele()
        {
            //Kurşunsuz 95
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from tblbenzin where petroltur='Kursunsuz95'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblKursunsuz95.Text = dr[3].ToString();
                progressBar1.Value = int.Parse(dr[5].ToString());
                lblKursunsuz95Litre.Text = dr[5].ToString();
            }
            baglanti.Close();


            //Kurşunsuz 97
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * from tblbenzin where petroltur='Kursunsuz97'", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblKursunsuz97.Text = dr2[3].ToString();
                progressBar2.Value = int.Parse(dr2[5].ToString());
                lblKursunsuz97Litre.Text = dr2[5].ToString();

            }
            baglanti.Close();


            //Euro Dizel 10
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select * from tblbenzin where petroltur='EuroDizel10'", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblEuroDizel.Text = dr3[3].ToString();
                progressBar3.Value = int.Parse(dr3[5].ToString());
                lblEuroDizelLitre.Text = dr3[5].ToString();
            }
            baglanti.Close();


            //Yeni Pro Dizel
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select * from tblbenzin where petroltur='YeniProDizel'", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblYeniProDizel.Text = dr4[3].ToString();
                progressBar4.Value = int.Parse(dr4[5].ToString());
                lblYeniProDizelLitre.Text = dr4[5].ToString();
            }
            baglanti.Close();


            //Gaz
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select * from tblbenzin where petroltur='Gaz'", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblGaz.Text = dr5[3].ToString();
                progressBar5.Value = int.Parse(dr5[5].ToString());
                lblGazLitre.Text = dr5[5].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select * from tblkasa", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblkasa.Text= dr6[0].ToString();
            }
            baglanti.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(lblKursunsuz95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            txtKursunsuz95Fiyat.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar;
            kursunsuz97 = Convert.ToDouble(lblKursunsuz97.Text);
            litre=Convert.ToDouble(numericUpDown2.Value);
            tutar = kursunsuz97 * litre;
            txtKursunsuz97Fiyat.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double euroDizel, litre, tutar;
            euroDizel = Convert.ToDouble(lblEuroDizel.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = euroDizel * litre;
            txtEuroDizelFiyat.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double yeniProDizel, litre, tutar;
            yeniProDizel = Convert.ToDouble(lblYeniProDizel.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = yeniProDizel * litre;
            txtYeniProDizelFiyat.Text = tutar.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(lblGaz.Text);
            litre = Convert.ToDouble(numericUpDown5.Value);
            tutar = gaz * litre;
            txtGazFiyat.Text = tutar.ToString();

            
        }

        private void btnDepoDoldur_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0) {
                if (txtPlaka.Text != "")
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into tblhareket (plaka,benzinturu,litre1,fiyat) " +
                    "values (@p1,@p2,@p3,@p4)", baglanti);
                    komut.Parameters.AddWithValue("@p1", txtPlaka.Text);
                    komut.Parameters.AddWithValue("@p2", "Kursunsuz95");
                    komut.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                    komut.Parameters.AddWithValue("@p4", decimal.Parse(txtKursunsuz95Fiyat.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();


                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("update tblkasa set miktar=miktar+@p1", baglanti);
                    komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtKursunsuz95Fiyat.Text));
                    komut2.ExecuteNonQuery();
                    baglanti.Close();


                    baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("update tblbenzin set stoktrue=stoktrue-@p1 where petroltur='kursunsuz95'", baglanti);
                    komut3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                    komut3.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Satış yapıldı");
                    listele();
                    numericUpDown1.Value = 0;
                   
                }
                else { MessageBox.Show("Lütfen Plaka Giriniz!"); }
            }
            else if (numericUpDown2.Value != 0)
            {
                if (txtPlaka.Text != "")
                {
                    baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into tblhareket (plaka,benzinturu,litre1,fiyat) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtPlaka.Text);
                komut.Parameters.AddWithValue("@p2", "Kursunsuz97");
                komut.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(txtKursunsuz97Fiyat.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set miktar=miktar+@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtKursunsuz97Fiyat.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzin set stoktrue=stoktrue-@p1 where petroltur='kursunsuz97'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış yapıldı");
                listele();
                numericUpDown2.Value = 0;

                }
                else { MessageBox.Show("Lütfen Plaka Giriniz!"); }

            }
            else if (numericUpDown3.Value != 0)  {
                
                if(txtPlaka.Text != "") { 
                     baglanti.Open();
                      SqlCommand komut = new SqlCommand("insert into tblhareket (plaka,benzinturu,litre1,fiyat) values (@p1,@p2,@p3,@p4)", baglanti);
                      komut.Parameters.AddWithValue("@p1", txtPlaka.Text);
                      komut.Parameters.AddWithValue("@p2", "EuroDizel10");
                      komut.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                      komut.Parameters.AddWithValue("@p4", decimal.Parse(txtEuroDizelFiyat.Text));
                      komut.ExecuteNonQuery();
                      baglanti.Close();

                      baglanti.Open();
                      SqlCommand komut2 = new SqlCommand("update tblkasa set miktar=miktar+@p1", baglanti);
                      komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtEuroDizelFiyat.Text));
                      komut2.ExecuteNonQuery();
                      baglanti.Close();

                      baglanti.Open();
                      SqlCommand komut3 = new SqlCommand("update tblbenzin set stoktrue=stoktrue-@p1 where petroltur='EuroDizel10'", baglanti);
                      komut3.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                      komut3.ExecuteNonQuery();
                      baglanti.Close();
                      MessageBox.Show("Satış yapıldı");
                      listele();
                      numericUpDown3.Value = 0;
                }
                else { MessageBox.Show("Lütfen Plaka Bilgisi Giriniz!"); }
            }
            else if (numericUpDown4.Value != 0){
                if (txtPlaka.Text != "")
                {

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into tblhareket (plaka,benzinturu,litre1,fiyat) values (@p1,@p2,@p3,@p4)", baglanti);
                    komut.Parameters.AddWithValue("@p1", txtPlaka.Text);
                    komut.Parameters.AddWithValue("@p2", "YeniProDizel");
                    komut.Parameters.AddWithValue("@p3", numericUpDown4.Value);
                    komut.Parameters.AddWithValue("@p4", decimal.Parse(txtYeniProDizelFiyat.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("update tblkasa set miktar=miktar+@p1", baglanti);
                    komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtYeniProDizelFiyat.Text));
                    komut2.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("update tblbenzin set stoktrue=stoktrue-@p1 where petroltur='YeniProDizel'", baglanti);
                    komut3.Parameters.AddWithValue("@p1", numericUpDown4.Value);
                    komut3.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Satış yapıldı");
                    listele();
                    numericUpDown4.Value = 0;
                }
                else { MessageBox.Show("Lütfen Plaka Bilgisi Giriniz!"); }
            }
            else if (numericUpDown5.Value != 0){
                if (txtPlaka.Text != "")
                {

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into tblhareket (plaka,benzinturu,litre1,fiyat) values (@p1,@p2,@p3,@p4)", baglanti);
                    komut.Parameters.AddWithValue("@p1", txtPlaka.Text);
                    komut.Parameters.AddWithValue("@p2", "gaz");
                    komut.Parameters.AddWithValue("@p3", numericUpDown5.Value);
                    komut.Parameters.AddWithValue("@p4", decimal.Parse(txtGazFiyat.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("update tblkasa set miktar=miktar+@p1", baglanti);
                    komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtGazFiyat.Text));
                    komut2.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("update tblbenzin set stoktrue=stoktrue-@p1 where petroltur='gaz'", baglanti);
                    komut3.Parameters.AddWithValue("@p1", numericUpDown5.Value);
                    komut3.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Satış yapıldı");
                    listele();
                    numericUpDown5.Value = 0;
                }
                else { MessageBox.Show("Lütfen Plaka Bilgisi Giriniz!"); }
            }
            else { MessageBox.Show("Lütfen Kaç Litre Yakıt Aldığını Giriniz!"); }
        }

       
    }
}
