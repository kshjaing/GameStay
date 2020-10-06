using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace GameStay
{
    public partial class Store_Main : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            DBManager dbManager = new DBManager();
            SqlDataAdapter featureAdapter = dbManager.SetFeaturesAdapter();              //추천게임 어댑터
            SqlDataAdapter discountCountAdpater = dbManager.SetDiscountCountAdapter();   //할인게임 총 개수 어댑터
            SqlDataAdapter discountAdapter1 = dbManager.SetDiscountAdapter1();           //할인게임 어댑터 1페이지
            SqlDataAdapter discountAdapter2 = dbManager.SetDiscountAdapter2();           //할인게임 어댑터 2페이지
            SqlDataAdapter discountAdapter3 = dbManager.SetDiscountAdapter3();           //할인게임 어댑터 3페이지
            SqlDataAdapter discountAdapter4 = dbManager.SetDiscountAdapter4();           //할인게임 어댑터 4페이지

            //추천게임 바인딩
            DataTable dt = new DataTable();
            featureAdapter.Fill(dt);
            featuresRepeater1.DataSource = dt;
            featuresRepeater1.DataBind();
            featuresRepeater2.DataSource = dt;
            featuresRepeater2.DataBind();

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

            dbManager.DBClose();


            //특집및추천 전체div 클릭 이벤트
            if (Request["__EVENTTARGET"] == "div_wrap_features")
            {
                Response.Redirect("Store_ProductDetail.aspx");
            }
        }

    }
}