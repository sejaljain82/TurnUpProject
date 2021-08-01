using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace TC_IC_API1.BDD
{
 [Binding]
   public class BillingOrderSteps
    {
        IWebDriver browser;
        private readonly ScenarioContext scenarioContext;

        public BillingOrderSteps (ScenarioContext scenarioContex)
        {
           this.scenarioContext = scenarioContex;
        }

        [Given(@"Open Billing Order Page")]
        public void OpenBillingOrderPage() 
        {
            browser = (IWebDriver)scenarioContext["Driver"];
            string username =(string)scenarioContext["Username"];
            string password = (string)scenarioContext["Password"];
        }
        [When(@"Enter user details")]
        public void WhenEnterUserDetails()
        {
            
        }

        [When(@"Submit user details")]
        public void WhenSubmitUserDetails()
        {
            
        }

        [Then(@"Form should be submitted successfully")]
        public void ThenFormShouldBeSubmittedSuccessfully()
        {
           
        }



    }
}
