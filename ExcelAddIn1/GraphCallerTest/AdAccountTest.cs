using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphCaller;

namespace GraphCallerTest
{
    [TestClass]
    public class AdAccountTest
    {
        // This is an old invalidate valude , but should serve as an warning no leakage of sensitive and sensible data
        public static readonly string testAdAccount = "CAACZBwbJIzL0BAPXZC7kufhmUsbBgaB8A8ZCh9SEQx6Ms4BpNCo1xPlvdJHjG263qCJRNK7Moa15zpPQCpdxMrxOHCb4aZB5zDSQBLpjsUWKfZCBZCH80cpZBUDkZCQlqoZAT7v4TFKAOQbFPnKWezMe3tMQnhYZCTQePLL7FJVRexAmkxSJFtU8kO";
            //do update with the real deal - access token
        public const long florinAdAccount = 10151318637546538;  

       [TestMethod]
        public void GetAdAccount()
        {
            // call
            var account = AdAccount.getAdAccount(testAdAccount, florinAdAccount);
            // assert
            Assert.AreEqual(florinAdAccount, account.AccontID);
            Assert.IsTrue(account.DailySpend > 0);
        }

        [TestMethod]
        public void GetAdGroup()
        {
            // call
            var adgroup = AdGroups.getAdGroup(testAdAccount, florinAdAccount);
            // assert
            //Assert.AreEqual(florinAdAccount, adgroup.AdgroupAccontID);
        }
        
    }
}
