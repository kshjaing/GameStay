using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStay
{
    public partial class DevRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["__EVENTTARGET"] == "div_logo")
            {
                Response.Redirect("Store_Main.aspx");
            }


        }

        static bool isIdCheck = false;
        DevDao dDao;



        protected void Register_OnClick(object sender, EventArgs e)
        {

            string fname = "";
            if (uploadImg_dev.HasFile) fname = this.GetFilename(uploadImg_dev.FileName);
            else
            {
                return;
            }

            string fileExt = fname.Substring(fname.LastIndexOf(".")).ToLower();
            bool isFig = (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".png" || fileExt == ".bmp" || fileExt == ".jpeg");
            
            if (!isFig)
            {
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "그림 형식의 파일을 선택해 주세요.";
                return;
            }

            dDao = new DevDao();

            DevDo dDo = new DevDo(inputID.Value.ToString(), inputPassword.Value.ToString(), inputNickname.Value.ToString(), fname, txt_explain.Text.ToString(), inputEmail.Value.ToString());
            //파일 경로
            string ufname = Server.MapPath(@"Images\Profile\" + dDo.Name.ToString() + fileExt);
            uploadImg_dev.SaveAs(ufname);

            if (isIdCheck = dDao.VerifyID(inputID.Value.ToString()))
            {
                dDao = new DevDao();
                dDao.RegistDev(dDo);
                Response.Redirect("SuccessRegist.aspx");
            }
            else if (inputID.Value.Length <= 0)
            {
                inputID.Focus();
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "아이디를 입력해주세요.";
                return;
            }
            else if (inputPassword.Value.Length <= 0)
            {
                inputPassword.Focus();
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "비밀번호를 입력해주세요.";
                return;
            }
            else if (inputPassword.Value != inputPasswordDupl.Value)
            {
                inputPassword.Focus();
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "비밀번호가 일치하지 않습니다.";
                return;
            }
            else if (inputEmail.Value.Length <= 0)
            {
                inputEmail.Focus();
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "개발사 이메일을 입력해주세요.";
                return;
            }
            else if (inputNickname.Value.Length <= 0)
            {
                inputNickname.Focus();
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "개발사 이름을 입력해주세요.";
                return;
            }
            else if (txt_explain.Text.Length <= 0)
            {
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "개발사 설명을 입력해주세요.";
                return;
            }
            else if (uploadImg_dev.FileName.Length <=0)
            {
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "개발사 로고를 입력해주세요.";
                return;

            }
            else
            {
                txtRegistCheck.Attributes.Add("style", "visibility: visible");
                txtRegistCheck.InnerText = "이미 사용중인 ID 입니다.";
                inputID.Value = "";
                inputID.Focus();
                return;
            }
        }

        private string GetFilename(string path)
        {
            return path.Substring(path.LastIndexOf(@"\") + 1);
        }
    }
}