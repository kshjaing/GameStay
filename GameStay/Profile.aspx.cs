using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStay
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["아이디"] == null)
                {
                    Response.Redirect("RequestLogin.aspx");
                }
                else
                {

                }
            }
        }
        protected void editprofile_click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileEdit.aspx");
        }
    }
}