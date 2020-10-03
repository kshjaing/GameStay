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
            SqlDataAdapter dataAdapter = dbManager.SetFeaturesAdapter();

            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            featuresRepeater1.DataSource = dt;
            featuresRepeater1.DataBind();
            featuresRepeater2.DataSource = dt;
            featuresRepeater2.DataBind();
            dbManager.DBClose();


            //특집및추천 전체div 클릭 이벤트
            if (Request["__EVENTTARGET"] == "div_wrap_features")
            {
                Response.Redirect("Store_ProductDetail.aspx");
            }
        }

    }
}