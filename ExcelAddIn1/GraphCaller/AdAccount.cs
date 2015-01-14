using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCaller
{
    public class AdAccount
    {

        public static AdAccount getAdAccount(string access_token,int account_id) {
            AdAccount result = new AdAccount();

            var fb = new Facebook.FacebookClient(access_token);
            var obj = fb.Get("act_" + account_id.ToString());
            return result;

        }
    }
}
