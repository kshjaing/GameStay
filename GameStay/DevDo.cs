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

        private string devintr;
        public string Devintr
        {
            get { return devintr; }
            set { devintr = value; }
        }

        private string profileimg;
        public string Profileimg
        {
            get { return profileimg; }
            set { profileimg = value; }
        }

        public DevDo(string uid, string pwd, string name)
        {
            this.userid = uid;
            this.passwd = pwd;
            this.name = name;
        }


        public DevDo(string profimg, string devintr)
        {
            this.profileimg = profimg;
            this.devintr = devintr;
        }
    }
}