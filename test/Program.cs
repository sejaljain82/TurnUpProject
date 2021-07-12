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
    [Parallelizable]
    class Program : CommonDriver
    {
        // static void Main(string[] args)
        //   {
        //      Console.WriteLine("Hello World!");

        // open chrome browser


        //Test the Creat New ,Edit and Delete funtion by creating TM Paje object 


        // }

        HomePage homePageobj = new HomePage();
        TMPage TMPageobj = new TMPage();

        [Test]
        public void CreatTMTest()
        {
            //Test the navigation to Time and Material Page by creating Homepage object
            homePageobj.GoToTMPage(driver);

            //Create new Time and  Material record
            TMPageobj.CreateTM(driver);
        }
        [Test]
        public void EditTMTest()
        {
            //Test the navigation to Time and Material Page by creating Homepage object
            homePageobj.GoToTMPage(driver);

            //Edit Time and  Material record
            TMPageobj.EditTM(driver);
        }
        [Test]
        public void DeleteTMTest()
        { 
            //Test the navigation to Time and Material Page by creating Homepage object
            homePageobj.GoToTMPage(driver);

            //Delete Time and Material record
             TMPageobj.DeleteTM(driver);
        }
       
    }
}
