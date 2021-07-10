using System;
using System.Threading;
using june2021.Pages;
using june2021.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace june2021
{
    [TestFixture]
    class Program : CommonDriver
    {
       // static void Main(string[] args)
     //   {
      //      Console.WriteLine("Hello World!");

            // open chrome browser


            //Test the Creat New ,Edit and Delete funtion by creating TM Paje object 
           

       // }

        [SetUp]
        public void LoginSteps()
        {
            driver = new ChromeDriver(@"C:\Sejal\Industry Connect\week2\june2021");
            Thread.Sleep(500);

            driver.Manage().Window.Maximize();
            Thread.Sleep(500);


            // Test Login page by Creating the LoginPage object and login function
            LoginPage loginobj = new LoginPage();
            loginobj.Login(driver);

            //Test the navigation to Time and Material Page by creating Homepage object
            HomePage homePageobj = new HomePage();
            homePageobj.GoToTMPage(driver);
        }
        [Test]
        public void CreatTMTest()
        {
            TMPage TMPageobj = new TMPage();
            TMPageobj.CreateTM(driver);
        }
        [Test]
        public void EditTMTest()
        {
            TMPage TMPageobj = new TMPage();
            TMPageobj.EditTM(driver);
        }
        [Test]
        public void DeleteTMTest()
        {
            TMPage TMPageobj = new TMPage();
            TMPageobj.DeleteTM(driver);
        }
        [TearDown]
        public void ClosetestRun()
        {
        }
    }
}
