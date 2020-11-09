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
        int mediaCount, totalGameReviewCount;
        bool checkHasGame;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbManager = new DBManager();
            //주소창에서 영어게임명 추출
            gameTitle = Request["title"];

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

            //로그인한 유저가 게임을 갖고있는지 체크
            if (Session["아이디"] != null)
            {
                (this.Master.FindControl("button_login") as HtmlButton).InnerText = "로그아웃";
                checkHasGame = dbManager.CheckHasGame(Session["아이디"].ToString(), Request["title"]);
            }


            //로그인이 되어있고 게임을 소유해야만 평가작성 가능
            if (Session["아이디"] == null)
            {
                wrap_total_review_write.Style["display"] = "none";
            }

            else if (Session["아이디"] != null && checkHasGame == false)
            {
                (this.Master.FindControl("button_login") as HtmlButton).InnerText = "로그아웃";
                wrap_total_review_write.Style["display"] = "none";
            }
            else if (Session["아이디"] != null && checkHasGame == true)
            {
                (this.Master.FindControl("button_login") as HtmlButton).InnerText = "로그아웃";
                wrap_total_review_write.Style["display"] = "block";

                img_review_write_profile.Attributes["src"] = dbManager.GetProfileImage(Session["아이디"].ToString());
                p_review_write_nickname.InnerText = Session["닉네임"].ToString();

                //리뷰와 평점을 가져옴
                if (!IsPostBack)
                {
                    textarea_review.InnerText = dbManager.GetMyReview(Session["아이디"].ToString(), gameTitle);
                    input_rating.Value = dbManager.GetRating(Session["아이디"].ToString(), gameTitle).ToString();
                }
            }


            //게임의 총 리뷰수가 8개 초과일때 모든 리뷰 보기 버튼 활성화(상점에선 최대 8개까지 보여줌)
            if (totalGameReviewCount > 8)
                p_review_total.Style["display"] = "block";
            else
                p_review_total.Style["display"] = "none";


            //모든 리뷰 보기 누르면 커뮤니티로 넘어가서 해당게임의 리뷰만 바인딩해서 보여줌
            if (Request["__EVENTTARGET"] == "div_p_review_total")
            {
                Response.Redirect("Community.aspx");
            }

            


            dbManager.DBClose();

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


        //리뷰 개수에 따라 리뷰전체를 감싸는 div 높이 변경
        //**Page_Load보다 Repeater 바인딩이 더 먼저 실행됨**
        public void divTotalReview_Resize(object sender, EventArgs e)
        {
            totalGameReviewCount = dbManager.SetGameReview(gameTitle);
            if (totalGameReviewCount <= 8)
                wrap_total_review.Style["height"] = 250 * totalGameReviewCount + 20 * totalGameReviewCount + "px";
            else
                wrap_total_review.Style["height"] = 2160 + "px";
        }


        //리뷰 게시버튼 클릭이벤트
        protected void ButtonPost_OnClick(object sender, EventArgs e)
        {
            String textarea = textarea_review.InnerText.Replace("\n", "<br>");
            int rating = Convert.ToInt32(input_rating.Value);
            dbManager.PostReview(Session["아이디"].ToString(), gameTitle,
                    textarea, rating);
            Response.Redirect(Request.RawUrl);
        }

        
    }
}