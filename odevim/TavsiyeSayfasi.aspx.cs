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
    public partial class TavsiyeSayfasi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {

            



            int bnmId = islemlerim.MaildenIdDonder(Session["kullaniciadi"].ToString());
            GridView8.DataSource = islemlerim.AynifilmizleyenKullanicilar(bnmId);
            GridView8.DataBind();


            GridView9.DataSource = islemlerim.AyniPuanVerenKullanicilar(bnmId);
            GridView9.DataBind();
        }

        protected void txtarama_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);

            string sql = "select * from filmtanim where FilmAdi like'" + txtarama.Text + "%'";
            SqlCommand komutNesnesi = new SqlCommand(sql, baglanti);

            SqlDataAdapter adaptor = new SqlDataAdapter(sql, baglanti);
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);
            GridView1.DataSource = tablo;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);

            string sql = "select * from Senarist where SenaristAdi like'" + txtarama2.Text + "%'";
            SqlCommand komutNesnesi = new SqlCommand(sql, baglanti);

            SqlDataAdapter adaptor = new SqlDataAdapter(sql, baglanti);
            DataTable tablo2 = new DataTable();
            adaptor.Fill(tablo2);
            GridView2.DataSource = tablo2;
            GridView2.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
          

        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
          GridView4.DataSource=  islemlerim.POPGOSTER();
            GridView4.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);

            string sql = "select * from Yonetmen where YonetmenAdi like'" + TxtYonetmenAra.Text + "%'";
            SqlCommand komutNesnesi = new SqlCommand(sql, baglanti);

            SqlDataAdapter adaptor = new SqlDataAdapter(sql, baglanti);
            DataTable tablo3 = new DataTable();
            adaptor.Fill(tablo3);
            GridView3.DataSource = tablo3;
            GridView3.DataBind();
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
           // FİLM detay sayfasına yonlendirilecek ve secilen FİLMİN ıd si yollanacak
            int seciliSatirIndex = GridView4.SelectedIndex;
            GridViewRow satir = GridView4.Rows[seciliSatirIndex];

            Session["PopSecilenFilm"] = satir.Cells[1].Text;
            Response.Redirect("filmdetay2.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            GridView6.DataSource = islemlerim.Yuksekpuanlifilmler();
            GridView6.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            GridView7.DataSource = islemlerim.popkategoriler();
            GridView7.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seciliSatirIndex = GridView1.SelectedIndex;
            GridViewRow satir = GridView1.Rows[seciliSatirIndex];

            Session["secilenfilm"] = satir.Cells[1].Text;
            Response.Redirect("filmdetay2.aspx");
        }

        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FİLM detay sayfasına yonlendirilecek
            int seciliSatirIndex = GridView6.SelectedIndex;
            GridViewRow satir = GridView6.Rows[seciliSatirIndex];

            Session["YuksekPuanliSecilenFilm"] = satir.Cells[1].Text;
            Session["PopSecilenFilm"] = "";
            Session["öneridenGelenfilm"] = "";
            Session["yonetmendenSecilenfilm"] = "";
            Session["secilenfilm"] = "";

            Response.Redirect("filmdetay2.aspx");
        }

        protected void GridView7_SelectedIndexChanged(object sender, EventArgs e)
        {
            //secilen satırdaki yönetmenin filmi listelenecek
            int seciliSatirIndex = GridView7.SelectedIndex;
            GridViewRow satir = GridView7.Rows[seciliSatirIndex];
            Session["secilenfilm"] = satir.Cells[1].Text;

            Session["kategoridensecilenfilm"] = satir.Cells[1].Text;
            Response.Redirect("filmdetay2.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("filmoneri.aspx");
        }
    }
}