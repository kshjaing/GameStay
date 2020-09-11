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
            img_store.Attributes["style"] = "visibility: visible";
            img_library.Attributes["style"] = "visibility: hidden";
            img_community.Attributes["style"] = "visibility: hidden";
            img_profile.Attributes["style"] = "visibility: hidden";
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