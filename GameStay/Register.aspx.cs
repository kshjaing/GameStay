using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStay
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["__EVENTTARGET"] == "div_logo")
            {
                Response.Redirect("Store_Main.aspx");
            }
        }

        protected void Register_OnClick(object sender, EventArgs e)
        {
            inputID.Value = "버튼작동";
        }
    }
}