using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCaller
{
    public class AdAccount
    {
        public long AccontID { get; set; }

        public string  Id{ get; set; }


        public static AdAccount getAdAccount(string access_token,long account_id) {
            AdAccount result = new AdAccount();

            var fb = new Facebook.FacebookClient(access_token);

            //var obj = fb.Get("act_" + account_id.ToString(), new object[0], typeof(AdAccount));
            dynamic obj2 = fb.Get("act_" + account_id.ToString());
            result.Id = obj2["id"];
            result.AccontID = long.Parse(obj2["account_id"]);
            return result;

        }
    }
}
