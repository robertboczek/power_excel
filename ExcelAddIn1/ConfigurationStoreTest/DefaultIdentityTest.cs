using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConfigurationStoreTest
{
    [TestClass]
    public class DefaultIdentityTest
    {
        [TestMethod]
        public void LoadAndSaveDefault()
        {
            // Load
            var config = new ConfigurationStore.Store();

            // Validate
            Assert.IsNotNull(config.DefaultCredential);
            Assert.IsNotNull(config.DefaultCredential.Access_token);
            
            // update
            config.DefaultCredential.Access_token = "test";
            config.Save();

            // re-load
            var config2 = new ConfigurationStore.Store();
            Assert.AreEqual("test", config2.DefaultCredential.Access_token);
        }
    }
}
