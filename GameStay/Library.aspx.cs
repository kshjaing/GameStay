using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GameStay
{
    public partial class Library : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["아이디"] == null)
                {
                    Response.Redirect("RequestLogin.aspx?before=Library");
                }
                else
                {
                    DBManager dbManager = new DBManager();
                    string uid = Session["아이디"].ToString();
                    (this.Master.FindControl("button_login") as HtmlButton).InnerText = "로그아웃";
                    SqlDataAdapter liblist = dbManager.SetLibrary(uid);
                    
                    DataTable dt = new DataTable();
                    liblist.Fill(dt);
                    library_list.DataSource = dt;
                    library_list.DataBind();
                }
            }
        }
    }
}