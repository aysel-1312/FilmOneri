using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace odevim
{
    public partial class KullanıcıAra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string isim = TextBox1.Text;
            GridView1.DataSource = islemlerim.KullaniciArama(isim);
            GridView1.DataBind();
            
           

            
        }

    }
}