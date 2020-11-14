using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStay
{
    public partial class SuccessPurchase : System.Web.UI.Page
    {
        string gameTitle;
        DBManager dbManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbManager = new DBManager();
            gameTitle = Request["title"];
            p_content.InnerText = "이제 " + dbManager.GetGameKorTitle(gameTitle) + "를 플레이하실 수 있습니다.";
            bg_image.Src = "Images/GameIntroImages/IntroImage_" + gameTitle + "_1.jpg";
            if (Request["__EVENTTARGET"] == "p_goStore")
            {
                Response.Redirect("Store_ProductDetail.aspx?title=" + gameTitle);
            }
        }
    }
}