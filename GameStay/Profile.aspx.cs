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
        static UserDo userDo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["아이디"] == null)
                {
                    Response.Redirect("RequestLogin.aspx");
                }
                else
                {
                    string uid = Session["아이디"].ToString();

                    userDo = (new UserDao()).GetUserInfo(uid);
                    txt_nickname.InnerText = userDo.Nickname;
                    txt_level.InnerText = userDo.Level.ToString();
                    if(userDo.Profileimg.Trim() != "")
                    {
                        img_profile.Src = userDo.Profileimg;
                    }
                    else
                    {
                        img_profile.Src = "/Images/Profile/Default_Profile.png";
                    }
                    
                }
            }
        }
        protected void editprofile_click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileEdit.aspx");
        }

        
    }
}