using june2021.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace june2021.Utility
{
    class CommonDriver
    {
        public  IWebDriver driver;

        [OneTimeSetUp]
        public void LoginSteps()
        {
            driver = new ChromeDriver(@"C:\Sejal\Industry Connect\week2\june2021");
            Thread.Sleep(500);

            driver.Manage().Window.Maximize();
            Thread.Sleep(500);

            // Test Login page by Creating the LoginPage object and login function
            LoginPage loginobj = new LoginPage();
            loginobj.Login(driver);

        }
        [ OneTimeTearDown]
        public void ClosetestRun()
        {
            driver.Quit();
        }
    }
}
