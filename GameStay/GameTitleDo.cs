using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        private int discount;
        public int Discount
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
        public GameTitleDo(string title, string titleeng, int price, int discount, string introduce, string developer, string mainimg, string wideimg, string subimg, string videolink)
        {
            this.title = title;
            this.titleeng = titleeng;
            this.price = price;
            this.discount = discount;
            this.introduce = introduce;
            this.developer = developer;
            this.mainimg = mainimg;
            this.wideimg = wideimg;
            this.subimg = subimg;
            this.videolink = videolink;
        }
    }
}