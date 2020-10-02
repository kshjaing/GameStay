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
            
            if (Request["__EVENTTARGET"] == "div_logo")
            {
                Response.Redirect("Store_Main.aspx");
            }
        }


        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            isLogin = dbManager.Authenticate(inputID.Value.ToString(), inputPassword.Value.ToString());

            if (inputID.Value.Length == 0 || inputPassword.Value.Length == 0)
            {
                txtLoginCheck.Attributes.Add("style", "visibility: visible");
                txtLoginCheck.InnerText = "아이디와 비밀번호를 모두 \r\n입력해주세요.";
            }

            else
            {
                if (isLogin == true)
                {
                    txtLoginCheck.Attributes.Add("style", "visibility: visible");
                    txtLoginCheck.InnerText = "로그인 성공!";
                }

                else
                {
                    txtLoginCheck.Attributes.Add("style", "visibility: visible");
                    txtLoginCheck.InnerText = "가입하지 않은 아이디이거나," + "\r\n" +"잘못된 비밀번호입니다.";
                }
            }
        }
        

    }
}