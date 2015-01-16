using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationStore
{
    public class AccessCredential
    {
        private string path = String.Empty;

        public AccessCredential(string path, string name = "Access") {

            this.path = Path.Combine(path, name);
            
            
            this.Access_token = (string)this.getValue("access_token",String.Empty);
            this.AdAccountId = -1;
            this.AppID = -1;
            this.UserId = -1;
        }

        public long UserId { get; set; }
        public long AppID { get; set; }

        public long AdAccountId { get; set; }

        public string Access_token { get; set; }

        internal void Save()
        {
            var properties = Settings1.Default.PropertyValues;
            this.setValue("access_token", this.Access_token);
        }

        private string getValue(string param_name, string def_value) {

            var properties = Settings1.Default.PropertyValues;
            
            //var properties = Settings1.Default.PropertyValues;
            //object result = def_value;
            string param_path = Path.Combine(this.path, param_name);
            //var prop_dict = properties.Cast<SettingsPropertyValue>().ToDictionary(s=>s.Property.Name);
            //try
            //{
            //    if (prop_dict.ContainsKey(param_path))
            //    {
            //        result = prop_dict[param_path].PropertyValue;
            //    }
            //}
            //catch (Exception e) {
            //    Debugger.Log(0, "Config error", e.ToString());
            //}

            
            
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[param_path] ?? def_value;
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }

            return def_value;
        }

        private void setValue(string name, string value) {
            //var properties = Settings1.Default.PropertyValues;
            var path_name = Path.Combine(this.path,name);
            //var prop = new SettingsProperty(path_name);
           
            //var val = new SettingsPropertyValue(prop);
            //val.PropertyValue = value;

            //properties.Add(val);

            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                var settings = configFile.AppSettings.Settings;
                if (settings[path_name] == null)
                {
                    settings.Add(path_name, value);
                }
                else
                {
                    settings[path_name].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
