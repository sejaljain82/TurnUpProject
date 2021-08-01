using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System.Collections;
using TC_IC_API1.ApiFunction;
using TC_IC_API1.Model;

namespace TC_IC_API1
{
    public class Tests
    {
        [SetUp]
   
        [Test]
        //Test case for Reading all Order 
        public void TC_GetAllOrder()
        {

            BillingOrderAPI billingOrderObj = new BillingOrderAPI();

            IRestResponse response = billingOrderObj.GetAllOrder();

            TestContext.WriteLine(response.Content);
        }

        [Test]
       //Test case for Reading Order using Id
        public void TC_GetOrder()
        {
            
            BillingOrderAPI billingOrderObj = new BillingOrderAPI();

            IRestResponse response = billingOrderObj.GetOrderById("3");
            
            TestContext.WriteLine(response.Content);
        }

        [Test]
        //Test case for Creating Order
        public void TC_PostOrder()
        {
            //Inserting the data in string formate 
            // string Body = "{\"addressLine1\": \"abc2\",\"addressLine2\": \"abc3\",\"city\":\"abccity\",\"comment\":\"xyz\",\"email\":\"ab@ab.com\",\"firstName\":\"abc\",\"id\":0,\"itemNumber\":1,\"lastName\":\"abc1\",\"phone\": \"1234567890\",\"state\":\"AL\",\"zipCode\":\"123456\"}";

            //Inserting the data using Object of class BiillingOder
            BillingOrder expectedbillingOrder = new BillingOrder {
                addressLine1  = "abc",
                addressLine2 = "abc2",
                city = "abc1",
                comment ="efg",
                email = "ab@ef.com",
                firstName = "Tom",
                itemNumber = 1,
                lastName = "zyx",
                phone = "1234567890",
                state = "AL",
                zipCode = "123456"
            };
            //converting the object into Jason formate
            string jsonBody = JsonConvert.SerializeObject(expectedbillingOrder);

            //Creating Billing Order 
            BillingOrderAPI billingOrderObj = new BillingOrderAPI();
            IRestResponse response = billingOrderObj.PostOrder(jsonBody);
            TestContext.WriteLine(response.Content);

            //Converying the json format response to BillingOrder object 
            BillingOrder actualbillingOrder= JsonConvert.DeserializeObject<BillingOrder>(response.Content);

            //Compering one value
            Assert.AreEqual(expectedbillingOrder.firstName, actualbillingOrder.firstName);

            //As Id is generated Dynamicly not passed in the object we can use the following hack and compere the whole object
           // expectedbillingOrder.id = actualbillingOrder.id;
            //expectedbillingOrder.Should().BeEquivalentTo(actualbillingOrder);
            
            //Id field can be Excluded for the coperision by passing it in the options parameter in the Excluding function 
            expectedbillingOrder.Should().BeEquivalentTo(actualbillingOrder, options => options.Excluding(o => o.id));
          
        }

        [Test]
        //Test case for Creating Order
        public void TC_UIBillingOrder()
        {
            //Inserting the data in string formate 
            // string Body = "{\"addressLine1\": \"abc2\",\"addressLine2\": \"abc3\",\"city\":\"abccity\",\"comment\":\"xyz\",\"email\":\"ab@ab.com\",\"firstName\":\"abc\",\"id\":0,\"itemNumber\":1,\"lastName\":\"abc1\",\"phone\": \"1234567890\",\"state\":\"AL\",\"zipCode\":\"123456\"}";

            IWebDriver driver = new ChromeDriver();

            //Inserting the data using Object of class BiillingOder
            BillingOrder expectedbillingOrder = new BillingOrder
            {
                addressLine1 = "abc",
                addressLine2 = "abc2",
                city = "abc1",
                comment = "efg",
                email = "ab@ef.com",
                firstName = "Tom",
                itemNumber = 1,
                lastName = "zyx",
                phone = "1234567890",
                state = "AL",
                zipCode = "123456"
            };
            TestBillingOrderPage orderPage = new TestBillingOrderPage(driver);
            orderPage.SubmitBillingOrder(expectedbillingOrder);

        }

        [Test]
        //Test case for Updating Order
        public void TC_PutOrder()
        {
            string Body = "{\"addressLine1\": \"abc2\",\"addressLine2\": \"abc3\",\"city\":\"abccity\",\"comment\":\"xyz234\",\"email\":\"ab@ab.com\",\"firstName\":\"abc\",\"id\":0,\"itemNumber\":1,\"lastName\":\"abc1\",\"phone\": \"1234567890\",\"state\":\"AL\",\"zipCode\":\"123456\"}";

            BillingOrderAPI billingOrderObj = new BillingOrderAPI();

            IRestResponse response = billingOrderObj.PutOrder(Body, "127");
            TestContext.WriteLine(response.Content);
        }
        [Test]
        //Test case for Creating 100 Orders
        public void TC_PostOrder100Times()
        {
            IRestResponse response;
            string Body;

            BillingOrderAPI billingOrderObj = new BillingOrderAPI();
            for (int i = 1; i <= 100; i++)
            {
                Body =$"{{\"addressLine1\": \"abc{i}\",\"addressLine2\": \"abc{i}\",\"city\":\"abccity\",\"comment\":\"xyz\",\"email\":\"ab@ab.com\",\"firstName\":\"abc\",\"id\":0,\"itemNumber\":1,\"lastName\":\"abc1\",\"phone\": \"1234567890\",\"state\":\"AL\",\"zipCode\":\"123456\"}}";

                response = billingOrderObj.PostOrder(Body);
                TestContext.WriteLine(response.Content);
            }
        }

        [Test]
        //Test case for Deleteing Order using Id
        public void TC_DeleteOrder()
        {

            BillingOrderAPI billingOrderObj = new BillingOrderAPI();

            IRestResponse response = billingOrderObj.DeleteOrderById("45");

            TestContext.WriteLine(response.Content);
        }


    }
}