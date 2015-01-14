using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphCaller;

namespace GraphCallerTest
{
    [TestClass]
    public class AdAccountTest
    {
        private string testAdAccount = "";
            //do update with the real deal
        private const long florinAdAccount = 10151318637546538;  

        [TestMethod]
        public void GetAdAccount()
        {
            // call
            var account = AdAccount.getAdAccount(testAdAccount, florinAdAccount);
            // assert
            Assert.AreEqual(florinAdAccount, account.AccontID);
            Assert.IsTrue(account.DailySpend > 0);
        }
    }
}
