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
        bool checkHasGame;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbManager = new DBManager();
            gameTitle = Request["title"];
            titleAdapter = dbManager.SetGameTitleAdapter(gameTitle);
            checkHasGame = dbManager.CheckHasGame(Session["아이디"].ToString(), gameTitle);

            DataTable titleDT = new DataTable();
            titleAdapter.Fill(titleDT);
            titleRepeater.DataSource = titleDT;
            titleRepeater.DataBind();

            if (!IsPostBack)
            {
                //Login.aspx 로그인버튼에서 체크
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
                if (checkHasGame == false)
                {
                    dbManager.PurchaseGame(Session["아이디"].ToString(), dbManager.GetKorGameTitle(gameTitle), gameTitle, dbManager.GetDiscountedPrice(gameTitle));
                    Response.Redirect("SuccessPurchase.aspx?title=" + gameTitle);
                }
                else return;
                dbManager.DBClose();
            }
        }
    }
}