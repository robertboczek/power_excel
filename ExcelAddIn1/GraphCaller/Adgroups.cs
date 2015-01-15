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

        public static AdGroups getAdGroup(string access_token, long account_id, HashSet<string> fields = null)
        {
            fields = (fields != null) ? fields : AdGroups.defaultFields;
            AdGroups result = new AdGroups();

            var fb = new Facebook.FacebookClient(access_token);

            //var obj = fb.Get("act_" + account_id.ToString(), new object[0], typeof(AdAccount));
            var param = new Dictionary<string, string>();
            param["fields"] = String.Join(",", fields.ToArray());

            dynamic obj2 = fb.Get("act_" + account_id.ToString() + "/adgroups", new { fields = param["fields"] });

            var data = obj2["data"];
            result.AdgroupId = data[0]["id"];
            var x = data[0]["name"];
            result.AdgroupName = data[0]["name"];
            result.AccontID = long.Parse(obj2["account_id"]);

            return result;

        }
    }
}
