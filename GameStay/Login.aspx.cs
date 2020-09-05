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

        

        public void OnClick()
        {
            if (Request["__EVENTTARGET"] == "login_Click")
            {
                
            }
        }


        //로그인 버튼 클릭
        protected void imgbtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            isLogin = dbManager.Authenticate(inputID.Value.ToString(), inputPassword.Value.ToString());

            if (inputID.Value.Length == 0 || inputPassword.Value.Length == 0)
            {
            }

            else
            {
                if (isLogin == true)
                {
                }
                else
                {

                }
            }
        }

    }
}