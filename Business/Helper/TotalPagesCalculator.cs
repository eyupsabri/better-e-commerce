using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper
{
    public static class TotalPagesCalculator
    {
        public static int CalculatingTotalPages(int itemsCount)
        {
            int remainder = itemsCount % 12;
            int quotient = itemsCount / 12;
            int totalPages = remainder > 0 ? quotient + 1 : quotient;
            return totalPages;
        }
    }
}
