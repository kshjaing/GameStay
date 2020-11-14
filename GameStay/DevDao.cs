using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GameStay
{
    
    public class DevDao
    {
        DBManager dbManager;

        public bool DEVAuthenticate(string id, string pw)
        {
            dbManager = new DBManager();

            //리턴값 및 아웃 참조변수 초기화
            bool isAuthen = false; //리턴값 false - 미인증상태
                                   //뭐리문 이용하여 조건(id, pwd) 에 일치하는 자료를 불러옴. 비밀번호는 MD5로 암호화
                                   //string test = this.GetMd5(pwd);
            string sQuery = "SELECT * FROM 개발사 WHERE 아이디='" + id + "' AND 비밀번호='" + this.GetMD5(pw) + "'";

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
            string sQuery = "SELECT * FROM 개발사 WHERE 아이디 = '" + id + "'";
            SqlDataReader myReader = dbManager.ExecuteReader(sQuery);
            if (myReader.Read()) result = false;
            myReader.Close();
            dbManager.DBClose();
            return result;
        }

        public int RegistDev(DevDo dDo)
        {
            dbManager = new DBManager();

            //모든메소드 dbManager = new DBManager(); 
            //프로시저사용시 SqlCommand mCmd = new SqlCommand("procAddUser",dbManager.Open());
            //메소드 처음에 해주기

            SqlCommand mCmd = new SqlCommand("procAddDevAcc", dbManager.Open());

            mCmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param;
            param = new SqlParameter("@아이디", SqlDbType.Char, 12);
            param.Value = dDo.Userid;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@비밀번호", SqlDbType.Char, 32);
            param.Value = this.GetMD5(dDo.Passwd);
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@개발사이름", SqlDbType.NVarChar, 25);
            param.Value = dDo.Name;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@개발사로고", SqlDbType.NChar, 50);
            param.Value = dDo.Profileimg;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("개발사소개", SqlDbType.NVarChar, 150);
            param.Value = dDo.Devintro;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("사이트링크", SqlDbType.VarChar, 150);
            param.Value = dDo.Link;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@이메일", SqlDbType.VarChar, 30);
            param.Value = dDo.Email;
            mCmd.Parameters.Add(param);

            SqlParameter paramOut = new SqlParameter("@result", SqlDbType.Int);
            paramOut.Direction = ParameterDirection.Output;
            mCmd.Parameters.Add(paramOut);
            return dbManager.ExecuteStoredProcedure(mCmd, paramOut);
        }
    }
}