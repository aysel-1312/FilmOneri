using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace odevim
{
    public partial class Masterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void BtnKayit2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kullanicikayit.aspx");
        }

        protected void BtnKayit_Click(object sender, EventArgs e)
        {
            
            string baglantiYolu = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(baglantiYolu);

            con.Open();
            SqlCommand komut = new SqlCommand("select * from Kullanicilar where Kullaniciadi='" + TxtKullaniciAdi.Text + "' and sifre ='" + TxtSifre.Text + "'", con);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Session["Kullaniciadi"] = TxtKullaniciAdi.Text;
                //Session["KullaniciID"] = dr["KullaniciID"].ToString();
                Response.Redirect("Tavsiyesayfasi.aspx");
                LblSonuc.Text = "Hoşgeldin";
            }
            else
            {
                LblSonuc.Text = "Yanlış kullanıcı adı veya şifresi ";
            }

        }



        protected void TxtArama_TextChanged(object sender, EventArgs e)
        {
            Response.Redirect("Anasayfa.aspx");
        }

        protected void BtnArama_Click(object sender, EventArgs e)
        {
            Response.Redirect("Anasayfa.aspx");
        }
    }
}