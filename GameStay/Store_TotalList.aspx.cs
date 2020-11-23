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
    public partial class Store_TotalList : System.Web.UI.Page
    {
        DBManager dbManager;
        SqlDataAdapter titleAdapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbManager = new DBManager();
            if (Request["sort"] == "discount")
            {
                titleAdapter = dbManager.SetDiscountTotalGameAdapter();
            }

            else if (Request["sort"] == "rating")
            {
                titleAdapter = dbManager.SetRatingTotalGameAdapter();
            }

            else if (Request["sort"] == "release")
            {
                titleAdapter = dbManager.SetReleaseTotalGameAdapter();
            }

            DataTable dt = new DataTable();
            titleAdapter.Fill(dt);
            titleRepeater.DataSource = dt;
            titleRepeater.DataBind();
            

            dbManager.DBClose();
        }
    }
}