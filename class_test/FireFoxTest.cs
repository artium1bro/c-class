using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Firefox;

namespace class_test
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);



        [TearDown]

        public void closeBrowser()
            //driver.Close()
        }

    }