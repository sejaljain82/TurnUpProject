using System;
using System.Threading;
using june2021.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace june2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // open chrome browser
            IWebDriver driver = new ChromeDriver(@"C:\Sejal\Industry Connect\week2\june2021");
            Thread.Sleep(500);
                         
            driver.Manage().Window.Maximize();
            Thread.Sleep(500);

            
            // Test Login page by Creating the LoginPage object and login function
            LoginPage loginobj = new LoginPage();
            loginobj.Login(driver);

            //Test the navigation to Time and Material Page by creating Homepage object
            HomePage homePageobj = new HomePage();
            homePageobj.GoToTMPage(driver);

            //Test the Creat New ,Edit and Delete funtion by creating TM Paje object 
            TMPage TMPageobj = new TMPage();
            TMPageobj.CreateTM(driver);
            TMPageobj.EditTM(driver);
            TMPageobj.DeleteTM(driver);


        }
    }
}

