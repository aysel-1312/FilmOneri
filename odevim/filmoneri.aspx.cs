using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace odevim
{
    public partial class filmoneri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idm = islemlerim.MaildenIdDonder(Session["kullaniciadi"].ToString());


            GridView1.DataSource = islemlerim.tavsiye1(idm);
            GridView1.DataBind();


          // GridView2.DataSource = islemlerim.tavsiye2(idm);
            GridView2.DataBind();

            GridView3.DataSource = islemlerim.tavsiye3(idm);
            GridView3.DataBind();



        }
    }
}