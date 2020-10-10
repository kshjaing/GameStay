using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStay
{
    public partial class Store_ProductDetail : System.Web.UI.Page
    {
        string gameTitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            gameTitle = Request.Url.ToString().Substring(55);
            h1.InnerText = gameTitle;
        }
    }
}