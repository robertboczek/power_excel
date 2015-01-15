using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCaller
{
    public class AdGroups
    {
        private static HashSet<string> defaultFields = new HashSet<string>() { "id", "name", "account_id" };

        public long AdgroupAccontID { get; set; }

        public string AdgroupId { get; set; }

        public string AdgroupName { get; set; }

        public static List<AdGroups> getAdGroup(string access_token, long account_id, HashSet<string> fields = null)
        {
            fields = (fields != null) ? fields : AdGroups.defaultFields;
            List<AdGroups> results = new List<AdGroups>();

            var fb = new Facebook.FacebookClient(access_token);

            //var obj = fb.Get("act_" + account_id.ToString(), new object[0], typeof(AdAccount));
            var param = new Dictionary<string, string>();
            param["fields"] = String.Join(",", fields.ToArray());

            dynamic obj2 = fb.Get("act_" + account_id.ToString() + "/adgroups", new { fields = param["fields"] });

            var data = obj2["data"];
            foreach (var adgroup in data) {
              AdGroups result = new AdGroups();
              result.AdgroupId = adgroup["id"];
              result.AdgroupName = adgroup["name"];
              result.AdgroupAccontID = long.Parse(adgroup["account_id"]);

              results.Add(result);
            }

            return results;
        }
    }
}
