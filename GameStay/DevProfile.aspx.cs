using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
/* application 변수는 웹사이트 실행중일때 모두 공유되는 객체
 * request 사용자가 사이트에 존제하는 객체
 * session 사용자가 접속중일때 혼자 사용하는 객체
 * 
 */
namespace GameStay
{
    public partial class DevProfile : System.Web.UI.Page
    {
        static DevDo dDo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["아이디"] == null)
                {
                    Response.Redirect("RequestLogin.aspx?before=DevProfile");
                }
                else
                {
                    if (Request["id"] != null)//주소창에 아이디 있을때
                    {
                        (this.Master.FindControl("button_login") as HtmlButton).InnerText = "로그아웃";

                        if (Request["id"].ToString().TrimEnd().Equals(Session["아이디"].ToString().TrimEnd()))//주소창 아이디와 사용자 아이디 같을 때
                        {
                            btn_profile_edit.Attributes.Add("style", "visibility: visible");
                        }
                        else//주소창 아이디와 사용자 아이디 다를때
                        {
                            btn_profile_edit.Attributes.Add("style", "visibility: hidden");
                        }
                        DBManager dbManager = new DBManager();

                        string id = Request["id"].ToString().TrimEnd();

                        SqlDataAdapter devinfo = dbManager.SetDevInfo(id);

                        DataTable dt4 = new DataTable();
                        devinfo.Fill(dt4);
                        DevInfo.DataSource = dt4;
                        DevInfo.DataBind();
                        DevInfo1.DataSource = dt4;
                        DevInfo1.DataBind();

                        SqlDataAdapter newgame1 = dbManager.SetDevNewGame1(id);
                        DataTable ngdt1 = new DataTable();
                        newgame1.Fill(ngdt1);
                        NewGame1.DataSource = ngdt1;
                        NewGame1.DataBind();

                        SqlDataAdapter newgame2 = dbManager.SetDevNewGame2(id);
                        DataTable ngdt2 = new DataTable();
                        newgame2.Fill(ngdt2);
                        NewGame2.DataSource = ngdt2;
                        NewGame2.DataBind();

                        SqlDataAdapter newgame3 = dbManager.SetDevNewGame3(id);
                        DataTable ngdt3 = new DataTable();
                        newgame3.Fill(ngdt3);
                        NewGame3.DataSource = ngdt3;
                        NewGame3.DataBind();

                        SqlDataAdapter newgame4 = dbManager.SetDevNewGame4(id);
                        DataTable ngdt4 = new DataTable();
                        newgame4.Fill(ngdt4);
                        NewGame4.DataSource = ngdt4;
                        NewGame4.DataBind();

                    }
                    else //주소창에 아이디 없을 때
                    {
                        Response.Redirect("DevProfile.aspx?id=" + Session["아이디"]);
                    }

                }
            }
        }

        public string GetDevImg(object uid, object fname)
        {
            return @"~\Images\Profile\" + dDo.Userid.Substring(fname.ToString().IndexOf("."));
        }

        protected void editprofile_click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileEdit.aspx");
        }
    }
}