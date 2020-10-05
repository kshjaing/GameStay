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
            SqlDataAdapter discountAdapter = dbManager.SetDiscountAdapter();   //할인게임 어댑터

            //추천게임 바인딩
            DataTable dt = new DataTable();
            featureAdapter.Fill(dt);
            featuresRepeater1.DataSource = dt;
            featuresRepeater1.DataBind();
            featuresRepeater2.DataSource = dt;
            featuresRepeater2.DataBind();


            //할인게임 바인딩
            DataTable dt2 = new DataTable();
            discountAdapter.Fill(dt2);
            discountRepeater1.DataSource = dt2;
            discountRepeater1.DataBind();
<<<<<<< HEAD

=======
            
>>>>>>> parent of 54250e2... 로그인
            dbManager.DBClose();


            //특집및추천 전체div 클릭 이벤트
            if (Request["__EVENTTARGET"] == "div_wrap_features")
            {
                Response.Redirect("Store_ProductDetail.aspx");
            }
        }

    }
}