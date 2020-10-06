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

        

        //특집 및 추천에 들어갈 게임들을 어댑터에 적용(어떤게임을 추천할지 그 로직은 추후 추가)
        public SqlDataAdapter SetFeaturesAdapter()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT 게임타이틀.게임명, 게임타이틀.게임가격, 게임타이틀.할인율, 게임타이틀.출시일, 게임타이틀.메인이미지 " +
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

        //저장 프로시저 실행
        public int ExecuteStoredProcedure(SqlCommand myCommand, SqlParameter ParamOut)
        {

            

            myCommand.ExecuteNonQuery();
            int returnValue = (int)ParamOut.Value;
            DBClose();
            return returnValue;
        }

        public DataSet DataAdapterFill(string strSql, string mytable)
        {
            DataSet myDs = new DataSet(mytable);
            SqlDataAdapter myAdapter = new SqlDataAdapter(strSql, Open());
            myAdapter.Fill(myDs, mytable);
            myAdapter.Dispose();
            DBClose();
            return myDs;
        }

        //======================로그인, 회원가입=========================
        /*
        //로그인
        public bool Authenticate(string id, string pwd)
        {
            bool isAuthen = false;
            string sQuery = "SELECT 비밀번호 FROM 유저 WHERE 아이디 = '" + id + "'";
            SqlDataReader myReader = this.ExecuteReader(sQuery);

            if (myReader.Read())
            {
                if (pwd == myReader["비밀번호"].ToString().TrimEnd())
                    isAuthen = true;
            }

            myReader.Close();
            return isAuthen;
        }*/
    }
}