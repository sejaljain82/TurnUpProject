using june2021.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace june2021.Pages
{
    class TMPage
    {
        IWebElement DDbox;
        IWebElement codebox;
        IWebElement pricebox;
        IWebElement lastpage;
        IWebElement descriptionbox;
        IWebElement Sbutton;
       IWebElement actulcode;
        //Test Create TM
        public void CreateTM(IWebDriver driver)
        {
            //open creat new page
            IWebElement CreateNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            CreateNewButton.Click();
            Wait.WaitForWebElementtoExits(driver,"XPath","//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]", 2);
        

            //select time from the draop down button
            DDbox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            DDbox.Click();

            //identify code and input code//*[@id="TypeCode"]
            codebox = driver.FindElement(By.Id("Code"));
            codebox.SendKeys("456");

            //identify description and input description
            descriptionbox = driver.FindElement(By.Id("Description"));
            descriptionbox.SendKeys("EFG");

            //identfy price and input price
            pricebox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            pricebox.Click();
            pricebox = driver.FindElement(By.Id("Price"));
            pricebox.SendKeys("16");

            //click on save button
            Sbutton = driver.FindElement(By.Id("SaveButton"));
            Sbutton.Click();
            Wait.WaitForWebElementtoExits(driver,"XPath","//*[@id='tmsGrid']/div[4]/a[4]/span",2);

            //click goto last page 
            lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastpage.Click();
            Wait.WaitForWebElementtoExits(driver,"XPath","//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 1);


            //check if the created record is present in the table and had expected value //*[@id="TimeMaterialEditForm"]/div/div[1]/div/span[1]/span/span[1]

            actulcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (actulcode.Text == "456")
            {
                Console.WriteLine("materiar record created succfully test pass");
            }

            else
            {
                Console.WriteLine("test fail");
            }
           

        }

        //Test Edit TM
        public void EditTM(IWebDriver driver)
        {
            Wait.WaitForWebElementtoExits(driver,"XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 2);
            IWebElement editbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editbutton.Click();

            //edit the dropdown list
            DDbox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            DDbox.Click();
           // Thread.Sleep(500);
            DDbox = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            DDbox.Click();

            //identify code and input code
            codebox = driver.FindElement(By.Id("Code"));
            codebox.Clear();
            codebox.SendKeys("789");

            //identify description and edit  description
            descriptionbox = driver.FindElement(By.Id("Description"));
            descriptionbox.Clear();
            descriptionbox.SendKeys("lmn");

            //identfy price and edit price
            pricebox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            pricebox.Click();
            pricebox = driver.FindElement(By.Id("Price"));
            pricebox.Clear();
            pricebox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            pricebox.Click();
            pricebox = driver.FindElement(By.Id("Price"));
            pricebox.SendKeys("50");


            //click on save button
            Sbutton = driver.FindElement(By.Id("SaveButton"));
            Sbutton.Click();
            //Thread.Sleep(3500);
            Wait.WaitForWebElementtoExits(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 3);

            //click goto last page 
            lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastpage.Click();
            // Thread.Sleep(1500);
            Wait.WaitForWebElementtoExits(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 3);

            //check if the edited record is present in the table and had expected value 
            actulcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (actulcode.Text == "789")
            {
                Console.WriteLine("materiar record edited succfully test pass");
            }

            else
            {
                Console.WriteLine("test fail");
            }
        }
        //Test Delete TM 
        public void DeleteTM(IWebDriver driver)
        {
            //identidy 
            IWebElement Dbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            Dbutton.Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Wait.WaitForWebElementtoExits(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 3);

            lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastpage.Click();
            Wait.WaitForWebElementtoExits(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 2);
           
            //check if the  record is present record is deleted s
            actulcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (actulcode.Text == "789")
            {
                Console.WriteLine("test fail");
            }

            else
            {
                Console.WriteLine("Record deleted succfully test pass");


            }

        }
    }
}