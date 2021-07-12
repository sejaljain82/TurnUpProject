using june2021.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace june2021.Pages
{
    class EmployeesPage
    {
        IWebElement lastpage;
        IWebElement actulname;
        IWebElement NameBox;
        IWebElement UsernameBox;
        IWebElement Password;
        IWebElement RetypePassword;
        IWebElement IsAdmin;
        IWebElement Vehicle;
        IWebElement Groups;
        IWebElement SaveButton;
        IWebElement BackToList;

        //Test Create Employees
        public void CreatEmployees(IWebDriver driver)
        {
            //open creat new page
            IWebElement CreateButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            CreateButton.Click();
            Wait.WaitForWebElementtoExits(driver, "Id", "Name", 2);

            //set Name
            NameBox = driver.FindElement(By.Id("Name"));
            NameBox.SendKeys("Tom");
            //set Username
            UsernameBox = driver.FindElement(By.Id("Username"));
            UsernameBox.SendKeys("Tom1");
         
            Password = driver.FindElement(By.Id("Password"));
            Password.SendKeys("123$Abcd");
           
            RetypePassword = driver.FindElement(By.Id("RetypePassword"));
            RetypePassword.SendKeys("123$Abcd");

            IsAdmin = driver.FindElement(By.Id("IsAdmin"));
            IsAdmin.Click();

            Vehicle = driver.FindElement(By.XPath("//*[@id='UserEditForm']/div/div[7]/div/span[1]/span/input"));
            Vehicle.SendKeys("SUV");

            Groups = driver.FindElement(By.XPath("//*[@id='UserEditForm']/div/div[8]/div/div/div[1]/input"));
            Groups.Click();
            Groups = driver.FindElement(By.XPath("//*[@id='groupList_listbox']/li[10]"));
            Groups.Click();

            SaveButton = driver.FindElement(By.Id("SaveButton"));
            SaveButton.Click();
            Thread.Sleep(2000);
            //*[@id="container"]/div/a
            BackToList = driver.FindElement(By.XPath("//*[@id='container']/div/a"));
            BackToList.Click();
            Thread.Sleep(2000);
           
            lastpage = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            lastpage.Click();
            Thread.Sleep(14000);
            actulname = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (actulname.Text == "Tom")
            {
                Assert.Pass("Record created succfully test pass");
            }
            else
            {
                Assert.Fail("test fail");
            }
            Thread.Sleep(15000);
        }
        //Test Edit Employees
        public void EditEmployees(IWebDriver driver)
        {
            Thread.Sleep(1000);
           //go to last page 
            lastpage = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            lastpage.Click();
            Wait.WaitForWebElementtoExits(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);

            //click onEdit button
            IWebElement Editbutton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            Editbutton.Click();

            NameBox = driver.FindElement(By.Id("Name"));
            NameBox.Clear();
           NameBox.SendKeys("Tomas");
            //set Username
            UsernameBox = driver.FindElement(By.Id("Username"));
            UsernameBox.Clear();
            UsernameBox.SendKeys("Tom2");

            Password = driver.FindElement(By.Id("Password"));
            Password.Clear();
            Password.SendKeys("321$Adcb");

            RetypePassword = driver.FindElement(By.Id("RetypePassword"));
            RetypePassword.Clear();
            RetypePassword.SendKeys("321$Adcb");


            IsAdmin = driver.FindElement(By.Id("IsAdmin"));
            IsAdmin.Click();

            Vehicle = driver.FindElement(By.XPath("//*[@id='UserEditForm']/div/div[7]/div/span[1]/span/input"));
            Vehicle.Click();
            Vehicle.SendKeys("Audi");

            //Groups = driver.FindElement(By.XPath("//*[@id='UserEditForm']/div/div[8]/div/div/div[1]/input"));
            //Groups.Clear();
            //Groups.Click();
            //Groups = driver.FindElement(By.XPath("//*[@id='groupList_listbox']/li[8]"));
            //Groups.Click();

            SaveButton = driver.FindElement(By.Id("SaveButton"));
            SaveButton.Click();
            Thread.Sleep(2000);
            //*[@id="container"]/div/a

          //  BackToList = driver.FindElement(By.XPath("//*[@id='container']/div/a"));
           // BackToList.Click();
           // Thread.Sleep(2000);

           // lastpage = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            lastpage.Click();
            Thread.Sleep(14000);
            actulname = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (actulname.Text == "Tomas")
            {
                Assert.Pass("Record Edit succfully test pass");
            }
            else
            {
                Assert.Fail("test fail");
            }
            
        }


        //Test Delete Employees
        public void DeleteEmployees(IWebDriver driver)
        {       
            Thread.Sleep(2000);
            lastpage = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            lastpage.Click();
            Wait.WaitForWebElementtoExits(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);

            //identify Delete button
            IWebElement Dbutton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
            Dbutton.Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Wait.WaitForWebElementtoExits(driver, "XPath", "//*[@id='usersGrid']/div[4]/a[4]/span", 5);
           
            lastpage = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            lastpage.Click();
            Wait.WaitForWebElementtoExits(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);
           
            actulname = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (actulname.Text == "abcde")
            {
                Assert.Fail("test fail");
            }
            
            else
            {

                Assert.Pass("Record deleted succfully test pass");
            }
        }

    }
}
