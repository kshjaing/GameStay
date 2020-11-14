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
    public partial class BuyGame : System.Web.UI.Page
    {
        DBManager dbManager;
        SqlDataAdapter titleAdapter;
        string gameTitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbManager = new DBManager();
            gameTitle = Request["title"];
            titleAdapter = dbManager.SetGameTitleAdapter(gameTitle);

            DataTable titleDT = new DataTable();
            titleAdapter.Fill(titleDT);
            titleRepeater.DataSource = titleDT;
            titleRepeater.DataBind();

            if (!IsPostBack)
            {
                Session["구매예정"] = gameTitle;

                if (Session["아이디"] != null)
                {
                    (this.Master.FindControl("button_login") as HtmlButton).InnerText = "로그아웃";
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

            //구매버튼 클릭이벤트
            if (Request["__EVENTTARGET"] == "buy_button")
            {

            }
        }
    }
}