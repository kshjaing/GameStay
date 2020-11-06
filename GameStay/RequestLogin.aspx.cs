using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GameStay
{
	public partial class RequestLogin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request["before"] == "Library")
            {
				p_guide.InnerText = "라이브러리를 이용하시려면 로그인해주세요.";
				(this.Master.FindControl("div_library") as HtmlControl).Style["box-sizing"] = "border-box";
				(this.Master.FindControl("div_library") as HtmlControl).Style["border-bottom"] = "5px solid #85cba5";
				(this.Master.FindControl("div_store") as HtmlControl).Style["box-sizing"] = "unset";
				(this.Master.FindControl("div_store") as HtmlControl).Style["border-bottom"] = "unset";
				(this.Master.FindControl("div_community") as HtmlControl).Style["box-sizing"] = "unset";
				(this.Master.FindControl("div_community") as HtmlControl).Style["border-bottom"] = "unset";
				(this.Master.FindControl("div_profile") as HtmlControl).Style["box-sizing"] = "unset";
				(this.Master.FindControl("div_profile") as HtmlControl).Style["border-bottom"] = "unset";

			}
			else if (Request["before"] == "Profile")
            {
				p_guide.InnerText = "프로필을 이용하시려면 로그인해주세요.";
				(this.Master.FindControl("div_profile") as HtmlControl).Style["box-sizing"] = "border-box";
				(this.Master.FindControl("div_profile") as HtmlControl).Style["border-bottom"] = "5px solid #85cba5";
				(this.Master.FindControl("div_library") as HtmlControl).Style["box-sizing"] = "unset";
				(this.Master.FindControl("div_library") as HtmlControl).Style["border-bottom"] = "unset";
				(this.Master.FindControl("div_community") as HtmlControl).Style["box-sizing"] = "unset";
				(this.Master.FindControl("div_community") as HtmlControl).Style["border-bottom"] = "unset";
				(this.Master.FindControl("div_store") as HtmlControl).Style["box-sizing"] = "unset";
				(this.Master.FindControl("div_store") as HtmlControl).Style["border-bottom"] = "unset";
			}

			else if (Request["before"] == "DevProfile")
            {
				p_guide.InnerText = "개발사프로필을 이용하시려면 로그인해주세요.";
				(this.Master.FindControl("div_profile") as HtmlControl).Style["box-sizing"] = "border-box";
				(this.Master.FindControl("div_profile") as HtmlControl).Style["border-bottom"] = "5px solid #85cba5";
				(this.Master.FindControl("div_library") as HtmlControl).Style["box-sizing"] = "unset";
				(this.Master.FindControl("div_library") as HtmlControl).Style["border-bottom"] = "unset";
				(this.Master.FindControl("div_community") as HtmlControl).Style["box-sizing"] = "unset";
				(this.Master.FindControl("div_community") as HtmlControl).Style["border-bottom"] = "unset";
				(this.Master.FindControl("div_store") as HtmlControl).Style["box-sizing"] = "unset";
				(this.Master.FindControl("div_store") as HtmlControl).Style["border-bottom"] = "unset";
			}

			if (Request["__EVENTTARGET"] == "p_goLogin")
			{
				if (Request["before"] == "DevProfile")
                {
					Response.Redirect("DevLogin.aspx");
                }
				else
				Response.Redirect("Login.aspx");
			}
		}

	}
}