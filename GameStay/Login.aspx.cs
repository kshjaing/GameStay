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

            UserDao uDao = new UserDao();
            if (uDao.Authenticate(inputID.Value.ToString(), inputPassword.Value.ToString()))
            {
                Session["아이디"] = inputID.Value.ToString();
                Session["닉네임"] = dbManager.GetNickName(Session["아이디"].ToString());
                Session["접속경로"] = "USER";
                Response.Redirect("Store_main.aspx");
            }
            else
            {
                inputID.Value = "";
                txtLoginCheck.Attributes.Add("style", "visibility: visible");
                txtLoginCheck.InnerText = "가입하지 않은 아이디이거나, 잘못된 비밀번호입니다.";
            }
        }
        

    }
}