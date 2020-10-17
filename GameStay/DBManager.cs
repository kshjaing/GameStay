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
        
        string DBSource = "Data Source=(local); UID=gsdev; PWD=1234; DATABASE=GameStay";

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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT 게임타이틀.게임명, 게임타이틀.영어게임명, 게임타이틀.게임가격, 게임타이틀.할인율, 게임타이틀.출시일, 게임타이틀.메인이미지 " +
                "FROM 게임타이틀 INNER JOIN 추천게임 " +
                "ON 게임타이틀.게임명 = 추천게임.게임명 ORDER BY 추천게임.번호", myConn);
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
                " AS rownum, *FROM 게임타이틀 WHERE 할인율 > 0) dis" +
                " WHERE dis.rownum BETWEEN 1 AND 6; ", myConn);
            return dataAdapter;
        }

        //할인중인 게임들 2페이지 어댑터 적용
        public SqlDataAdapter SetDiscountAdapter2()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 게임명)" +
                " AS rownum, *FROM 게임타이틀 WHERE 할인율 > 0) dis" +
                " WHERE dis.rownum BETWEEN 7 AND 12; ", myConn);
            return dataAdapter;
        }

        //할인중인 게임들 3페이지 어댑터 적용
        public SqlDataAdapter SetDiscountAdapter3()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 게임명)" +
                " AS rownum, *FROM 게임타이틀 WHERE 할인율 > 0) dis" +
                " WHERE dis.rownum BETWEEN 13 AND 18; ", myConn);
            return dataAdapter;
        }

        //할인중인 게임들 4페이지 어댑터 적용
        public SqlDataAdapter SetDiscountAdapter4()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 게임명)" +
                " AS rownum, *FROM 게임타이틀 WHERE 할인율 > 0) dis" +
                " WHERE dis.rownum BETWEEN 19 AND 24; ", myConn);
            return dataAdapter;
        }

        //최고인기게임 8개 평점순으로 어댑터 적용
        public SqlDataAdapter SetBestGamesAdapter()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM(SELECT ROW_NUMBER() OVER(ORDER BY 평점 DESC) " +
                "AS rownum, *FROM 게임타이틀) AS best WHERE best.rownum BETWEEN 1 AND 8; SELECT * FROM(SELECT ROW_NUMBER() OVER(ORDER BY 출시일 DESC) AS rownum, " +
                "*FROM 게임타이틀) AS release WHERE release.rownum BETWEEN 1 AND 8", myConn);
            return dataAdapter;
        }

        //신규출시게임 8개 출시일순으로 어댑터 적용
        public SqlDataAdapter SetNewGamesAdapter()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM(SELECT ROW_NUMBER() OVER(ORDER BY 출시일 DESC) AS rownum, " +
                "*FROM 게임타이틀) AS release WHERE release.rownum BETWEEN 1 AND 8", myConn);
            return dataAdapter;
        }


        //-------------------------------------------------------------------------------------------------


        //--------------------------------------------게임상세페이지 관련-------------------------------------

        //특정게임타이틀 레코드 어댑터
        public SqlDataAdapter SetGameTitleAdapter(string gametitle)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM 게임타이틀 WHERE 영어게임명='" + gametitle + "'", myConn);
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
            SqlCommand command = new SqlCommand(querystring, myConn);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                count = Convert.ToInt32(dataReader["스샷영상개수"]);
            }
            return count;
        }



        //--------------------------------------------------------------------------------------------------

        //저장 프로시저 실행
        public int ExecuteStoredProcedure(SqlCommand myCommand, SqlParameter ParamOut)
        {

            myCommand.ExecuteNonQuery();
            int returnValue = (int)ParamOut.Value;
            DBClose();
            return returnValue;
        }

        //최근 구매게임 1
        public SqlDataAdapter SetRecentAdapter1(string uid)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 거래목록.거래일 DESC) AS rownum, 거래목록.구매자, 게임타이틀.게임명, 거래목록.구매금액, 거래목록.거래일, 게임타이틀.메인이미지 FROM 게임타이틀 INNER JOIN 거래목록 ON 게임타이틀.게임명 = 거래목록.게임명 WHERE 구매자 = '" + uid + "') transc WHERE transc.rownum BETWEEN 1 AND 1;", myConn);
            return dataAdapter;
        }
        //최근 구매게임 2
        public SqlDataAdapter SetRecentAdapter2(string uid)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 거래목록.거래일 DESC) AS rownum, 거래목록.구매자, 게임타이틀.게임명, 거래목록.구매금액, 거래목록.거래일, 게임타이틀.메인이미지 FROM 게임타이틀 INNER JOIN 거래목록 ON 게임타이틀.게임명 = 거래목록.게임명 WHERE 구매자 = '" + uid + "') transc WHERE transc.rownum BETWEEN 2 AND 2;", myConn);
            return dataAdapter;
        }
        //최근 구매게임 3
        public SqlDataAdapter SetRecentAdapter3(string uid)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY 거래목록.거래일 DESC) AS rownum, 거래목록.구매자, 게임타이틀.게임명, 거래목록.구매금액, 거래목록.거래일, 게임타이틀.메인이미지 FROM 게임타이틀 INNER JOIN 거래목록 ON 게임타이틀.게임명 = 거래목록.게임명 WHERE 구매자 = '" + uid + "') transc WHERE transc.rownum BETWEEN 3 AND 3;", myConn);
            return dataAdapter;
        }
    }
}