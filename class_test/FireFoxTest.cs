using NUnit.Framework.Interfaces;using OpenQA.Selenium;using OpenQA.Selenium.Chrome;using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;using OpenQA.Selenium.IE;

namespace class_test{    public class FireFoxTest    {        public static IWebDriver driver;        public Dictionary<string, string> filter = new Dictionary<string, string>();        [SetUp]        public void startBrowser()        {            driver = BrowserFactory.GetDriver("firefox", new List<string> { });
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);            filter.Add("Price_Lower_Then", "100");            filter.Add("Price_Higher_Or_Equal_Then", "50");            filter.Add("Free_Shipping", "true");        }        [Test]        public void UnitTest()        {            Amazon Amazon = new Amazon(driver);            Amazon.Pages.Home.SearchBar.Text = "mouse";            Amazon.Pages.Home.SearchBar.Click();            Amazon.Pages.Results.GetResultsBy(filter);            Assert.Pass();        }



        [TearDown]

        public void closeBrowser()        {
            //driver.Close()
        }

    }}