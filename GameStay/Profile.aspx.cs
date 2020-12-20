using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
                    Response.Redirect("RequestLogin.aspx?before=Profile");
                }
                else
                {
                    (this.Master.FindControl("button_login") as HtmlButton).InnerText = "로그아웃";

                    if (Request["id"] != null)
                    {
                        if (Request["id"].ToString().TrimEnd().Equals(Session["아이디"].ToString().TrimEnd()))
                        {
                            wrap_edit_p.Style["visibility"] = "visible";
                            DropDownList1.Style["visibility"] = "visible";
                            FileUpload1.Style["visibility"] = "visible";
                            btn_upload.Style["visibility"] = "visible";
                            DropDownList1.SelectedIndex = 0;
                        }

                        else
                        {
                            wrap_edit_p.Style["visibility"] = "hidden";
                            DropDownList1.Style["visibility"] = "hidden";
                            FileUpload1.Style["visibility"] = "hidden";
                            btn_upload.Style["visibility"] = "hidden";
                        }
                        DBManager dbManager = new DBManager();
                        SqlDataAdapter recentAdapter1 = dbManager.SetRecentAdapter1(Request["id"].ToString().TrimEnd());
                        
                        SqlDataAdapter userinfo = dbManager.SetUserInfo(Request["id"].ToString().TrimEnd());

                        SqlDataAdapter screen = dbManager.SetScreenShot(Request["id"].ToString().TrimEnd());

                        SqlDataAdapter screengame = dbManager.SetScreenShotGame(Session["아이디"].ToString().TrimEnd());

                        DataTable dt1 = new DataTable();
                        recentAdapter1.Fill(dt1);
                        RecentGame1.DataSource = dt1;
                        RecentGame1.DataBind();
                       
                        DataTable dt4 = new DataTable();
                        userinfo.Fill(dt4);
                        UserInfo.DataSource = dt4;
                        UserInfo.DataBind();

                        DataTable dt2 = new DataTable();
                        screen.Fill(dt2);
                        ScreenShot.DataSource = dt2;
                        ScreenShot.DataBind();

                        DataTable dt3 = new DataTable();
                        screengame.Fill(dt3);
                        DropDownList1.DataSource = dt3;
                        DropDownList1.DataTextField = "영어게임명";
                        DropDownList1.DataBind();

                        //소유한 게임 수
                        txt_profile_countgame.InnerText = dbManager.GetHasGameCount(Request["id"].ToString()).ToString();
                        dbManager.DBClose();
                    }
                    else
                    {
                        Response.Redirect("Profile.aspx?id=" + Session["아이디"]);
                    }
                }
            }

            if (Request["__EVENTTARGET"] == "wrap_edit_p")
            {
                Response.Redirect("ProfileEdit.aspx");
            }
        }


        

        protected void btn_upload_click(object sender, EventArgs e)
        {
            if(FileUpload1.ClientID.Length < 1)
            {
                return;
            }
            string uid = Session["아이디"].ToString();
            string title = DropDownList1.SelectedValue.ToString();
            string fname = "Images/ScreenShot/" + uid.ToString() + "_" + DateTime.Now.ToString("yyyymmddhhmmss") + ".jpg";

            UserDao udo = new UserDao();
            udo.uploadimg(title, uid, fname);
            FileUpload1.SaveAs(Server.MapPath(@"" + fname.ToString()));
        }
    }
}