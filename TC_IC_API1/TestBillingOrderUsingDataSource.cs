using FluentAssertions;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TC_IC_API1.ApiFunction;
using TC_IC_API1.Model;

namespace TC_IC_API1
{
    class TestBillingOrderUsingDataSource
    {
     

        [TestCaseSource(nameof(BillingOrderTestCaseData))]
        //Test case for Creating anOder using Testcasesource object 
        public void TC_CreateOdrerusingTestCaseSource(BillingOrder expectedbillingOrder)
        {
            BillingOrderAPI billingOrderObj = new BillingOrderAPI();

            //converting the object into Jason formate
            string jsonBody = JsonConvert.SerializeObject(expectedbillingOrder);
            IRestResponse response = billingOrderObj.PostOrder(jsonBody);
            //Converying the json format response to BillingOrder object 
            BillingOrder actualbillingOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);
            
            expectedbillingOrder.Should().BeEquivalentTo(actualbillingOrder, options => options.Excluding(o => o.id));
        }
        public static IEnumerable BillingOrderTestCaseData
        {
            get

            {
                yield return new TestCaseData(new BillingOrder
                {
                    addressLine1 = "abc",
                    addressLine2 = "abc2",
                    city = "abc1",
                    comment = "efg",
                    email = "ab@ef.com",
                    firstName = "Tom",
                    itemNumber = 1,
                    lastName = "xyz",
                    phone = "1234567890",
                    state = "AL",
                    zipCode = "123456"
                }).SetName("Create BillingOrder Test Case");

                yield return new TestCaseData(new BillingOrder { email = "abcom" }).SetName("Email Validation");
                yield return new TestCaseData(new BillingOrder { phone = "12345" }).SetName("Phone number Validation");
                yield return new TestCaseData(new BillingOrder { zipCode = "12" }).SetName("Zipcode number Validation");

            }

        }
        public static IEnumerable BillingOrderCSVTestCaseData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory+ "\\Utility\\BillingOrderTestData.csv";
            var csv = new CsvReader(new StreamReader(Path.Combine(path)), true);
            {
                while (csv.ReadNextRecord())
                {
                    string descreption =csv["descreption"];
                    BillingOrder order = new BillingOrder(
                        addressLine1 :csv["addressLine1"],
                        addressLine2 : csv["addressLine2"],
                        city :csv["city"],
                        comment: csv["comment"],
                        email : csv["email"],
                        firstName: csv["firstname"],
                        itemNumber :int.Parse(csv["itemnumber"]),
                        lastName : csv["lastname"],
                        phone :csv["phone"],
                        state :csv["state"],
                        zipCode : csv["zipcode"]
                    );
                    yield return new TestCaseData(order).SetName(descreption);

                }
             
            }
        }
        [TestCaseSource(nameof(BillingOrderCSVTestCaseData))]
        //Test case for Creating an Order using Testcasesource object 
        public void TC_CreateOdrerusingCSVTestCaseSource(BillingOrder expectedbillingOrder)
        {
            BillingOrderAPI billingOrderObj = new BillingOrderAPI();

            //converting the object into Jason formate
            string jsonBody = JsonConvert.SerializeObject(expectedbillingOrder);
            IRestResponse response = billingOrderObj.PostOrder(jsonBody);
            //Converying the json format response to BillingOrder object 
            BillingOrder actualbillingOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);

            expectedbillingOrder.Should().BeEquivalentTo(actualbillingOrder, options => options.Excluding(o => o.id));
        }
    }
}