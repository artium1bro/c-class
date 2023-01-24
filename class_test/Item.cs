using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace class_test
{
    public class Item
    {
        private string title;
        private string price;
        private string link;
        public Item(String title,string price,string link)
        {
            this.title = title;
            this.price = price; 
            this.link=link; 
        }
        
        public string Title { get { return this.title; } }
        public string Price { get { return this.price;} }
        public string Link { get { return this.link; } }

    }
    
}
