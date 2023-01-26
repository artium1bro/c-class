
using class_test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace class_test
{
    public class Results
    {
        private IWebDriver driver;

        public Results(IWebDriver driver)
        {
            this.driver = driver;
        }
        public List<Item> GetResultsBy(Dictionary<string, string> filters)
        {
            List<Item> items = new List<Item>();

            string xPath = "//div[@data-component-type='s-search-result' ";

            foreach (string key in filters.Keys)
            {
                switch (key)
                {
                    case "Price_Lower_Then":
                        xPath += "and descendant::span[@class='a-offscreen' and translate(text(),'$,','')<" + filters[key] + " and parent::span[not(contains(@data-a-strike,'true'))]]";
                        break;
                    case "Price_Higher_Or_Equal_Then":
                        xPath += "and descendant::span[@class='a-offscreen' and translate(text(),'$,','')>=" + filters[key] + " and parent::span[not(contains(@data-a-strike,'true'))]]";
                        break;
                    case "Fre_Shipping":
                        if (filters[key].Equals("true"))
                        {
                            xPath += "and descendant::span[@class='a-color-base a-text-bold' and contains (text(),'FREE')]";
                        }
                        break;
                    default:
                        return null;
                }
            }
            xPath += "]";

            List<IWebElement> webElements = this.driver.FindElements(By.XPath(xPath)).ToList<IWebElement>();

            foreach (IWebElement webElement in webElements)
            {
                // Get the title, price, and link
                string title = webElement.FindElement(By.XPath(".//span[@class='a-size-medium a-color-base a-text-normal']")).Text;
                string price = webElement.FindElement(By.XPath(".//span[@class= 'a-price-whole']")).Text + '.' + webElement.FindElement(By.XPath("//span[@class='a-price-fraction']")).Text + '$';
                string link = webElement.FindElement(By.XPath(".//a[@class='a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal']")).GetAttribute("href");

                Item itemElement = new Item(title, price, link);
                items.Add(itemElement);

                Console.WriteLine(itemElement.toString());
            }
            return items;
        }
    }
}