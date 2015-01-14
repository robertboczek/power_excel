using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphCaller;

namespace GraphCallerTest
{
    [TestClass]
    public class AdAccountTest
    {
        private string testAdAccount = "abc";//do update with the real deal
        private const int florinAdAccount = 123 ;  

        [TestMethod]
        public void GetAdAccount()
        {
            // call
            var account = AdAccount.getAdAccount(testAdAccount, florinAdAccount);
            // assert
            Assert.AreNotEqual(null, account);
        }
    }
}
