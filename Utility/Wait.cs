using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace june2021.Utility
{
    class Wait
    {
        //re-useble function Wait
        public static void WaitForWebElementtoExits(IWebDriver driver, string attribute, string attributvalue, int sectowait)
        {
            var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, sectowait));
            if (attribute == "XPath")
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(attributvalue)));
            }
            if (attribute == "Id")
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(attributvalue)));
            }
            if (attribute == "CssSelector")
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(attributvalue)));
            }
        }
    }
}
