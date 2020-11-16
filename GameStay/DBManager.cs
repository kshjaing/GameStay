using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameStay
{
    public class DBManager
    {

        string DBSource = "Data Source=PC\\SQLEXPRESS01; UID=gsdev; PWD=1234; DATABASE=GameStay";

        SqlConnection myConn;

        public DBManager()
        {
            DBOpen();
        }

        //DB연결 메서드
        public void DBOpen()
        {
            myConn = new SqlConnection(DBSource);
            myConn.Open();
        }

        //DB닫기 메서드
        public void DBClose()
        {
            myConn.Close();
        }

        //반환값 없는 쿼리실행 (Insert, Update, Delete)
        public void ExecuteNonQuery(string sQuery)
        {
            SqlCommand sqlCommand = new SqlCommand(sQuery, Open()); //자동Open
            sqlCommand.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(string sQuery)
        {
            SqlCommand sqlCommand = new SqlCommand(sQuery, myConn); //수동Open
            return sqlCommand.ExecuteReader();
        }

        public SqlConnection Open()
        {
            myConn = new SqlConnection(DBSource);
            myConn.Open();
            return myConn;
        }


        //-----------------------------------상점메인페이지관련----------------------------------------

        //특집 및 추천에 들어갈 게임들을 어댑터에 적용(어떤게임을 추천할지 그 로직은 추후 추가)
        public SqlDataAdapter SetFeaturesAdapter()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT 뷰_게임타이틀.게임명, 뷰_게임타이틀.영어게임명, 뷰_게임타이틀.할인가격, 뷰_게임타이틀.할인율, 뷰_게임타이틀.출시일, 뷰_게임타이틀.메인이미지 " +
                "FROM 뷰_게임타이틀 INNER JOIN 추천게임 " +
                "ON 뷰_게임타이틀.게임명 = 추천게임.게임명 ORDER BY 추천게임.번호", myConn);
            return dataAdapter;
        }

        //할인중인 게임들 총 개수 어댑터 적용
        public SqlDataAdapter SetDiscountCountAdapter()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT COUNT(*) AS '총 할인게임 개수' FROM 게임타이틀 WHERE 할인율 > 0;", myConn);
            return dataAdapter;
        }

        //할인중인 게임들 1페이지 어댑터 적용
        public SqlDataAdapter SetDiscountAdapter1()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 게임명)" +
                " AS rownum, *FROM 뷰_게임타이틀 WHERE 할인율 > 0) dis" +
                " WHERE dis.rownum BETWEEN 1 AND 6; ", myConn);
            return dataAdapter;
        }

        //할인중인 게임들 2페이지 어댑터 적용
        public SqlDataAdapter SetDiscountAdapter2()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 게임명)" +
                " AS rownum, *FROM 뷰_게임타이틀 WHERE 할인율 > 0) dis" +
                " WHERE dis.rownum BETWEEN 7 AND 12; ", myConn);
            return dataAdapter;
        }

        //할인중인 게임들 3페이지 어댑터 적용
        public SqlDataAdapter SetDiscountAdapter3()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 게임명)" +
                " AS rownum, *FROM 뷰_게임타이틀 WHERE 할인율 > 0) dis" +
                " WHERE dis.rownum BETWEEN 13 AND 18; ", myConn);
            return dataAdapter;
        }

        //할인중인 게임들 4페이지 어댑터 적용
        public SqlDataAdapter SetDiscountAdapter4()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 게임명)" +
                " AS rownum, *FROM 뷰_게임타이틀 WHERE 할인율 > 0) dis" +
                " WHERE dis.rownum BETWEEN 19 AND 24; ", myConn);
            return dataAdapter;
        }

        public SqlDataAdapter SetDiscountTagAdapter1(string userid)
        {
            String tag1, tag2, tag3;
            String querytag1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=1";
            String querytag2 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=2";
            String querytag3 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=3";
            DBOpen();
            SqlDataReader dataReader1 = this.ExecuteReader(querytag1);
            dataReader1.Read();
            tag1 = dataReader1["태그"].ToString();
            dataReader1.Close();
            SqlDataReader dataReader2 = this.ExecuteReader(querytag2);
            dataReader2.Read();
            tag2 = dataReader2["태그"].ToString();
            dataReader2.Close();
            SqlDataReader dataReader3 = this.ExecuteReader(querytag3);
            dataReader3.Read();
            tag3 = dataReader3["태그"].ToString();
            dataReader3.Close();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) AS rownum, * "
              + "FROM(SELECT TOP(24) * FROM 뷰_게임타이틀 "
              + "WHERE 태그1 = '" + tag1 + "' OR 태그2 = '" + tag1 + "' OR 태그3 = '" + tag1 + "' "
              + "OR 태그1 = '" + tag2 + "' OR 태그2 = '" + tag2 + "' OR 태그3 = '" + tag2 + "' "
              + "OR 태그1 = '" + tag3 + "' OR 태그2 = '" + tag3 + "' OR 태그3 = '" + tag3 + "' "
              + "ORDER BY NEWID())b) a WHERE a.rownum BETWEEN 1 AND 6 AND 할인율 > 0", myConn);
            return dataAdapter;
        }

        public SqlDataAdapter SetDiscountTagAdapter2(string userid)
        {
            String tag1, tag2, tag3;
            String querytag1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=1";
            String querytag2 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=2";
            String querytag3 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=3";
            DBOpen();
            SqlDataReader dataReader1 = this.ExecuteReader(querytag1);
            dataReader1.Read();
            tag1 = dataReader1["태그"].ToString();
            dataReader1.Close();
            SqlDataReader dataReader2 = this.ExecuteReader(querytag2);
            dataReader2.Read();
            tag2 = dataReader2["태그"].ToString();
            dataReader2.Close();
            SqlDataReader dataReader3 = this.ExecuteReader(querytag3);
            dataReader3.Read();
            tag3 = dataReader3["태그"].ToString();
            dataReader3.Close();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) AS rownum, * "
              + "FROM(SELECT TOP(24) * FROM 뷰_게임타이틀 "
              + "WHERE 태그1 = '" + tag1 + "' OR 태그2 = '" + tag1 + "' OR 태그3 = '" + tag1 + "' "
              + "OR 태그1 = '" + tag2 + "' OR 태그2 = '" + tag2 + "' OR 태그3 = '" + tag2 + "' "
              + "OR 태그1 = '" + tag3 + "' OR 태그2 = '" + tag3 + "' OR 태그3 = '" + tag3 + "' "
              + "ORDER BY NEWID())b) a WHERE a.rownum BETWEEN 7 AND 12 AND 할인율 > 0", myConn);
            return dataAdapter;
        }

        public SqlDataAdapter SetDiscountTagAdapter3(string userid)
        {
            String tag1, tag2, tag3;
            String querytag1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=1";
            String querytag2 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=2";
            String querytag3 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=3";
            DBOpen();
            SqlDataReader dataReader1 = this.ExecuteReader(querytag1);
            dataReader1.Read();
            tag1 = dataReader1["태그"].ToString();
            dataReader1.Close();
            SqlDataReader dataReader2 = this.ExecuteReader(querytag2);
            dataReader2.Read();
            tag2 = dataReader2["태그"].ToString();
            dataReader2.Close();
            SqlDataReader dataReader3 = this.ExecuteReader(querytag3);
            dataReader3.Read();
            tag3 = dataReader3["태그"].ToString();
            dataReader3.Close();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) AS rownum, * "
              + "FROM(SELECT TOP(24) * FROM 뷰_게임타이틀 "
              + "WHERE 태그1 = '" + tag1 + "' OR 태그2 = '" + tag1 + "' OR 태그3 = '" + tag1 + "' "
              + "OR 태그1 = '" + tag2 + "' OR 태그2 = '" + tag2 + "' OR 태그3 = '" + tag2 + "' "
              + "OR 태그1 = '" + tag3 + "' OR 태그2 = '" + tag3 + "' OR 태그3 = '" + tag3 + "' "
              + "ORDER BY NEWID())b) a WHERE a.rownum BETWEEN 13 AND 18 AND 할인율 > 0", myConn);
            return dataAdapter;
        }

        public SqlDataAdapter SetDiscountTagAdapter4(string userid)
        {
            String tag1, tag2, tag3;
            String querytag1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=1";
            String querytag2 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=2";
            String querytag3 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 태그포인트 DESC) AS rownum, * "
                + "FROM 태그포인트 WHERE 유저 = '" + userid + "') a WHERE a.rownum=3";
            DBOpen();
            SqlDataReader dataReader1 = this.ExecuteReader(querytag1);
            dataReader1.Read();
            tag1 = dataReader1["태그"].ToString();
            dataReader1.Close();
            SqlDataReader dataReader2 = this.ExecuteReader(querytag2);
            dataReader2.Read();
            tag2 = dataReader2["태그"].ToString();
            dataReader2.Close();
            SqlDataReader dataReader3 = this.ExecuteReader(querytag3);
            dataReader3.Read();
            tag3 = dataReader3["태그"].ToString();
            dataReader3.Close();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) AS rownum, * "
              + "FROM(SELECT TOP(24) * FROM 뷰_게임타이틀 "
              + "WHERE 태그1 = '" + tag1 + "' OR 태그2 = '" + tag1 + "' OR 태그3 = '" + tag1 + "' "
              + "OR 태그1 = '" + tag2 + "' OR 태그2 = '" + tag2 + "' OR 태그3 = '" + tag2 + "' "
              + "OR 태그1 = '" + tag3 + "' OR 태그2 = '" + tag3 + "' OR 태그3 = '" + tag3 + "' "
              + "ORDER BY NEWID())b) a WHERE a.rownum BETWEEN 19 AND 24 AND 할인율 > 0", myConn);
            return dataAdapter;
        }

        //최고인기게임, 신규인기게임 8개씩 어댑터 적용
        public SqlDataAdapter SetBestGamesAdapter()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM(SELECT ROW_NUMBER() OVER(ORDER BY 평점 DESC) " +
                "AS rownum, *FROM 뷰_게임타이틀) AS best WHERE best.rownum BETWEEN 1 AND 8; SELECT * FROM(SELECT ROW_NUMBER() OVER(ORDER BY 출시일 DESC) AS rownum, " +
                "*FROM 뷰_게임타이틀) AS release WHERE release.rownum BETWEEN 1 AND 8", myConn);
            return dataAdapter;
        }

        //신규출시게임 8개 출시일순으로 어댑터 적용
        public SqlDataAdapter SetNewGamesAdapter()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM(SELECT ROW_NUMBER() OVER(ORDER BY 출시일 DESC) AS rownum, " +
                "*FROM 뷰_게임타이틀) AS release WHERE release.rownum BETWEEN 1 AND 8", myConn);
            return dataAdapter;
        }


        //-------------------------------------------------------------------------------------------------


        //--------------------------------------------게임상세페이지 관련-------------------------------------

        //특정게임타이틀 레코드 어댑터
        public SqlDataAdapter SetGameTitleAdapter(string gametitle)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM 뷰_게임타이틀 WHERE 영어게임명='" + gametitle + "'", myConn);
            return dataAdapter;
        }

        //특정게임 소개영상 어댑터
        public SqlDataAdapter SetGameIntroVideoAdapter(string gametitle)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM 게임소개영상 WHERE 영어게임명='" + gametitle + "'", myConn);
            return dataAdapter;
        }

        //특정게임 소개스샷 어댑터
        public SqlDataAdapter SetGameIntroImageAdapter(string gametitle)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM 게임소개스샷 WHERE 영어게임명='" + gametitle + "'", myConn);
            return dataAdapter;
        }

        //특정게임의 스샷과 영상의 총 개수 추출 메서드(사진, 영상 개수에 따른 동적인 div너비 적용)
        public int IntCountImgVid(string gametitle)
        {
            String querystring = "SELECT SUM(cnt) AS 스샷영상개수 FROM ( "
             + "SELECT COUNT(*) AS cnt FROM 게임소개스샷 WHERE 영어게임명 = '" + gametitle + "'"
             + "UNION ALL "
             + "SELECT COUNT(*) AS cnt FROM 게임소개영상 WHERE 영어게임명 = '" + gametitle + "') a";
            int count = 0;
            DBOpen();
            SqlCommand command = new SqlCommand(querystring, myConn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                count = Convert.ToInt32(dataReader["스샷영상개수"]);
            }
            dataReader.Close();
            return count;
        }

        //특정게임의 대표영상링크 추출 메서드
        public string GetMainVideoLink(string gametitle)
        {
            String querystring = "SELECT 대표영상링크 FROM 게임타이틀 WHERE 영어게임명 = '" + gametitle + "'";
            String link = "";
            DBOpen();
            SqlCommand command = new SqlCommand(querystring, myConn);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                link = dataReader["대표영상링크"].ToString();
            }
            dataReader.Close();
            return link;
        }


        //특정게임의 최소요구사양 어댑터
        public SqlDataAdapter SetMinReqAdapter(string gametitle)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM 최소사양 WHERE 영어게임명 = '" + gametitle + "'", myConn);
            return adapter;
        }

        //특정게임의 권장사양 어댑터
        public SqlDataAdapter SetRecReqAdapter(string gametitle)
        {
            SqlDataAdapter adpater = new SqlDataAdapter("SELECT * FROM 권장사양 WHERE 영어게임명 = '" + gametitle + "'", myConn);
            return adpater;
        }


        //--------------------------------------------------------------------------------------------------


        //--------------------------------------------게임상세페이지 리뷰파트-------------------------------------
        



        //특정 게임의 리뷰를 1~8개까지 보여줌
        public SqlDataAdapter SetReviewAdapter(string gametitle)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM(SELECT ROW_NUMBER() OVER(ORDER BY 평점 DESC) AS rownum, *FROM(SELECT * FROM 뷰_유저리뷰 WHERE 영어게임명 = '"+ gametitle +"') AS review1) AS review2 "
             + "WHERE review2.rownum BETWEEN 1 AND 8", myConn);
            return dataAdapter;
        }

        //저장 프로시저 실행
        public int ExecuteStoredProcedure(SqlCommand myCommand, SqlParameter ParamOut)
        {

            myCommand.ExecuteNonQuery();
            int returnValue = (int)ParamOut.Value;
            DBClose();
            return returnValue;
        }
        //----------------------------------------------유저 프로필----------------------------------------------
        //최근 구매게임 
        public SqlDataAdapter SetRecentAdapter1(string uid)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 거래목록.거래일 DESC) AS rownum, 거래목록.구매자, 게임타이틀.게임명, 거래목록.구매금액, 거래목록.거래일, 게임타이틀.메인이미지 FROM 게임타이틀 INNER JOIN 거래목록 ON 게임타이틀.영어게임명 = 거래목록.영어게임명 WHERE 구매자 = '" + uid + "') transc WHERE transc.rownum BETWEEN 1 AND 3;", myConn);
            return dataAdapter;
        }
        

        //유저 정보
        public SqlDataAdapter SetUserInfo(string uid)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM 유저 WHERE 아이디 =  " + "'" + uid + "'", myConn);
            return dataAdapter;
        }

        //유저의 닉네임
        public String GetNickName(string userid)
        {
            String querystring = "SELECT 닉네임 FROM 유저 WHERE 아이디 = '" + userid + "'";
            String nickname = "";
            DBOpen();
            SqlDataReader dataReader = this.ExecuteReader(querystring);
            while (dataReader.Read())
            {
                nickname = dataReader["닉네임"].ToString();
            }
            dataReader.Close();
            return nickname;
        }

        //유저의 프로필사진
        public String GetProfileImage(string userid)
        {
            String querystring = "SELECT 프로필사진 FROM 유저 WHERE 아이디 = '" + userid + "'";
            String profileimage = "";
            DBOpen();
            SqlDataReader dataReader = this.ExecuteReader(querystring);
            while (dataReader.Read())
            {
                profileimage = dataReader["프로필사진"].ToString();
            }
            dataReader.Close();
            return profileimage;
        }

        //유저가 게임을 보유하고 있는지 체크(true=보유, false=미보유)
        public bool CheckHasGame(string userid, string gametitle)
        {
            bool isHave = false;
            String querystring = "SELECT * FROM 거래목록 WHERE 구매자='" + userid + "' AND 영어게임명='" + gametitle + "'";
            DBOpen();
            SqlDataReader dataReader = this.ExecuteReader(querystring);
            if (dataReader.Read())
                isHave = true;
            else
                isHave = false;
            dataReader.Close();
            return isHave;
        }

        //유저가 소유한 게임 수
        public int GetHasGameCount(string userid)
        {
            String querystring = "SELECT COUNT(*) AS '소유한 게임 수' FROM 거래목록 WHERE 구매자='" + userid + "'";
            int count = 0;
            DBOpen();
            SqlDataReader dataReader = this.ExecuteReader(querystring);
            while (dataReader.Read())
            {
                count = Convert.ToInt32(dataReader["소유한 게임 수"]);
            }
            dataReader.Close();
            return count;
        }

        //유저가 작성한 리뷰 수
        public int GetReviewCount(string userid)
        {
            String querystring = "SELECT COUNT(*) AS '작성한 리뷰 수' FROM 리뷰 WHERE 작성자 ='" + userid + "'";
            int count = 0;
            DBOpen();
            SqlDataReader dataReader = this.ExecuteReader(querystring);
            while (dataReader.Read())
            {
                count = Convert.ToInt32(dataReader["작성한 리뷰 수"]);
            }
            dataReader.Close();
            return count;
        }

        //특정 게임의 리뷰 수
        public int SetGameReview(string gametitle)
        {
            String querystring = "SELECT  COUNT(rownum) AS '게임의 총 리뷰 수' " 
               + "FROM(SELECT ROW_NUMBER() OVER(ORDER BY 평점 DESC) AS rownum, * " 
               + "FROM(SELECT * FROM 리뷰 WHERE 영어게임명 = '"+ gametitle +"') AS review1) AS review ";
            int count = 0;
            DBOpen();
            SqlDataReader dataReader = this.ExecuteReader(querystring);
            while (dataReader.Read())
            {
                count = Convert.ToInt32(dataReader["게임의 총 리뷰 수"]);
            }
            dataReader.Close();
            return count;
        }

        //로그인한 유저의 특정게임 평점
        public int GetRating(string userid, string gametitle)
        {
            String querystring = "SELECT 평점 FROM 리뷰 WHERE 작성자='" + userid + "' AND 영어게임명='" + gametitle + "'";
            int count = 0;
            DBOpen();
            SqlDataReader dataReader = this.ExecuteReader(querystring);
            while (dataReader.Read())
            {
                count = Convert.ToInt32(dataReader["평점"]);
            }
            dataReader.Close();
            return count;
        }

        //특정게임에서 이미 쓴 자신의 리뷰를 가져옴
        public String GetMyReview(string userid, string gametitle)
        {
            String querystring = "SELECT 내용 FROM 리뷰 WHERE 작성자='" + userid +"' AND 영어게임명='" + gametitle + "'";
            String myReview = "";
            DBOpen();
            SqlDataReader dataReader = this.ExecuteReader(querystring);
            while (dataReader.Read())
            {
                myReview = dataReader["내용"].ToString().Replace("<br>", "");
            }
            dataReader.Close();
            return myReview;
        }

        //특정게임의 한글게임명 반환
        public String GetGameKorTitle(string gametitle)
        {
            String querystring = "SELECT 게임명 FROM 게임타이틀 WHERE 영어게임명='" + gametitle + "'";
            String korTitle = "";
            DBOpen();
            SqlDataReader dataReader = this.ExecuteReader(querystring);
            dataReader.Read();
            korTitle = dataReader["게임명"].ToString();
            dataReader.Close();
            return korTitle;
        }

        //리뷰 게시
        public void PostReview(string userid, string gametitle, string contents, int rating)
        {
            String querystring1 = "SELECT COUNT(*) AS 확인 FROM 리뷰 WHERE 작성자='" + userid + "' AND 영어게임명='" + gametitle + "'";
            String querystring2 = "";

            String tag1, tag2, tag3;
            String queryadd1 = "", queryadd2 = "", queryadd3 = "";
            String querytag1 = "SELECT 태그1 FROM 게임별태그 WHERE 영어게임명='" + gametitle + "'";
            String querytag2 = "SELECT 태그2 FROM 게임별태그 WHERE 영어게임명='" + gametitle + "'";
            String querytag3 = "SELECT 태그3 FROM 게임별태그 WHERE 영어게임명='" + gametitle + "'";
            String querypoint = "";

            //평점을 20으로 나눈 몫으로 별 개수 선정
            int star = 1;
            if (rating / 20 == 5)
                star = 5;
            else
                star = rating / 20 + 1;

            DBOpen();
            SqlDataReader dataReader1 = this.ExecuteReader(querytag1);
            dataReader1.Read();
            tag1 = dataReader1["태그1"].ToString();
            dataReader1.Close();

            SqlDataReader dataReader2 = this.ExecuteReader(querytag2);
            dataReader2.Read();
            tag2 = dataReader2["태그2"].ToString();
            dataReader2.Close();

            SqlDataReader dataReader3 = this.ExecuteReader(querytag3);
            dataReader3.Read();
            tag3 = dataReader3["태그3"].ToString();
            dataReader3.Close();

            SqlDataReader dataReader = this.ExecuteReader(querystring1);
            dataReader.Read();
            //dataReader가 1이면 이미 이 게임에 이 유저가 작성한 리뷰가 있는것
            if (Convert.ToInt32(dataReader["확인"]) == 1)
            {
                querystring2 = "UPDATE 리뷰 SET 내용='" + contents + "', "
                    + "평점=" + rating + ", 평점이미지='Images/Icon/Star/Star_" + star + ".png' "
                    + "WHERE 작성자='" + userid + "' AND 영어게임명='" + gametitle + "'";
            }
            //0이면 리뷰가 없으니 새로 삽입
            else if (Convert.ToInt32(dataReader["확인"]) == 0)
            {
                querystring2 = "INSERT INTO 리뷰(작성자, 영어게임명, 내용, 평점, 평점이미지, 좋아요, 작성일) "
                  + "VALUES('" + userid + "', '" + gametitle + "', '" + contents + "', '" + rating + "', "
                  + "'Images/Icon/Star/Star_" + star + ".png', 0, '" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                queryadd1 = "UPDATE 태그포인트 SET 태그포인트= 태그포인트 + 3 WHERE 태그='" + tag1 + "' AND 유저='" + userid + "'";
                queryadd2 = "UPDATE 태그포인트 SET 태그포인트= 태그포인트 + 3 WHERE 태그='" + tag2 + "' AND 유저='" + userid + "'";
                queryadd3 = "UPDATE 태그포인트 SET 태그포인트= 태그포인트 + 3 WHERE 태그='" + tag3 + "' AND 유저='" + userid + "'";
                querypoint = "UPDATE 유저 SET 활동포인트= 활동포인트 + 50 WHERE 아이디='" + userid + "'";
            }
            dataReader.Close();
            this.ExecuteNonQuery(querystring2);
            
            if (queryadd1 != "" && queryadd2 != "" && queryadd3 != "")
            {
                this.ExecuteNonQuery(queryadd1);
                this.ExecuteNonQuery(queryadd2);
                this.ExecuteNonQuery(queryadd3);
            }

            if (querypoint != "")
            {
                this.ExecuteNonQuery(querypoint);
            }
        }

        //게임의 할인된 가격 반환
        public int GetDiscountedPrice(string gametitle)
        {
            String querystring = "SELECT 할인가격 FROM 뷰_게임타이틀 WHERE 영어게임명='" + gametitle + "'";
            int price;
            DBOpen();
            SqlDataReader dataReader = this.ExecuteReader(querystring);
            dataReader.Read();
            price = Convert.ToInt32(dataReader["할인가격"]);
            dataReader.Close();
            return price;
        }

        public string GetKorGameTitle(string gametitle)
        {
            String querystring = "SELECT 게임명 FROM 게임타이틀 WHERE 영어게임명='" + gametitle + "'";
            string title;
            DBOpen();
            SqlDataReader dataReader = this.ExecuteReader(querystring);
            dataReader.Read();
            title = dataReader["게임명"].ToString();
            dataReader.Close();
            return title;
        }

        //게임 구매
        public void PurchaseGame(string userid, string korgametitle, string gametitle, int price)
        {
            String querystring = "INSERT INTO 거래목록(구매자, 게임명, 영어게임명, 구매금액, 거래일) "
                + "VALUES('" + userid + "', '" + korgametitle + "', '" + gametitle + "', '" + price + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
            
            //구매하려는 게임의 태그 3개를 모두 가져옴
            String tag1, tag2, tag3;
            String queryadd1, queryadd2, queryadd3;
            String querytag1 = "SELECT 태그1 FROM 게임별태그 WHERE 영어게임명='" + gametitle + "'";
            String querytag2 = "SELECT 태그2 FROM 게임별태그 WHERE 영어게임명='" + gametitle + "'";
            String querytag3 = "SELECT 태그3 FROM 게임별태그 WHERE 영어게임명='" + gametitle + "'";
            DBOpen();
            SqlDataReader dataReader1 = this.ExecuteReader(querytag1);
            dataReader1.Read();
            tag1 = dataReader1["태그1"].ToString();
            dataReader1.Close();

            SqlDataReader dataReader2 = this.ExecuteReader(querytag2);
            dataReader2.Read();
            tag2 = dataReader2["태그2"].ToString();
            dataReader2.Close();

            SqlDataReader dataReader3 = this.ExecuteReader(querytag3);
            dataReader3.Read();
            tag3 = dataReader3["태그3"].ToString();
            dataReader3.Close();
            //----------------------------------------
            //해당태그의 태그포인트 증가

            String querycheck1 = "SELECT * FROM 태그포인트 WHERE 유저='" + userid + "' AND 태그='" + tag1 + "'";
            String querycheck2 = "SELECT * FROM 태그포인트 WHERE 유저='" + userid + "' AND 태그='" + tag2 + "'";
            String querycheck3 = "SELECT * FROM 태그포인트 WHERE 유저='" + userid + "' AND 태그='" + tag3 + "'";
            
            SqlDataReader dataReaderCheck1 = this.ExecuteReader(querycheck1);
            //태그포인트 테이블에 해당 태그가 존재할때
            if (dataReaderCheck1.Read())
            {
                queryadd1 = "UPDATE 태그포인트 SET 태그포인트= 태그포인트 + 5 WHERE 태그='" + tag1 + "' AND 유저='" + userid + "'";
            }
            //태그포인트 테이블에 해당 태그가 없을때
            else
            {
                queryadd1 = "INSERT INTO 태그포인트(유저, 태그, 태그포인트) VALUES('" + userid + "', '" + tag1 + "', 5)";
            }
            dataReaderCheck1.Close();



            SqlDataReader dataReaderCheck2 = this.ExecuteReader(querycheck2);
            if (dataReaderCheck2.Read())
            {
                queryadd2 = "UPDATE 태그포인트 SET 태그포인트= 태그포인트 + 5 WHERE 태그='" + tag2 + "' AND 유저='" + userid + "'";
            }
            else
            {
                queryadd2 = "INSERT INTO 태그포인트(유저, 태그, 태그포인트) VALUES('" + userid + "', '" + tag2 + "', 5)";
            }
            dataReaderCheck2.Close();



            SqlDataReader dataReaderCheck3 = this.ExecuteReader(querycheck3);
            if (dataReaderCheck3.Read())
            {
                queryadd3 = "UPDATE 태그포인트 SET 태그포인트= 태그포인트 + 5 WHERE 태그='" + tag3 + "' AND 유저='" + userid + "'";
            }
            else
            {
                queryadd3 = "INSERT INTO 태그포인트(유저, 태그, 태그포인트) VALUES('" + userid + "', '" + tag3 + "', 5)";
            }
            dataReaderCheck3.Close();

            //포인트 추가
            String querypoint = "UPDATE 유저 SET 활동포인트= 활동포인트 + FLOOR(" + price +" * 0.01) WHERE 아이디='" + userid + "'";
            this.ExecuteNonQuery(querystring);
            this.ExecuteNonQuery(queryadd1);
            this.ExecuteNonQuery(queryadd2);
            this.ExecuteNonQuery(queryadd3);
            this.ExecuteNonQuery(querypoint);
        }

        //개발사 정보
        public SqlDataAdapter SetDevInfo(string uid)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM 개발사 WHERE 아이디 =  " + "'" + uid + "'", myConn);
            return dataAdapter;
        }

        //개발사 최근발매 게임
        public SqlDataAdapter SetDevNewGame1(string uid)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM(SELECT ROW_NUMBER() OVER(ORDER BY 출시일 DESC)AS rownum, * FROM Dev_title_view WHERE 아이디 = " + "'" + uid + "') transc WHERE transc.rownum BETWEEN 1 AND 4", myConn);
            return dataAdapter;
        }
        
        //개발사 게임 리스트
        public SqlDataAdapter SetDevGameList(string uid)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Dev_title_view WHERE 아이디 = " + "'" + uid + "' ORDER BY 출시일 DESC", myConn);
            return dataAdapter;
        }

        //개발사 매출
        public SqlDataAdapter SetDevIncome(string uid)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT SUM(구매금액) AS 매출액 FROM Transaction_detail_view WHERE 아이디  = '" + uid + "'", myConn);
            return dataAdapter;
        }

        //------------------유저 라이브러리 -----------------//
        public SqlDataAdapter SetLibrary(string uid)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM 뷰_유저라이브러리 WHERE 아이디 ='" + uid + "' ORDER BY 게임명 ASC", myConn);
            return dataAdapter;
        }
        
    }
}