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
            SqlDataAdapter dataAdapter = dbManager.SetFeaturesAdapter("게임타이틀");

            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "게임타이틀");
            featuresRepeater1.DataSource = ds.Tables["게임타이틀"];
            featuresRepeater1.DataBind();
            featuresRepeater2.DataSource = ds.Tables["게임타이틀"];
            featuresRepeater2.DataBind();
            dbManager.DBClose();
        }

        public string GetImageURL(string gametitle)
        {
            DBManager dbManager = new DBManager();
            string imageURL = "";
            string sQuery = "SELECT 메인이미지 FROM 게임타이틀 WHERE 게임명 = '" + gametitle + "'";
            SqlDataReader myReader = dbManager.ExecuteReader(sQuery);
            if (myReader.Read())
            {
                imageURL = myReader.ToString().TrimEnd();

            }
            myReader.Close();
            return imageURL;
        }
    }
}