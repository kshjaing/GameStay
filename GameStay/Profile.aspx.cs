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
                if (Session["아이디"] == null)
                {
                    Response.Redirect("RequestLogin.aspx");
                }
                else
                {
                    if (Request["id"] != null)
                    {
                        if(Request["id"].ToString().TrimEnd().Equals(Session["아이디"].ToString().TrimEnd()))
                        {
                            btn_profile_edit.Attributes.Add("style", "visibility: visible");
                        }
                        else
                        {
                            btn_profile_edit.Attributes.Add("style", "visibility: hidden");
                        }
                        DBManager dbManager = new DBManager();
                        SqlDataAdapter recentAdapter1 = dbManager.SetRecentAdapter1(Request["id"].ToString().TrimEnd());
                        SqlDataAdapter recentAdapter2 = dbManager.SetRecentAdapter2(Request["id"].ToString().TrimEnd());
                        SqlDataAdapter recentAdapter3 = dbManager.SetRecentAdapter3(Request["id"].ToString().TrimEnd());
                        SqlDataAdapter userinfo = dbManager.SetUserInfo(Request["id"].ToString().TrimEnd());
                        SqlDataAdapter hasGameCount = dbManager.GetHasGameCount(Request["id"].ToString().TrimEnd());

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

                        DataTable countDT = new DataTable();
                        hasGameCount.Fill(countDT);
                        HasGameCountRepeater.DataSource = countDT;
                        HasGameCountRepeater.DataBind();
                    }
                    else
                    {
                        Response.Redirect("Profile.aspx?id=" + Session["아이디"]);
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