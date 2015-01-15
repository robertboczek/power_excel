using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCaller
{
    public class AdGroup
    {
        private static HashSet<string> defaultFields = new HashSet<string>() { "id", "name", "account_id" };

        public long AccontID { get; set; }

        public string Id { get; set; }

        public long Name { get; set; }

        public static AdGroup getAdGroup(string access_token, long account_id, HashSet<string> fields = null)
        {
            fields = (fields != null) ? fields : AdGroup.defaultFields;
            AdGroup result = new AdGroup();

            var fb = new Facebook.FacebookClient(access_token);

            //var obj = fb.Get("act_" + account_id.ToString(), new object[0], typeof(AdAccount));
            var param = new Dictionary<string, string>();
            param["fields"] = String.Join(",", fields.ToArray());

            dynamic obj2 = fb.Get("act_" + account_id.ToString() + "/adgroups", new { fields = param["fields"] });
            result.Id = obj2["id"];
            result.AccontID = long.Parse(obj2["account_id"]);
           // result.DailySpend = obj2["daily_spend_limit"];
            return result;

        }
    }
}
