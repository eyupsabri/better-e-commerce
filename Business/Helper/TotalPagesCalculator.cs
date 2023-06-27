using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper
{
    public static class TotalPagesCalculator
    {
        public static int CalculatingTotalPages(int itemsCount, int itemPerPage = 12)
        {
            int remainder = itemsCount % itemPerPage;
            int quotient = itemsCount / itemPerPage;
            int totalPages = remainder > 0 ? quotient + 1 : quotient;
            return totalPages;
        }


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
