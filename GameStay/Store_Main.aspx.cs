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
            SqlDataAdapter featureAdapter = dbManager.SetFeaturesAdapter();    //추천게임 어댑터
            SqlDataAdapter discountAdapter1 = dbManager.SetDiscountAdapter1();   //할인게임 어댑터 1페이지

            //추천게임 바인딩
            DataTable dt = new DataTable();
            featureAdapter.Fill(dt);
            featuresRepeater1.DataSource = dt;
            featuresRepeater1.DataBind();
            featuresRepeater2.DataSource = dt;
            featuresRepeater2.DataBind();


            //할인게임 바인딩
            DataTable dt1 = new DataTable();
            discountAdapter1.Fill(dt1);
            discountRepeater1.DataSource = dt1;
            discountRepeater1.DataBind();

            dbManager.DBClose();


            //특집및추천 전체div 클릭 이벤트
            if (Request["__EVENTTARGET"] == "div_wrap_features")
            {
                Response.Redirect("Store_ProductDetail.aspx");
            }
        }

    }
}