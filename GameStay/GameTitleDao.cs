using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameStay
{
    public class GameTitleDao
    {
        DBManager dbManager;
        GameTitleDo gtdo;
        public int uploadGame(GameTitleDo gtdo)
        {
            dbManager = new DBManager();

            SqlCommand mCmd = new SqlCommand("procAddGame", dbManager.Open());

            mCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;
            param = new SqlParameter("@게임명", SqlDbType.NVarChar, 20);
            param.Value = gtdo.Title;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@영어게임명", SqlDbType.NVarChar, 50);
            param.Value = gtdo.Titleeng;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@게임가격", SqlDbType.Int);
            param.Value = gtdo.Price;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@할인율", SqlDbType.Float);
            param.Value = gtdo.Discount;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@게임소개", SqlDbType.NVarChar, 500);
            param.Value = gtdo.Introduce;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@출시일", SqlDbType.SmallDateTime);
            param.Value = gtdo.Rdate;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@개발사이름", SqlDbType.NVarChar, 50);
            param.Value = gtdo.Developer;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@메인이미지", SqlDbType.NVarChar, 150);
            param.Value = gtdo.Mainimg;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@와이드이미지", SqlDbType.NVarChar, 150);
            param.Value = gtdo.Wideimg;
            mCmd.Parameters.Add(param);

            param = new SqlParameter("@이미지4대3", SqlDbType.NVarChar, 150);
            param.Value = gtdo.Subimg;
            mCmd.Parameters.Add(param);


            param = new SqlParameter("@대표영상링크", SqlDbType.NVarChar, 300);
            param.Value = gtdo.Videolink;
            mCmd.Parameters.Add(param);

            SqlParameter paramOut = new SqlParameter("@번호", SqlDbType.Int);
            paramOut.Direction = ParameterDirection.Output;
            mCmd.Parameters.Add(paramOut);

            return
            dbManager.ExecuteStoredProcedure(mCmd, paramOut);
        }

        public void uploadimg(string fname, string title)
        {
            dbManager = new DBManager();
            string qryInsert = "INSERT INTO 게임소개스샷 " + "(영어게임명, 스크린샷) " + "VALUES('" + title.ToString() + "', '" + fname.ToString() + "')";
            dbManager.ExecuteNonQuery(qryInsert);
        }

        public void SystemMinimum(string title, string mOS, string mCPU, string mMEM, string mVGA, string mhdd)
        {

            dbManager = new DBManager();
            string qryInsert = "INSERT INTO 최소사양 " + "(영어게임명, 운영체제, CPU, 메모리, 그래픽카드, 저장공간) " + "VALUES('" + title + "', '" + 
                mOS + "', '" + mCPU + "', '" + mMEM + "', '" + mVGA + "', '" + mhdd + "')";
            dbManager.ExecuteNonQuery(qryInsert);
            dbManager.DBClose();
        }

        public void SystemRecommend(string title, string rOS, string rCPU, string rMEM, string rVGA, string rhdd)
        {

            dbManager = new DBManager();
            string qryInsert = "INSERT INTO 권장사양 " + "(영어게임명, 운영체제, CPU, 메모리, 그래픽카드, 저장공간) " + "VALUES('" + title + "', '" + rOS + "', '" + 
                rCPU + "', '" + rMEM + "', '" + rVGA + "', '" + rhdd + "')";
            dbManager.ExecuteNonQuery(qryInsert);
            dbManager.DBClose();
        }

        public string GetDev(string uid)
        {
            dbManager = new DBManager();

            string devname = null;
            string squery = "SELECT 개발사이름 FROM 개발사 WHERE 아이디 = '" + uid + "'";
            SqlDataReader mReader = dbManager.ExecuteReader(squery);
            if (mReader.Read())
            {
                devname = mReader["개발사이름"].ToString().TrimEnd();
            }
            mReader.Close();
            dbManager.DBClose();
            return devname;
        }
    }
}