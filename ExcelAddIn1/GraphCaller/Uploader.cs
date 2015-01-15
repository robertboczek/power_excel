using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCaller
{
    public static class Uploader
    {
        public static void Edit(string resource_id, string access_token, Dictionary<string, object> update_spec)
        {
            var fb = new Facebook.FacebookClient(access_token);

            var result = fb.Post(resource_id, update_spec);

            if (null == result)
            {
                throw new Exception("Failed adgroup edit");
            }
        }
    }
}
