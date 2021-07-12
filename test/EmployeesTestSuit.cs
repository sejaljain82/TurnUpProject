using june2021.Pages;
using june2021.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace june2021.test
{
    [TestFixture]
    [Parallelizable]
    class EmployeesTestSuit:CommonDriver
    {
        HomePage homePageobj = new HomePage();
        EmployeesPage employeesobj = new EmployeesPage();
        [Test]
        public void CreatEmployeesTest()
        {
            //Test the navigation to Time and Material Page by creating Homepage object
            homePageobj.GoToEmployeesPage(driver);

            //Creat new Employees record
            employeesobj.CreatEmployees(driver);
        }

        [Test]
        public void EditEmployeesTest()
        {
            //Test the navigation to Employees Page by creating Homepage object
            homePageobj.GoToEmployeesPage(driver);

            // Edit Employees record
            employeesobj.EditEmployees(driver);
        }

        [Test]
        public void DeleteEmployeesTest()
        {
            //Test the navigation to Time and Material Page by creating Homepage object
            homePageobj.GoToEmployeesPage(driver);

            // Delete Employees record
            employeesobj.DeleteEmployees(driver);
        }
       
    }
}
