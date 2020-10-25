﻿using System;
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
        string gameTitle;
        string mainVidLink;
        int mediaCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbManager = new DBManager();
            gameTitle = Request.Url.ToString().Substring(Request.Url.ToString().IndexOf("=") +  1);

            detailTitleAdapter = dbManager.SetGameTitleAdapter(gameTitle);
            detailImageAdapter = dbManager.SetGameIntroImageAdapter(gameTitle);
            detailVideoAdapter = dbManager.SetGameIntroVideoAdapter(gameTitle);

            DataTable titleDT = new DataTable();
            detailTitleAdapter.Fill(titleDT);
            detailTitleRepeater1.DataSource = titleDT;
            detailTitleRepeater1.DataBind();
            detailTitleRepeater2.DataSource = titleDT;
            detailTitleRepeater2.DataBind();
            detailTitleRepeater3.DataSource = titleDT;
            detailTitleRepeater3.DataBind();

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

            

            dbManager.DBClose();

        }

        public void divSmallImages_Resize(object sender, EventArgs e)
        {
            //특정게임이 갖고있는 소개영상과 스샷의 총 개수
            //그 개수에 따라 동적으로 div의 너비를 적용
            mediaCount = dbManager.IntCountImgVid(gameTitle);
            div_wrap_small_boxes.Style["width"] = 187.5 * mediaCount + 4 * mediaCount + "px";
        }


    }
}