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
        
        static string DBSource = "Data Source=(local); UID=gsdev; PWD=1234; DATABASE=GameStay";

        static SqlConnection myConn;

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
        public static void DBClose()
        {
            myConn.Close();
        }

        //반환값 없는 쿼리실행 (Insert, Update, Delete)
        public static void ExecuteNonQuery(string sQuery)
        {
            SqlCommand sqlCommand = new SqlCommand(sQuery, myConn);
            sqlCommand.ExecuteNonQuery();
        }


        public static SqlDataReader ExecuteReader(string sQuery)
        {
            SqlCommand sqlCommand = new SqlCommand(sQuery, myConn);
            return sqlCommand.ExecuteReader();
        }



        //특집 및 추천에 들어갈 게임들을 어댑터에 적용(어떤게임을 추천할지 그 로직은 추후 추가)
        public SqlDataAdapter SetFeaturesAdapter()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT 게임타이틀.게임명, 게임타이틀.게임가격, 게임타이틀.할인율, 게임타이틀.출시일, 게임타이틀.메인이미지 " +
                "FROM 게임타이틀 INNER JOIN 추천게임 " +
                "ON 게임타이틀.게임명 = 추천게임.게임명 ORDER BY 추천게임.번호", myConn);
            return dataAdapter;
        }

        //할인중인 게임들 어댑터 적용
        public SqlDataAdapter SetDiscountAdapter()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("", myConn);
            return dataAdapter;
        }

        

        //======================로그인, 회원가입=========================

        //로그인
        /*
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