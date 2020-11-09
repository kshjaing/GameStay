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
    public partial class RegistGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DateTime.Now.ToString("MM");
            if (!IsPostBack)
            {
                if (Session["아이디"] == null)
                {
                    Response.Redirect("RequestLogin.aspx");
                }
                else
                {
                    DBManager dbManager = new DBManager();
                    txt_manageinfo.InnerText = DateTime.Now.ToString("MM");
                    string id = Session["아이디"].ToString().TrimEnd();

                    SqlDataAdapter devincome = dbManager.SetDevIncome(id);

                    DataTable dt1 = new DataTable();
                    devincome.Fill(dt1);
                    DevInfo.DataSource = dt1;
                    DevInfo.DataBind();

                    SqlDataAdapter devinfo = dbManager.SetDevInfo(id);
                    //개발사 정보 
                    DataTable dt4 = new DataTable();
                    devinfo.Fill(dt4);
                    Devname.DataSource = dt4;
                    Devname.DataBind();

                    SqlDataAdapter gamelist = dbManager.SetDevGameList(id);
                    DataTable gldt = new DataTable();
                    gamelist.Fill(gldt);
                    Devgamelist.DataSource = gldt;
                    Devgamelist.DataBind();
                }
            }
        }

        //editGame_click
        protected void uploadGame_click(object sender, EventArgs e)
        {
            //게임  등록 수정페이지
            Response.Redirect("UploadGame.aspx");
        }
        protected void editGame_click(object sender, EventArgs e)
        {
            //게임  등록 수정페이지
            Response.Redirect("UploadGame.aspx");
        }
    }
}