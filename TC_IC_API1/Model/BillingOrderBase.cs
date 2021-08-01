using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TC_IC_API1.Model
{
   public class BillingOrderBase
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public BillingOrderComplexClass Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

