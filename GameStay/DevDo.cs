using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStay
{
    public class DevDo
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

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string devintro;
        public string Devintro
        {
            get { return devintro; }
            set { devintro = value; }
        }

        private string profileimg;
        public string Profileimg
        {
            get { return profileimg; }
            set { profileimg = value; }
        }

        private string link;
        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public DevDo(string uid, string pwd, string name, string profimg, string devintro, string link, string email)
        {
            this.userid = uid;
            this.passwd = pwd;
            this.name = name;
            this.profileimg = profimg;
            this.devintro = devintro;
            this.link = link;
            this.email = email;
        }
    }
}