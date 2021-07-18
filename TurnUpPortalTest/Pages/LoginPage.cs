using june2021.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit;
using NUnit.Framework;

namespace june2021.Pages
{
    class LoginPage
    {
        //Test Login function
        public void Login(IWebDriver driver)
        {
            try
            {

                // launch turnup portal
                driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
                Wait.WaitForWebElementtoExits(driver, "Id", "UserName", 2);

                // identify username textbox and enter valid username
                IWebElement username = driver.FindElement(By.Id("UserName"));
                username.SendKeys("hari");

                // identify password textbox and enter valid password
                IWebElement password = driver.FindElement(By.Id("Password"));
                password.SendKeys("123123");

                // indentify login action button and click
                IWebElement loginbutton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
                loginbutton.Click();
                Wait.WaitForWebElementtoExits(driver, "XPath", "//*[@id='logoutForm']/ul/li/a", 1);
            }
            catch
            {
                Assert.Fail("Log in failed");
                
            }
         
        }
    }
}
