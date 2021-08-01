using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace TC_IC_API1.BDD
{
    [Binding]
    public class SumOfTwoNumberSteps
    {

        int num1;
        int num2;
        int sum;
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int num1)
        {
            this.num1 = num1;
                  }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int num2)
        {
            this.num2 = num2;
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            sum = num1 + num2;
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            Assert.AreEqual(expected, sum);
            
        }
        [TestCaseSource("SumTestData")]
        public void SumTest(int num1, int num2, int sum)
        {
            Assert.AreEqual(num1+num2,sum);
        }

        static object[] SumTestData =
        {
            new object[] { 12, 3, 15 },
            new object[] { 12, 2, 14},
            new object[] { 12, 4, 16}
        };
    }
}
