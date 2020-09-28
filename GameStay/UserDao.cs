using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using GameStay;

public class UserDao
{
    public UserDao()
    {

    }

    public bool Authenticate(string id, string pw)
    {
        //리턴값 및 아웃 참조변수 초기화
        bool isAuthen = false; //리턴값 false - 미인증상태
        //뭐리문 이용하여 조건(id, pwd, 탈퇴하지 않음) 에 일치하는 자료를 불러옴. 비밀번호는 MD5로 암호화
        //string test = this.GetMd5(pwd);
        string sQuery = "SELECT * FROM 유저 WHERE 아이디='" + id + "' AND 비밀번호='" + pw + "'";
        //dbman.executeReader() 메서드를 호출하여 결과를 가져옴
        SqlDataReader mReader = DBManager.ExecuteReader(sQuery);

        //결과값이 존재하면 인증성공, 없으면 인증실패
        if (mReader.Read()) isAuthen = true;

        //1학년 방식 : 쿼리문을 이용하여 암호와 현재상태 값을 가져옴
        //sqldatareader 객체를 닫음
        mReader.Close();
        //DB연결해제
        DBManager.DBClose();
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

    public string GetNickname(string uid)
    {
        string nickname = null; //리턴값 초기회
        //쿼리문을 이용하여 닉네임을 읽어옴
        string sQuery = "SELECT 닉네임 FROM 유저 WHERE 아이디 = '" + uid + "'";
        SqlDataReader mReader = DBManager.ExecuteReader(sQuery);
        //userid 존재 여부 확인 후 닉네임 지정
        if (mReader.Read())
        {
            nickname = mReader["닉네임"].ToString().TrimEnd();
        }
        //mReader 닫기, 닫지 않으면 추후 sqldatareader를 만들 때 오류 발생
        mReader.Close();
        //DB 연결 해제
        DBManager.DBClose();
        //리턴값 반환
        return nickname;
    }
}