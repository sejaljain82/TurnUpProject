using NUnit.Framework;
using RestSharp;
using TC_IC_API1.ApiFunction;

namespace TC_IC_API1
{
    public class Tests
    {
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
            string Body = "{\"addressLine1\": \"abc2\",\"addressLine2\": \"abc3\",\"city\":\"abccity\",\"comment\":\"xyz\",\"email\":\"ab@ab.com\",\"firstName\":\"abc\",\"id\":0,\"itemNumber\":1,\"lastName\":\"abc1\",\"phone\": \"1234567890\",\"state\":\"AL\",\"zipCode\":\"123456\"}";
           
            BillingOrderAPI billingOrderObj = new BillingOrderAPI();
           
            IRestResponse response = billingOrderObj.PostOrder(Body);
            TestContext.WriteLine(response.Content);
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