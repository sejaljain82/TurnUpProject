using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TC_IC_API1.BDD
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public IWebDriver driver;

        private readonly  ScenarioContext _scenarioContext;

        public Hooks1(ScenarioContext scenarioContex)
        {
            _scenarioContext = scenarioContex;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            _scenarioContext["Driver"] = driver;//keeping the driver at common place
            _scenarioContext["Username"] = "Admi";
            _scenarioContext["Password"] = "123123";
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
