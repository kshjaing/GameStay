using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStay
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Url.ToString().Contains("Store_Main.aspx"))
            {
                div_store.Style["box-sizing"] = "border-box";
                div_store.Style["border-bottom"] = "5px solid #85cba5";
                div_library.Style["box-sizing"] = "unset";
                div_library.Style["border-bottom"] = "unset";
                div_community.Style["box-sizing"] = "unset";
                div_community.Style["border-bottom"] = "unset";
                div_profile.Style["box-sizing"] = "unset";
                div_profile.Style["border-bottom"] = "unset";
            }
            else if (Request.Url.ToString().Contains("Library.aspx"))
            {
                div_library.Style["box-sizing"] = "border-box";
                div_library.Style["border-bottom"] = "5px solid #85cba5";
                div_store.Style["box-sizing"] = "unset";
                div_store.Style["border-bottom"] = "unset";
                div_community.Style["box-sizing"] = "unset";
                div_community.Style["border-bottom"] = "unset";
                div_profile.Style["box-sizing"] = "unset";
                div_profile.Style["border-bottom"] = "unset";
            }
            else if (Request.Url.ToString().Contains("Community.aspx"))
            {
                div_community.Style["box-sizing"] = "border-box";
                div_community.Style["border-bottom"] = "5px solid #85cba5";
                div_store.Style["box-sizing"] = "unset";
                div_store.Style["border-bottom"] = "unset";
                div_library.Style["box-sizing"] = "unset";
                div_library.Style["border-bottom"] = "unset";
                div_profile.Style["box-sizing"] = "unset";
                div_profile.Style["border-bottom"] = "unset";
            }
            else if (Request.Url.ToString().Contains("Profile.aspx"))
            {
                div_profile.Style["box-sizing"] = "border-box";
                div_profile.Style["border-bottom"] = "5px solid #85cba5";
                div_library.Style["box-sizing"] = "unset";
                div_library.Style["border-bottom"] = "unset";
                div_community.Style["box-sizing"] = "unset";
                div_community.Style["border-bottom"] = "unset";
                div_store.Style["box-sizing"] = "unset";
                div_store.Style["border-bottom"] = "unset";
            }
        }

        protected void StoreMenu_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Store_Main.aspx");
            button_store.Style["background"] = "#85cba5";
        }
        protected void LibraryMenu_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Library.aspx");
            button_library.Style["background"] = "#85cba5";
        }
        protected void CommunityMenu_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Community.aspx");
            button_community.Style["background"] = "#85cba5";
        }
        protected void ProfileMenu_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
            button_profile.Style["background"] = "#85cba5";
        }

        protected void Login_OnClick(object sender, EventArgs e)
        {
            if(Session["아이디"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //로그아웃
                Session["아이디"] = null;
                
            }
            
        }
    }
}