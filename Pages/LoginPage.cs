using june2021.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace june2021.Pages
{
    class LoginPage
    {
        //Test Login function
        public void Login(IWebDriver driver)
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
            Wait.WaitForWebElementtoExits(driver, "XPath", "//*[@id='logoutForm']/ul/li/a",1);

            // check if user is logged in successfully
            IWebElement hellohari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (hellohari.Text == "Hello hari!")
            {
                Console.WriteLine("Loggedin successfully, test passed");
            }
            else
            {
                Console.WriteLine("Log in failed, test failed");
            }
        }
    }
}
