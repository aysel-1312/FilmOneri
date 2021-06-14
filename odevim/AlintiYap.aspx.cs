using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace odevim
{
    public partial class AlintiYap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int FilmID = Convert.ToInt32(Session["secilenfilm"]);
            
            string kullaniciadi = Session["Kullaniciadi"].ToString();
            int kllncId = islemlerim.MaildenIdDonder(kullaniciadi);

           
            string Cumle = TextBox2.Text;

           
            
            //kullanıcı sınıfına inceleme kaydet methodu yapılacak
            islemlerim.AlintiEkle(kllncId,FilmID,Cumle);
            //kullanıcı sınıfına alıntı kaydet methodu yapılacak
            Response.Write("<script language='javascript'>alert('film için alıntı kaydınız alınmıstır.');</script>");
            Response.Redirect("filmdetay2.aspx");
        }










    }
}