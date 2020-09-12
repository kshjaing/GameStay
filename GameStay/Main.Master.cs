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
                img_store.Style["visibility"] = "visible";
                img_library.Style["visibility"] = "hidden";
                img_community.Style["visibility"] = "hidden";
                img_profile.Style["visibility"] = "hidden";
            }
            else if (Request.Url.ToString().Contains("Library.aspx"))
            {
                img_store.Style["visibility"] = "hidden";
                img_library.Style["visibility"] = "visible";
                img_community.Style["visibility"] = "hidden";
                img_profile.Style["visibility"] = "hidden";
            }
            else if (Request.Url.ToString().Contains("Community.aspx"))
            {
                img_store.Style["visibility"] = "hidden";
                img_library.Style["visibility"] = "hidden";
                img_community.Style["visibility"] = "visible";
                img_profile.Style["visibility"] = "hidden";
            }
            else if (Request.Url.ToString().Contains("Profile.aspx"))
            {
                img_store.Style["visibility"] = "hidden";
                img_library.Style["visibility"] = "hidden";
                img_community.Style["visibility"] = "hidden";
                img_profile.Style["visibility"] = "visible";
            }
        }

        protected void StoreMenu_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Store_Main.aspx");

        }
        protected void LibraryMenu_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Library.aspx");
        }
        protected void CommunityMenu_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Community.aspx");
        }
        protected void ProfileMenu_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}