using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace GameStay
{
    public partial class Store_ProductDetail : System.Web.UI.Page
    {
        DBManager dbManager;
        SqlDataAdapter detailTitleAdapter;
        SqlDataAdapter detailImageAdapter;
        SqlDataAdapter detailVideoAdapter;
        string gameTitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbManager = new DBManager();
            gameTitle = Request.Url.ToString().Substring(55);

            detailTitleAdapter = dbManager.SetGameTitleAdapter(gameTitle);
            detailImageAdapter = dbManager.SetGameIntroImageAdapter(gameTitle);
            detailVideoAdapter = dbManager.SetGameIntroVideoAdapter(gameTitle);




            DataTable titleDT = new DataTable();
            detailTitleAdapter.Fill(titleDT);
            detailTitleRepeater.DataSource = titleDT;
            detailTitleRepeater.DataBind();

            DataTable imageDT = new DataTable();
            detailImageAdapter.Fill(imageDT);
            detailImageRepeater1.DataSource = imageDT;
            detailImageRepeater1.DataBind();
            detailImageRepeater2.DataSource = imageDT;
            detailImageRepeater2.DataBind();

            DataTable videoDT = new DataTable();
            detailVideoAdapter.Fill(videoDT);
            detailVideoRepeater1.DataSource = videoDT;
            detailVideoRepeater1.DataBind();
            detailVideoRepeater2.DataSource = videoDT;
            detailVideoRepeater2.DataBind();


        }

        public void divSmallImages_Resize(object sender, EventArgs e)
        {
            //특정게임이 갖고있는 소개영상과 스샷의 총 개수
            //그 개수에 따라 동적으로 div의 너비를 적용
            int mediaCount = dbManager.IntCountImgVid(gameTitle);
            div_wrap_small_boxes.Style["width"] = 187.5 * mediaCount + 4 * mediaCount + "px";
        }

        public void SmallImage_OnBind(object sender, EventArgs e)
        {
            
        }
    }
}