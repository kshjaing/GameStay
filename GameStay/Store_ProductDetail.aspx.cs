using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Services;

namespace GameStay
{
    public partial class Store_ProductDetail : System.Web.UI.Page
    {
        DBManager dbManager;
        SqlDataAdapter detailTitleAdapter;
        SqlDataAdapter detailImageAdapter;
        SqlDataAdapter detailVideoAdapter;
        SqlDataAdapter detailMinRequireAdapter;
        SqlDataAdapter detailRecRequireAdapter;
        SqlDataAdapter detailReviewAdapter;
        string gameTitle;
        int mediaCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbManager = new DBManager();
            //주소창에서 영어게임명 추출
            gameTitle = Request["title"];
            //gameTitle = Request.Url.ToString().Substring(Request.Url.ToString().IndexOf("=") + 1);

            detailTitleAdapter = dbManager.SetGameTitleAdapter(gameTitle);
            detailImageAdapter = dbManager.SetGameIntroImageAdapter(gameTitle);
            detailVideoAdapter = dbManager.SetGameIntroVideoAdapter(gameTitle);
            detailMinRequireAdapter = dbManager.SetMinReqAdapter(gameTitle);
            detailRecRequireAdapter = dbManager.SetRecReqAdapter(gameTitle);
            detailReviewAdapter = dbManager.SetReviewAdapter(gameTitle);

            DataTable titleDT = new DataTable();
            detailTitleAdapter.Fill(titleDT);
            detailTitleRepeater1.DataSource = titleDT;
            detailTitleRepeater1.DataBind();
            detailTitleRepeater2.DataSource = titleDT;
            detailTitleRepeater2.DataBind();

            DataTable imageDT = new DataTable();
            detailImageAdapter.Fill(imageDT);
            detailImageRepeater.DataSource = imageDT;
            detailImageRepeater.DataBind();

            DataTable videoDT = new DataTable();
            detailVideoAdapter.Fill(videoDT);
            detailVideoRepeater.DataSource = videoDT;
            detailVideoRepeater.DataBind();

            /*
            HtmlControl mainframe = (HtmlControl)this.FindControl("main_video");
            mainframe.Attributes["src"] = GetMainVideo();*/


            DataTable minreqDT = new DataTable();
            detailMinRequireAdapter.Fill(minreqDT);
            detailMinRequireRepeater.DataSource = minreqDT;
            detailMinRequireRepeater.DataBind();

            DataTable recreqDT = new DataTable();
            detailRecRequireAdapter.Fill(recreqDT);
            detailRecRequireRepeater.DataSource = recreqDT;
            detailRecRequireRepeater.DataBind();

            DataTable reviewDT = new DataTable();
            detailReviewAdapter.Fill(reviewDT);
            detailReviewRepeater.DataSource = reviewDT;
            detailReviewRepeater.DataBind();

            

            dbManager.DBClose();

            if (Session["아이디"] == null)
            {

            }
            else
            {
                dbManager.GetNickName(Session["아이디"].ToString());
            }
        }

        public void divSmallImages_Resize(object sender, EventArgs e)
        {
            //특정게임이 갖고있는 소개영상과 스샷의 총 개수
            //그 개수에 따라 동적으로 div의 너비를 적용
            mediaCount = dbManager.IntCountImgVid(gameTitle);
            div_wrap_small_boxes.Style["width"] = 187.5 * mediaCount + 4 * mediaCount + "px";
        }

        public void SetProfileImage()
        {
            img_review_write_profile.Attributes["src"] = dbManager.GetProfileImage(Session["아이디"].ToString());
        }
    }
}