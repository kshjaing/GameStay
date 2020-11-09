using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace GameStay
{
    public class GameTitleDo
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string titleeng;
        public string Titleeng
        {
            get { return titleeng; }
            set { titleeng = value; }
        }
        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        private float discount;
        public float Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        private int rating;
        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        private string introduce;
        public string Introduce
        {
            get { return introduce; }
            set { introduce = value; }
        }

        private string rdate;
        public string Rdate
        {
            get { return rdate; }
            set { rdate = value; }
        }
        private string developer;
        public string Developer
        {
            get { return developer; }
            set { developer = value; }
        }
        private string mainimg;
        public string Mainimg
        {
            get { return mainimg; }
            set { mainimg = value; }
        }
        private string wideimg;
        public string Wideimg
        {
            get { return wideimg; }
            set { wideimg = value; }
        }
        private string subimg;
        public string Subimg
        {
            get { return subimg; }
            set { subimg = value; }
        }
        private string videolink;
        public string Videolink
        {
            get { return videolink; }
            set { videolink = value; }
        }
        public GameTitleDo(string title, string titleeng, int price, float discount, string introduce, string rdate, string developer, string mainimg, string wideimg, string subimg, string videolink)
        {
            this.title = title;
            this.titleeng = titleeng;
            this.price = price;
            this.discount = discount;
            this.introduce = introduce;
            this.rdate = rdate;
            this.developer = developer;
            this.mainimg = mainimg;
            this.wideimg = wideimg;
            this.subimg = subimg;
            this.videolink = videolink;
        }


        //요구사항
        private string mos;
        public string Mos
        {
            get { return mos; }
            set { mos = value; }
        }
        private string mcpu;
        public string Mcpu
        {
            get { return mcpu; }
            set { mcpu = value; }
        }
        private string mmem;
        public string Mmem
        {
            get { return mmem; }
            set { mmem = value; }
        }
        private string mvga;
        public string Mvga
        {
            get { return mvga; }
            set { mvga = value; }
        }
        private string mhdd;
        public string Mhdd
        {
            get { return mhdd; }
            set { mhdd = value; }
        }

        public GameTitleDo(string mos, string mcpu, string mmem, string mvga, string mhdd)
        {
            this.mos = mos;
            this.mcpu = mcpu;
            this.mmem = mmem;
            this.mvga = mvga;
            this.mhdd = mhdd;
        }

        //권장사양
        private string ros;
        public string Ros
        {
            get { return ros; }
            set { ros = value; }
        }
        private string rcpu;
        public string Rcpu
        {
            get { return rcpu; }
            set { rcpu = value; }
        }
        private string rmem;
        public string Rmem
        {
            get { return rmem; }
            set { mmem = value; }
        }
        private string rvga;
        public string Rvga
        {
            get { return rvga; }
            set { rvga = value; }
        }
        private string rhdd;
        public string Rhdd
        {
            get { return rhdd; }
            set { rhdd = value; }
        }
        public GameTitleDo(string ros, string rcpu, string rmem, string rvga, string rhdd, string title)
        {
            this.ros = ros;
            this.rcpu = rcpu;
            this.rmem = rmem;
            this.rvga = rvga;
            this.rhdd = rhdd;
            this.title = title;
        }

    }
}