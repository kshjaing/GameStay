using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                if (Request["아이디"] != null)
                {
                    string uid = Request["아이디"];

                    userDo = (new UserDao()).Getprofileimg(uid);
                    if (userDo.Profileimg.Trim() != "")
                    {
                        img_profile.Src = userDo.Profileimg;
                    }
                    else
                    {
                        img_profile.Src = "/Images/Profile/Default_Profile.png";
                    }
                    DBManager dbManager = new DBManager();
                    SqlDataAdapter recentAdapter1 = dbManager.SetRecentAdapter1(uid);
                    SqlDataAdapter recentAdapter2 = dbManager.SetRecentAdapter2(uid);
                    SqlDataAdapter recentAdapter3 = dbManager.SetRecentAdapter3(uid);
                    SqlDataAdapter userinfo = dbManager.SetUserInfo(uid);

                    DataTable dt1 = new DataTable();
                    recentAdapter1.Fill(dt1);
                    RecentGame1.DataSource = dt1;
                    RecentGame1.DataBind();

                    DataTable dt2 = new DataTable();
                    recentAdapter2.Fill(dt2);
                    RecentGame2.DataSource = dt2;
                    RecentGame2.DataBind();

                    DataTable dt3 = new DataTable();
                    recentAdapter3.Fill(dt3);
                    RecentGame3.DataSource = dt3;
                    RecentGame3.DataBind();

                    DataTable dt4 = new DataTable();
                    userinfo.Fill(dt4);
                    UserInfo.DataSource = dt4;
                    UserInfo.DataBind();
                }
                else
                {
                    btn_profile_edit.Attributes.Add("style", "visibility: visible");
                    string uid = Session["아이디"].ToString();
                    userDo = (new UserDao()).Getprofileimg(uid);
                    if (userDo.Profileimg.Trim() != "")
                    {
                        img_profile.Src = userDo.Profileimg;
                    }
                    else
                    {
                        img_profile.Src = "/Images/Profile/Default_Profile.png";
                    }

                    DBManager dbManager = new DBManager();
                    SqlDataAdapter recentAdapter1 = dbManager.SetRecentAdapter1(uid);
                    SqlDataAdapter recentAdapter2 = dbManager.SetRecentAdapter2(uid);
                    SqlDataAdapter recentAdapter3 = dbManager.SetRecentAdapter3(uid);
                    SqlDataAdapter userinfo = dbManager.SetUserInfo(uid);

                    DataTable dt1 = new DataTable();
                    recentAdapter1.Fill(dt1);
                    RecentGame1.DataSource = dt1;
                    RecentGame1.DataBind();

                    DataTable dt2 = new DataTable();
                    recentAdapter2.Fill(dt2);
                    RecentGame2.DataSource = dt2;
                    RecentGame2.DataBind();

                    DataTable dt3 = new DataTable();
                    recentAdapter3.Fill(dt3);
                    RecentGame3.DataSource = dt3;
                    RecentGame3.DataBind();

                    DataTable dt4 = new DataTable();
                    userinfo.Fill(dt4);
                    UserInfo.DataSource = dt4;
                    UserInfo.DataBind();


                }
            }
        }
        protected void editprofile_click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileEdit.aspx");
        }

        
    }
}