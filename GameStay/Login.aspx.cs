using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GameStay
{
    public partial class Login : System.Web.UI.Page
    {
        DBManager dbManager = new DBManager();
        Boolean isLogin = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbManager.DBOpen();
        }

        public void Login_OnClick()
        {
            if (Request["__EVENTTARGET"] == "login_Click")
            {
                Response.Redirect("Store_Main.aspx");
                //inputID.Value = "뭔데";
            }
            
            isLogin = dbManager.Authenticate(inputID.Value.ToString(), inputPassword.Value.ToString());
            

            
            if (isLogin == true)
            {
                Response.Redirect("Store_Main.aspx");
            }
            else
                Response.Redirect("Register.aspx");
            
        }
    }
}