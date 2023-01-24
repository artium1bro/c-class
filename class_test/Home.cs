using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_test
{
    public class Home
    {
        private IWebDriver driver;
        private SearchBar searchBar;

        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SearchBar searchBar
        {
            get
            {
                if (this.searchBar == null)
                {
                    this.searchBar = new SearchBar();
                }
            return this.searchBar
            }
        }
    }
}
