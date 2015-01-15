using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GraphCaller;

namespace GraphCallerTest
{
    [TestClass]
    public class AdgroupPostTest
    {
        const long test_adgroup =  6018423759292;// an adgroup from Florin's Ad account

        [TestMethod]
        public void PostAdgrpoup()
        {
            // call
            Uploader.Edit(test_adgroup.ToString(), AdAccountTest.testAdAccount, 
                new Dictionary<string, object>() {
                    {"name", "trywebsites.azurewebsites.net/ - Website Clicks - Image 1<success>"+DateTime.Now.ToString()} 
                }
              );
            // validation - no exceptions
            
        }
    }
}
