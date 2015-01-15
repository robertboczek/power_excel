using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GraphCaller
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        string Uppercase(string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        private void ParseFromDynamic<T>(string field, dynamic obj2, T result)
        {
            //split abc_def into {abc,def} and then convert to {Abc,Def}
            var nameParts = field.Split(new char[] { '_' }).Select(Uppercase);
            var variableName = string.Join("", nameParts);
            var property = result.GetType().GetProperty(
                variableName,
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (null != property && property.CanWrite)
            {
                try
                {
                    if (property.PropertyType.Equals(typeof(Int32)))
                    {
                        var value = Int32.Parse(obj2[field].ToString());
                        property.SetValue(result, value);
                    }
                    else if (property.PropertyType.Equals(typeof(Int64)))
                    {
                        var value = Int64.Parse(obj2[field].ToString());
                        property.SetValue(result, value);
                    }
                    else if (property.PropertyType.Equals(typeof(float)))
                    {
                        var value = float.Parse(obj2[field].ToString());
                        property.SetValue(result, value);
                    }
                    else if (property.PropertyType.Equals(typeof(string)))
                    {
                        var value = obj2[field].ToString();
                        property.SetValue(result, value);
                    }
                    else if (property.PropertyType.Equals(typeof(DateTime)))
                    {
                        var value = DateTime.Parse(obj2[field].ToString());
                        property.SetValue(result, value);
                    }
                    else if (property.PropertyType.Equals(typeof(List<string>)))
                    {
                        var values = (Facebook.JsonArray)obj2[field];
                        var list = new List<string>();
                        foreach (var value in values)
                        {
                            list.Add((string)value);
                        }
                        property.SetValue(result, values);
                    }
                }
                catch (Exception)
                { }
            }
        }

        public FBAdAccount GetAdAccount(string access_token, Int64 account_id)
        {
            HashSet<string> fields = new HashSet<string>() { 
                "account_groups", "account_id", "account_status", "age", "agency_client_declaration", "amount_spent", 
                "balance", "business_city", "business_country_code", "business_name", "business_state", "business_street",
                "business_street2", "business_zip", "capabilities", "created_time", "currency", "daily_spend_limit", "end_advertiser",
                "funding_source", "funding_source_details", "id", "is_personal", "media_agency", "name", "offsite_pixels_tos_accepted",
                "partner", "spend_cap", "daily_spend_limit", "timezone_id", "timezone_name", "timezone_offset_hours_utc", "tos_accepted",
                "users", "tax_id_status"
            };

            FBAdAccount result = new FBAdAccount();
            var fb = new Facebook.FacebookClient(access_token);

            var param = new Dictionary<string, string>();
            param["fields"] = String.Join(",", fields.ToArray());

            dynamic obj2 = fb.Get("act_" + account_id.ToString(), new { fields = param["fields"] });

            foreach (string field in fields)
            {
                if (field == "agency_client_declaration")
                {
                    var acd = new FBAgencyClientDeclaration();
                    var properties = acd.GetType().GetProperties(
                        System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    foreach (var property in properties)
                    {
                        var r = new System.Text.RegularExpressions.Regex(@"
                            (?<=[A-Z])(?=[A-Z][a-z]) |
                            (?<=[^A-Z])(?=[A-Z]) |
                            (?<=[A-Za-z])(?=[^A-Za-z])",
                            System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace);
                        string fieldFromProperty = r.Replace(property.Name, "_").ToLower();
                        try
                        {
                            ParseFromDynamic<FBAgencyClientDeclaration>(
                                fieldFromProperty,
                                obj2[field],
                                acd);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                else if (field == "user")
                {
                    var user = new List<FBUser>();
                }
                else if (field == "account_group")
                {
                    var accountGroups = new List<FBAccountGroup>();
                }
                else
                {
                    ParseFromDynamic<FBAdAccount>(field, obj2, result);
                }
            }

            return result;
        }
    }
}
