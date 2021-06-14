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
    public partial class YoneticiGiris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(baglantiYolu);

            con.Open();
            SqlCommand komut = new SqlCommand("select * from YoneticiTablosu where kullaniciadi ='" + TextBox1.Text + "' and sifre ='" + TextBox2.Text + "'", con);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Session["Kullaniciadi"] = TextBox1.Text;
                //Session["KullaniciID"] = dr["KullaniciID"].ToString();
          // Label1.Text = "Hoşgeldin";
                Response.Redirect("AdminAnasayfasi.aspx");
            }
            else
            {
                Label1.Text = "Yanlış kullanıcı adı veya şifresi ";
            }

        }
    }
}