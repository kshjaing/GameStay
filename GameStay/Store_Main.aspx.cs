using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace GameStay
{
    public partial class Store_Main : System.Web.UI.Page
    {
        SqlDataAdapter featureAdapter;
        SqlDataAdapter discountCountAdpater;
        SqlDataAdapter discountAdapter1;
        SqlDataAdapter discountAdapter2;
        SqlDataAdapter discountAdapter3;
        SqlDataAdapter discountAdapter4;
        SqlDataAdapter bestgamesAdapter;
        SqlDataAdapter newgamesAdapter;
        DBManager dbManager;
        DataTable bestDT;
        DataTable newDT;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbManager = new DBManager();
            featureAdapter = dbManager.SetFeaturesAdapter();              //추천게임 어댑터
            discountCountAdpater = dbManager.SetDiscountCountAdapter();   //할인게임 총 개수 어댑터
            discountAdapter1 = dbManager.SetDiscountAdapter1();           //할인게임 어댑터 1페이지
            discountAdapter2 = dbManager.SetDiscountAdapter2();           //할인게임 어댑터 2페이지
            discountAdapter3 = dbManager.SetDiscountAdapter3();           //할인게임 어댑터 3페이지
            discountAdapter4 = dbManager.SetDiscountAdapter4();           //할인게임 어댑터 4페이지
            bestgamesAdapter = dbManager.SetBestGamesAdapter();           //최고인기게임 어댑터
            newgamesAdapter = dbManager.SetNewGamesAdapter();             //신규출시게임 어댑터
            


            //추천게임 바인딩
            DataTable dt = new DataTable();
            featureAdapter.Fill(dt);
            featuresRepeater1.DataSource = dt;
            featuresRepeater1.DataBind();
            featuresRepeater2.DataSource = dt;
            featuresRepeater2.DataBind();



            //-------------------할인게임파트---------------------//
            //할인게임 개수 바인딩
            DataTable countDT = new DataTable();
            discountCountAdpater.Fill(countDT);
            countDiscountRepeater.DataSource = countDT;
            countDiscountRepeater.DataBind();


            //할인게임 1페이지 바인딩
            DataTable dt1 = new DataTable();
            discountAdapter1.Fill(dt1);
            discountRepeater1.DataSource = dt1;
            discountRepeater1.DataBind();

            //할인게임 2페이지 바인딩
            DataTable dt2 = new DataTable();
            discountAdapter2.Fill(dt2);
            discountRepeater2.DataSource = dt2;
            discountRepeater2.DataBind();

            //할인게임 3페이지 바인딩
            DataTable dt3 = new DataTable();
            discountAdapter3.Fill(dt3);
            discountRepeater3.DataSource = dt3;
            discountRepeater3.DataBind();

            //할인게임 4페이지 바인딩
            DataTable dt4 = new DataTable();
            discountAdapter4.Fill(dt4);
            discountRepeater4.DataSource = dt4;
            discountRepeater4.DataBind();



            //---------------------인기게임 파트----------------------//
            bestDT = new DataTable();
            bestgamesAdapter.Fill(bestDT);
            bestgamesRepeater.DataSource = bestDT;
            bestgamesRepeater.DataBind();


            dbManager.DBClose();


            //특집및추천 전체div 클릭 이벤트
            if (Request["__EVENTTARGET"] == "div_wrap_features")
            {
                Response.Redirect("Store_ProductDetail.aspx");
            }

            if (Request["__EVENTTARGET"] == "div_discount_contentbox1")
            {
                Response.Redirect("Store_ProductDetail.aspx");
            }

            if (Request["__EVENTTARGET"] == "div_discount_contentbox2")
            {
                Response.Redirect("Store_ProductDetail.aspx");
            }

            if (Request["__EVENTTARGET"] == "div_discount_contentbox3")
            {
                Response.Redirect("Store_ProductDetail.aspx");
            }

            if (Request["__EVENTTARGET"] == "div_discount_contentbox4")
            {
                Response.Redirect("Store_ProductDetail.aspx");
            }
        }

        public void NewGames_Click()
        {
            newDT = new DataTable();
            newgamesAdapter = dbManager.SetNewGamesAdapter();
            newgamesAdapter.Fill(newDT);
            bestgamesRepeater.DataSource = newDT;
            bestgamesRepeater.DataBind();
            div_wrap_p_bestgames.Style["background"] = "transparent";
            div_wrap_p_newgames.Style["background"] = "1B1C1E";
        }

        public void BestGames_Click()
        {
            bestgamesAdapter = dbManager.SetBestGamesAdapter();
            bestgamesAdapter.Fill(bestDT);
            bestgamesRepeater.DataSource = bestDT;
            bestgamesRepeater.DataBind();
            div_wrap_p_bestgames.Style["background"] = "1B1C1E";
            div_wrap_p_newgames.Style["background"] = "transparent";
        }
    }
}