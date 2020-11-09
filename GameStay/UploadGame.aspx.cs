using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GameStay
{

    public partial class UploadGame : System.Web.UI.Page
    {
        DBManager dbManager;
        GameTitleDao gtdao;
        int no;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["아이디"] == null)
                {
                    Response.Redirect("RequestLogin.aspx?before=DevProfile");
                }
                else
                {
                    (this.Master.FindControl("button_login") as HtmlButton).InnerText = "로그아웃";

                }
            }
        }

        protected void uploadGame_click(object sender, EventArgs e)
        {
            

            if(inputDiscount.Value.Length < 1 )//기본정보
            {
                inputDiscount.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "할인율을 입력해주세요.";
                return;
            }
            else if (inputTitleKor.Value.Length < 1)
            {
                inputTitleKor.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "한글제목을 입력해주세요.";
                return;
            }
            else if (inputTitleEng.Value.Length < 1)
            {
                inputTitleEng.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "영문제목을 입력해주세요.";
                return;
            }
            else if (inputPrice.Value.Length < 1)
            {
                inputPrice.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "가격을 입력해주세요.";
                return;
            }
            else if (inputDate.Value.Length < 1)
            {
                inputDate.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "발매일을 입력해주세요.";
                return;
            }
            else if (txt_explain.Text.Length < 1)
            {
                txt_explain.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "게임설명을 입력해주세요.";
                return;
            }
            else if (FileUpload1.ClientID.Length < 1)//스샷부분
            {
                FileUpload1.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "대표이미지를 등록해주세요.";
                return;
            }
            else if (FileUpload2.ClientID.Length < 1)
            {
                FileUpload2.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "와이드이미지를 등록해주세요.";
                return;
            }
            else if (FileUploads1.ClientID.Length < 1)
            {
                FileUploads1.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "스크린샷을 등록해주세요.";
                return;
            }
            else if (FileUploads2.ClientID.Length < 1)
            {
                FileUploads2.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "스크린샷을 등록해주세요.";
                return;
            }
            else if (FileUploads3.ClientID.Length < 1)
            {
                FileUploads3.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "스크린샷을 등록해주세요.";
                return;
            }
            else if (FileUploads4.ClientID.Length < 1)
            {
                FileUploads4.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "스크린샷을 등록해주세요.";
                return;
            }
            else if (FileUploads5.ClientID.Length < 1)
            {
                FileUploads5.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "스크린샷을 등록해주세요.";
                return;
            }
            else if (FileUpload8.ClientID.Length < 1)
            {
                FileUpload8.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "4:3 이미지를 등록해주세요.";
                return;
            }
            else if(min_os.Value.Length < 1)//최소사양
            {
                min_os.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "최소사양 (OS)를 입력해주세요.";
                return;
            }
            else if (min_CPU.Value.Length < 1)
            {
                min_CPU.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "최소사양 (CPU)를 입력해주세요.";
                return;
            }
            else if (min_hdd.Value.Length < 1)
            {
                min_hdd.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "최소사양 (저장공간)를 입력해주세요.";
                return;
            }
            else if (min_MEM.Value.Length < 1)
            {
                min_MEM.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "최소사양 (메모리)를 입력해주세요.";
                return;
            }
            else if (min_VGA.Value.Length < 1)
            {
                min_VGA.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "최소사양 (그래픽)를 입력해주세요.";
                return;
            }
            else if (rec_CPU.Value.Length < 1)//권장사양
            {
                rec_CPU.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "권장사양 (CPU)를 입력해주세요.";
                return;
            }
            else if (rec_hdd.Value.Length < 1)
            {
                rec_hdd.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "권장사양 (저장공간)를 입력해주세요.";
                return;
            }
            else if (rec_MEM.Value.Length < 1)
            {
                rec_MEM.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "권장사양 (메모리)를 입력해주세요.";
                return;
            }
            else if (rec_OS.Value.Length < 1)
            {
                rec_OS.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "권장사양 (OS)를 입력해주세요.";
                return;
            }
            else if (rec_VGA.Value.Length < 1)
            {
                rec_VGA.Focus();
                txtCheck.Attributes.Add("style", "visibility: visible");
                txtCheck.InnerText = "권장사양 (그래필)를 입력해주세요.";
                return;
            }
            else
            {
                gtdao = new GameTitleDao();

                //타이틀, 4대3, 와이드 이미지 저장할 이름 지정 경로+영문명

                string mainimg = "Images/GameTitleImages/TitleImage_" + inputTitleEng.Value.ToString() + ".jpg";
                string subimg = "Images/Game4vs3Images/4vs3_" + inputTitleEng.Value.ToString() + ".jpg";
                string wideimg = "Images/GameWideImages/WideImage_" + inputTitleEng.Value.ToString() + ".jpg";
                string title = inputTitleEng.Value.ToString();

                string i = inputPrice.Value.ToString(); //가격 변환
                int price = int.Parse(i);
                string x = inputDiscount.Value.ToString(); //할인율 변환
                float discount = float.Parse(x);


                //개발사 이름 가져오기

                string uid = Session["아이디"].ToString();
                string dev = gtdao.GetDev(uid);

                //프로시저이용

                GameTitleDo gtDo = new GameTitleDo(inputTitleKor.Value.ToString(), title, price, discount,
                    txt_explain.Text.ToString(), inputDate.Value.ToString(), dev, mainimg, wideimg, subimg, inputVideoLink.Value.ToString());

                //타이틀이미지 저장
                string uFnameT = "TitleImage_" + inputTitleEng.Value.ToString();
                FileUpload1.SaveAs(Server.MapPath(@"Images/GameTitleImages/" + uFnameT + ".jpg"));

                //4대3 이미지 저장
                string uFnameS = "4vs3_" + inputTitleEng.Value.ToString();
                FileUpload8.SaveAs(Server.MapPath(@"Images/Game4vs3Images/" + uFnameS + ".jpg"));

                //와이드 이미지 저장
                string uFnameW = "WideImage_" + inputTitleEng.Value.ToString();
                FileUpload2.SaveAs(Server.MapPath(@"Images/GameWideImages/" + uFnameW + ".jpg"));

                no = (new GameTitleDao()).uploadGame(gtDo);

                //스샷 이미지//

                string fname1 = "Images/GameIntroImages/IntroImage_" + inputTitleEng.Value.ToString() + "1.jpg";
                gtdao.uploadimg(fname1, title);
                FileUploads1.SaveAs(Server.MapPath(@"Images/GameIntroImages/" + title + "1.jpg"));

                string fname2 = "Images/GameIntroImages/IntroImage_" + inputTitleEng.Value.ToString() + "2.jpg";
                gtdao.uploadimg(fname2, title);
                FileUploads2.SaveAs(Server.MapPath(@"Images/GameIntroImages/" + title + "2.jpg"));

                string fname3 = "Images/GameIntroImages/IntroImage_" + inputTitleEng.Value.ToString() + "3.jpg";
                gtdao.uploadimg(fname3, title);
                FileUploads3.SaveAs(Server.MapPath(@"Images/GameIntroImages/" + title + "3.jpg"));

                string fname4 = "Images/GameIntroImages/IntroImage_" + inputTitleEng.Value.ToString() + "4.jpg";
                gtdao.uploadimg(fname4, title);
                FileUploads4.SaveAs(Server.MapPath(@"Images/GameIntroImages/" + title + "4.jpg"));

                string fname5 = "Images/GameIntroImages/IntroImage_" + inputTitleEng.Value.ToString() + "5.jpg";
                gtdao.uploadimg(fname5, title);
                FileUploads5.SaveAs(Server.MapPath(@"Images/GameIntroImages/" + title + "5.jpg"));

                //요구사항 저장

                string rOS = rec_OS.Value.ToString();
                string rCPU = rec_CPU.Value.ToString();
                string rMEM = rec_MEM.Value.ToString();
                string rVGA = rec_VGA.Value.ToString();
                string rhdd = rec_hdd.Value.ToString();

                gtdao.SystemRecommend(title, rOS, rCPU, rMEM, rVGA, rhdd);

                //최소사양

                string mOS = min_os.Value.ToString();
                string mCPU = min_CPU.Value.ToString();
                string mMEM = min_MEM.Value.ToString();
                string mVGA = min_VGA.Value.ToString();
                string mhdd = min_hdd.Value.ToString();

                gtdao.SystemMinimum(title, mOS, mCPU, mMEM, mVGA, mhdd);

            }


            Response.Redirect("Store_Main.aspx");
        }
    }
}