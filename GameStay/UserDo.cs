using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStay
{
    public class UserDo
    {
        private string userid;
        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        private string passwd;
        public string Passwd
        {
            get { return passwd; }
            set { passwd = value; }
        }

        private string nickname;
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int level;
        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        private int ugrade;
        public int Ugrade
        {
            get { return ugrade; }
            set { ugrade = value; }
        }

        private string profileimg;
        public string Profileimg
        {
            get { return profileimg; }
            set { profileimg = value; }
        }

        public UserDo(string uid, string pwd, string nickname, string email)
        {
            this.userid = uid;
            this.passwd = pwd;
            this.nickname = nickname;
            this.email = email;
        }

        public UserDo(string profimg)
        {
            this.profileimg = profimg;
        }

    }

    
}