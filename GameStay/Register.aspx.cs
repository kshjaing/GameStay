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

        static bool isIdCheck = false;
        UserDao uDao;

        protected void Register_OnClick(object sender, EventArgs e)
        {
            
            uDao = new UserDao();

            UserDo uDo = new UserDo(inputID.Value.ToString(), inputPassword.Value.ToString(), inputNickname.Value.ToString() , inputEmail.Value.ToString());

            
            if (inputID.Value.Length < 1)
            {
                inputID.Focus();
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "아이디를 입력해주세요.";
                return;
            }
            else if (inputPassword.Value.Length < 1)
            {
                inputPassword.Focus();
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "비밀번호를 입력해주세요.";
                return;
            }
            else if (inputPassword.Value != inputPasswordDupl.Value)
            {
                inputPassword.Focus();
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "비밀번호가 일치하지 않습니다.";
                return;
            }
            else if (inputNickname.Value.Length < 1)
            {
                inputNickname.Focus();
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "닉네임을 입력해주세요.";
                return;
            }
            else if (inputEmail.Value.Length < 1)
            {
                inputEmail.Focus();
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "이메일을 입력해주세요.";
                return;
            }
            else if (isIdCheck = uDao.VerifyID(inputID.Value.ToString()))
            {
                uDao = new UserDao();
                uDao.RegistUser(uDo);
                Response.Redirect("SuccessRegist.aspx");
            }
            else
            {
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "이미 사용중인 ID 입니다.";
                inputID.Value = "";
                inputID.Focus();
                return;
            }
        }
    }
}