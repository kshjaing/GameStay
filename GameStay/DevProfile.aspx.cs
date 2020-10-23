using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStay
{
    public partial class DevProfile : System.Web.UI.Page
    {
        static DevDo dDo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["아이디"] == null)
                {
                    Response.Redirect("RequestLogin.aspx");
                }
                else
                {
                    if (Request["아이디"] != null)
                    {
                        string uid = Request["아이디"];

                        DBManager dbManager = new DBManager();

                        SqlDataAdapter devinfo = dbManager.SetDevInfo(uid);

                        DataTable dt4 = new DataTable();
                        devinfo.Fill(dt4);
                        DevInfo.DataSource = dt4;
                        DevInfo.DataBind();
                    }
                    else
                    {
                        string uid = Session["아이디"].ToString();
                        //btn_profile_edit.Attributes.Add("style", "visibility: visible");


                        DBManager dbManager = new DBManager();

                        SqlDataAdapter devinfo = dbManager.SetDevInfo(uid);

                        DataTable dt4 = new DataTable();
                        devinfo.Fill(dt4);
                        DevInfo.DataSource = dt4;
                        DevInfo.DataBind();
                    }

                }
            }
        }
        protected void editprofile_click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileEdit.aspx");
        }
    }
}