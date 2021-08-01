using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TC_IC_API1.ApiFunction
{
    class BillingOrderAPI
    {
        private readonly string BaseUrl = "http://localhost:8080";
       
        //Funtion to Read all the Data from API 
        public IRestResponse GetAllOrder()
        {
            var client = new RestClient($"{BaseUrl}/BillingOrder");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            return response;
        }
        //Funtion to read Data from API by giving the Order Id 
        public IRestResponse GetOrderById(string id)
        {
            var client = new RestClient($"{BaseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            return response;
        }

        //Funtion to Delete Data from API by giving the Order Id 
        public IRestResponse DeleteOrderById(string id)
        {
            var client = new RestClient($"{BaseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.DELETE);
            
            IRestResponse response = client.Execute(request);
            return response;
        }

        //Function to Create/Post a new record in the Billing Order API 
        public IRestResponse PostOrder(string Body)
        {
            var client = new RestClient($"{BaseUrl}/BillingOrder");
            var request = new RestRequest(Method.POST);

            //Setting Header so that we know data is in jason format
            request.AddHeader("Content-Type", "application/json");

            //Sending the data to the API which is passed in the string named as Body
            request.AddParameter("application/json", Body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            return response;
        }

        //Function to Update/Put a record in the Billing Order API using Id
        public IRestResponse PutOrder(string Body, string id)
        {
            var client = new RestClient($"{BaseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.PUT);

            //Setting Header so that we know data is in jason format
            request.AddHeader("Content-Type", "application/json");

            //Sending the data to the API which is passed in the string named as Body
            request.AddParameter("application/json", Body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
