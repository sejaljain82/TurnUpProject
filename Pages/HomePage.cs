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
        //Function to navigate to Tme and Material Page
        public void GoToTMPage(IWebDriver driver)
        
        {
            //identify the Administratoion dropdown

            IWebElement adimin = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
            adimin.Click();
            Wait.WaitForWebElementtoExits(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 1);
            
            //identify the Time and Material button
            IWebElement TMB = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TMB.Click();
            Thread.Sleep(2000);
            

        }
        //Function to navigate to Employees Page
        public void GoToEmployeesPage(IWebDriver driver)

        {
            //identify the Administratoion dropdown

            IWebElement adimin = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
            adimin.Click();
            Wait.WaitForWebElementtoExits(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a", 1);

            //identify the Employees button
            IWebElement EmployeesB = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));
            EmployeesB.Click();
            Thread.Sleep(2000);


        }
    }
}
