using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TC_IC_API1.Utility;

namespace TC_IC_API1.Model
{
   public class BillingOrder
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string comment { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public int id { get; set; }
        public int itemNumber { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }

        public BillingOrder(string addressLine1=null , string addressLine2=null , string city=null, string comment=null, string email=null, string firstName=null,int? itemNumber=0, string lastName=null, string phone=null , string state=null, string zipCode=null )
        {
            this.addressLine1 = addressLine1 ?? DataGenerator.RandomString(10);
            this.addressLine2 = addressLine2 ?? DataGenerator.RandomString(10);
            this.city = city ?? DataGenerator.RandomString(10);
            this.comment = comment ?? DataGenerator.RandomString(10);
            this.email = email ?? TestContext.CurrentContext.Random.GetString()+"@ef.com";
            this.firstName = firstName ?? DataGenerator.FullName;
            //  this.id = id;
            this.itemNumber = itemNumber ?? int.Parse(DataGenerator.RandomStringint(2));
            this.lastName = lastName ?? DataGenerator.LastName;
            this.phone = phone ??  DataGenerator.RandomStringint (10) ;
            this.state = state ?? "AL";
            this.zipCode = zipCode ??DataGenerator.RandomStringint (6);
        }

    }
}
