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


            if (inputID.Value.Length <= 0)
            {
                inputID.Focus();
            }
            if(isIdCheck = uDao.VerifyID(inputID.Value.ToString()) || uDao.RegistUser(uDo) == 1)
            {
                

                uDao = new UserDao();
                uDao.RegisterUserQry(uDo);
                Response.Redirect("SuccessRegist.aspx");
            }
            else
            {
                txtRegistCheck.Visible = true;
                inputID.Value = "";
                inputID.Focus();
            }
            
        }
    }
}