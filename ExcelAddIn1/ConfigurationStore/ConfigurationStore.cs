using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationStore
{
    /*
     Local cache of configuration this can store safely stuff like access tokens such is not exposed 
     * 
     * in code when check in
     
     */
    public class Store
    {
        //ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public Store() { 
            // load the config whatever that would be
            this.DefaultCredential = new AccessCredential("default");
        }

        public AccessCredential DefaultCredential { get; set; }

        public void Save() {
            this.DefaultCredential.Save();

        }

    }
 
}
