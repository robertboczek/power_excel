using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCaller
{
    public class AdGroups
    {
        public static readonly HashSet<string> defaultFields = new HashSet<string>() { "id", "name", "account_id" };

        public static readonly HashSet<string> knownFields = new HashSet<string>() { "id", "name", "account_id", "adgroup_status" };

        public long AdgroupAccontID { get; set; }

        public string AdgroupId { get; set; }

        public string AdgroupName { get; set; }

        public string Status { get; set; }

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
            var populator = new Dictionary<string, Action<AdGroups, dynamic>>(){
                {"id" , ( a,v) => a.AdgroupId = v["id"] },
                {"name" , ( a,v) => a.AdgroupName = v["name"] },
                {"account_id" , ( a,v) => a.AdgroupAccontID =  long.Parse(v["account_id"]) },
                {"adgroup_status" , ( a,v) => a.Status =  v["adgroup_status"] },
            };
            

            foreach (var adgroup in data) {

              AdGroups result = new AdGroups();
              foreach(var field in fields) {
                  populator[field](result, adgroup);
              }
              results.Add(result);
            }

            return results;
        }
    }
}
