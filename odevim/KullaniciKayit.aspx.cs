using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace odevim
{
    public partial class KullaniciKayit : System.Web.UI.Page
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/" + str));
                string Image = "~/img/" + str.ToString();
                string name = TextBox1.Text;
                islemlerim.kullanıcıekle(TextBox1.Text,TextBox2.Text,DropDownList1.SelectedValue.ToString(),Calendar1.SelectedDate.ToShortDateString(),TextBox4.Text,TextBox5.Text,Image);
             
                Label1.Text = "kayıt başarılı";
                
            }

            else
            {
                Label1.Text = "lütfen resim yükleyin";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}