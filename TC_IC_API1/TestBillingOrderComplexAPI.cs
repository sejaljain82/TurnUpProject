using ApprovalTests.Reporters;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TC_IC_API1.ApiFunction;
using TC_IC_API1.Model;

namespace TC_IC_API1
{
    [UseReporter(typeof(VisualStudioReporter))]
    class TestBillingOrderComplexAPI
    {
        public void TC_GetAllOrder()
        {

            BillingOrderComplexAPI billingOrderObj1 = new BillingOrderComplexAPI();

            IRestResponse response = billingOrderObj1.GetAllOrder();

            TestContext.WriteLine(response.Content);
        }

        [Test]
        //Test case for Reading Order using Id
        public void TC_GetOrder()
        {

            BillingOrderComplexAPI billingOrderObj1 = new BillingOrderComplexAPI();

            IRestResponse response = billingOrderObj1.GetOrderById("28");

            TestContext.WriteLine(response.Content);
        }

        [Test]
        //Test case for Creating Order
        public void TC_PostOrder()
        {
            //Inserting the data using Object of class BiillingOder
            BillingOrderComplexClass expectedbillingOrder1 = new BillingOrderComplexClass
            {   
                AddressLine1 = "abc",
                AddressLine2 = "abc2",
                Comment = "efg",
                Email = "ab@ef.com",
                FirstName = "Tom",
                LastName = "zyx",
                PhoneNumber = "1234567890",
                ZipCode = "123456"
            };
            //converting the object into Jason formate
            string jsonBody = JsonConvert.SerializeObject(expectedbillingOrder1);

            //Creating Billing Order 
            BillingOrderComplexAPI billingOrderObj1 = new BillingOrderComplexAPI();
            IRestResponse response = billingOrderObj1.PostOrder(jsonBody);
            TestContext.WriteLine(response.Content);

            //Converying the json format response to BillingOrder object 
            BillingOrderBase actualbillingOrder = JsonConvert.DeserializeObject<BillingOrderBase>(response.Content);

            //Compering one value
            Assert.AreEqual(expectedbillingOrder1.FirstName, actualbillingOrder.Data.FirstName);

          
            //Id field can be Excluded for the coperision by passing it in the options parameter in the Excluding function 
            expectedbillingOrder1.Should().BeEquivalentTo(actualbillingOrder.Data, options => options.Excluding(o => o.Id));

        }
        [Test]
        //Test case for Updating Order
        public void TC_PutOrder()
        {
            string Body = "{\"AddressLine1\": \"abc2\",\"AddressLine2\": \"abc3\",\"Comment\":\"xyz234\",\"Email\":\"ab@ab.com\",\"FirstName\":\"abc\",\"Id\":0,\"LastName\":\"abc1\",\"PhoneNumber\": \"1234567890\",\"ZipCode\":\"123456\"}";
          
            BillingOrderComplexAPI billingOrderObj1 = new BillingOrderComplexAPI();

            IRestResponse response = billingOrderObj1.PutOrder(Body, "28");
            TestContext.WriteLine(response.Content);
        }
        [Test]
        public void TC_DeleteOrder()
        {

            BillingOrderComplexAPI billingOrderObj1 = new BillingOrderComplexAPI();

            IRestResponse response = billingOrderObj1.DeleteOrderById("28");

            TestContext.WriteLine(response.Content);
        }
        [Test]
        //Test case for Creating Order
        // public void TC_SnapShotPostOrder()
        public void TC_PostOrderSnapShot()
        {
            //Inserting the data using Object of class BiillingOder
            BillingOrderComplexClass expectedbillingOrder1 = new BillingOrderComplexClass
            {
                AddressLine1 = "abc",
                AddressLine2 = "abc2",
                Comment = "efg",
                Email = "ab@ef.com",
                FirstName = "Tom",
                LastName = "zyx",
                PhoneNumber = "1234567890",
                ZipCode = "123456"
            };
            //converting the object into Jason formate
            string jsonBody = JsonConvert.SerializeObject(expectedbillingOrder1);

            //Creating Billing Order 
            BillingOrderComplexAPI billingOrderObj1 = new BillingOrderComplexAPI();
            IRestResponse response = billingOrderObj1.PostOrder(jsonBody);
            TestContext.WriteLine(response.Content);

            //Converying the json format response to BillingOrder object 
            BillingOrderBase actualbillingOrder = JsonConvert.DeserializeObject<BillingOrderBase>(response.Content);

            //Compering one value
            actualbillingOrder.Data.Id = 0;
            string jsonBody1 = JsonConvert.SerializeObject(actualbillingOrder);
            ApprovalTests.Approvals.VerifyJson(jsonBody1); 

          
        }
    }
 
}
