using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
namespace class_test
{
    public class UnitTest1
    {
        public static IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver("C:\\Drivers\\", options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [Test]
        public void test()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com");
            Amazon Amazon = new Amazon(new ChromeDriver());
            Amazon.Pages.Home.searchBar.Text = "mouse";
            Amazon.Pages.Home.searchBar.Click();
            //Amazon.Pages.Results.GetResultsBy();
        }
        [TearDown]
        public void closeBrowser()
        {
            // driver.Close();
        }
    }
}