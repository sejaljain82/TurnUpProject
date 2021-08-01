using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TC_IC_API1.Utility
{
    class DataGenerator
    {
        static string a1 = "abcdefghijklmnopqrstuvwxyz";
        static string a2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string num = "0123456789";
        public static string RandomString(int len = 10)
        {
            return TestContext.CurrentContext.Random.GetString(len, $"{a1}{a2}");
        }
        public static string  RandomStringint(int len = 10)
        {
            return TestContext.CurrentContext.Random.GetString(len, $"{num}");
        }
        public static string FullName => Faker.Name.FullName();
        public static string LastName => Faker.Name.FullName();


    }
}
