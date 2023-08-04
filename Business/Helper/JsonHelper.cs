using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper
{
    public static class JsonHelper
    {

        public static string JsonToQuery(this string jsonQuery)
        {
            string str = "&";
            str += jsonQuery.Replace(":", "=").Replace("{", "").
                        Replace("}", "").Replace(",", "&").
                            Replace("\"", "");
            return str;
        }
    }
}
