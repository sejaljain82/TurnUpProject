using june2021.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace june2021.Pages
{
    class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            //identify the Administratoion dropdown

            IWebElement adimin = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
            adimin.Click();
            Wait.WaitForWebElementtoExits(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 1);
            
            //identify the Time and Material button
            IWebElement TMB = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TMB.Click();
           


        }
    }
}
