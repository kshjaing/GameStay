using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using GameStay;

namespace GameStay
{
    public class UserDao
    {
        DBManager dbManager;
        public UserDao()
        {

        }

        //로그인 판별

        public bool Authenticate(string id, string pw)
        {
            dbManager = new DBManager();

            //리턴값 및 아웃 참조변수 초기화
            bool isAuthen = false; //리턴값 false - 미인증상태
                                   //뭐리문 이용하여 조건(id, pwd) 에 일치하는 자료를 불러옴. 비밀번호는 MD5로 암호화
                                   //string test = this.GetMd5(pwd);
            string sQuery = "SELECT * FROM 유저 WHERE 아이디='" + id + "' AND 비밀번호='" + this.GetMD5(pw) + "'";

            //dbman.executeReader() 메서드를 호출하여 결과를 가져옴
            SqlDataReader mReader = dbManager.ExecuteReader(sQuery);

            //결과값이 존재하면 인증성공, 없으면 인증실패
            if (mReader.Read()) isAuthen = true;

            //sqldatareader 객체를 닫음
            mReader.Close();
            //DB연결해제
            dbManager.DBClose();
            //결과값 반환
            return isAuthen;
        }

        public bool DEVAuthenticate(string id, string pw)
        {
            dbManager = new DBManager();

            //리턴값 및 아웃 참조변수 초기화
            bool isAuthen = false; //리턴값 false - 미인증상태
                                   //뭐리문 이용하여 조건(id, pwd) 에 일치하는 자료를 불러옴. 비밀번호는 MD5로 암호화
                                   //string test = this.GetMd5(pwd);
            string sQuery = "SELECT * FROM 개발사 WHERE 아이디='" + id + "' AND 비밀번호='" + pw + "'";

            //dbman.executeReader() 메서드를 호출하여 결과를 가져옴
            SqlDataReader mReader = dbManager.ExecuteReader(sQuery);

            //결과값이 존재하면 인증성공, 없으면 인증실패
            if (mReader.Read()) isAuthen = true;

            //sqldatareader 객체를 닫음
            mReader.Close();
            //DB연결해제
            dbManager.DBClose();
            //결과값 반환
            return isAuthen;
        }

        //md5 알고리즘
        //구글링을 통하여 구한 코드
        private String GetMD5(String input)
        {
            //use input string to calculate md5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    //10진수를 두자리의 16진수로 변환
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


        //ID 중복검사
        public bool VerifyID(string id)
        {
            dbManager = new DBManager();

            bool result = true;
            string sQuery = "SELECT * FROM 유저 WHERE 아이디 = '" + id + "'";
            SqlDataReader myReader = dbManager.ExecuteReader(sQuery);
            if (myReader.Read()) result = false;
            myReader.Close();
            dbManager.DBClose();
            return result;
        }

        //유저 프로필 정보 
        public UserDo Getprofileimg(string uid)
        {
            dbManager = new DBManager();

            string qrySelect = "SELECT 프로필사진 FROM 유저 WHERE 아이디 =  " + "'" + uid + "'";

            SqlDataReader mReader = dbManager.ExecuteReader(qrySelect);

            mReader.Read();

            UserDo udo = new UserDo
            (
                mReader["프로필사진"].ToString().TrimEnd()
            );

            mReader.Close();
            dbManager.DBClose();
            return udo;
        }

        //쿼리 이용한 회원가입
        public void RegisterUserQry(UserDo uDo)
        {

            dbManager = new DBManager();
            string sQuery = "INSERT INTO 유저 (아이디, 비밀번호, 닉네임, 이메일, 프로필사진, 레벨, 등급) VALUES ('" + uDo.Userid + "', '" + this.GetMD5(uDo.Passwd) + "', '" + uDo.Nickname + "', '" + uDo.Email + "', null , 1, 1)";
            dbManager.ExecuteNonQuery(sQuery);
            dbManager.DBClose();
        }

        //저장 프로시저 이용한 회원가입
        public int RegistUser(UserDo uDo)
        {
            dbManager = new DBManager();

            //모든메소드 dbManager = new DBManager(); 
            //프로시저사용시 SqlCommand mCmd = new SqlCommand("procAddUser",dbManager.Open());
            //메소드 처음에 해주기

            SqlCommand mCmd = new SqlCommand("procAddUser", dbManager.Open());

            mCmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param;
            param = new SqlParameter("@아이디", SqlDbType.Char, 12);
            param.Value = uDo.Userid;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@비밀번호", SqlDbType.Char, 32);
            param.Value = this.GetMD5(uDo.Passwd);
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@닉네임", SqlDbType.NVarChar, 25);
            param.Value = uDo.Nickname;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@이메일", SqlDbType.VarChar, 30);
            param.Value = uDo.Email;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@프로필사진", SqlDbType.NChar, 50);
            //param.Value = uDo.Profileimg;
            param.Value = DBNull.Value;
            mCmd.Parameters.Add(param);

            SqlParameter paramOut = new SqlParameter("@result", SqlDbType.Int);
            paramOut.Direction = ParameterDirection.Output;
            mCmd.Parameters.Add(paramOut);
            return dbManager.ExecuteStoredProcedure(mCmd, paramOut);
        }
    }
}