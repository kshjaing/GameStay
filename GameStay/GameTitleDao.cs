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

            SqlCommand mCmd = new SqlCommand("procAddTitle", dbManager.Open());

            mCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;


            return dbManager.ExecuteStoredProcedure(mCmd, paramOut);
        }
    }
}