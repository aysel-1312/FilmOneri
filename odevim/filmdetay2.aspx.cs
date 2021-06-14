using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace odevim
{
    public partial class filmdetay2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           
            


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlintiYap.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("incelemeyap.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filmAd = Session["secilenfilm"].ToString();
            int kullaniciId = islemlerim.MaildenIdDonder(Session["kullaniciadi"].ToString());
            int id = islemlerim.AdaGoreIdDönder(filmAd);
            //secili rb ye gore kitabım okunma durumu kaydedilecek

            if (RadioButton1.Checked)
            {
                islemlerim.OkunduEkle(kullaniciId, id);
            }

            int puan = Convert.ToInt32(TextBox1.Text);
            //puan tablosuna puan kaydı yapılacak
            islemlerim.PuanEkle(kullaniciId, id, puan);
            Label2.Text = Convert.ToString(islemlerim.OrtalamaPuanHesapla(id));
            Label1.Text = Convert.ToString(islemlerim.izlenmeSayisi(id));
            Response.Write("<script language='javascript'>alert('FİLM  kaydınız alınmıştır.');</script>");

        }
    }
}