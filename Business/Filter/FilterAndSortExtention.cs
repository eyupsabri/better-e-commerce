using Business.PageList;
using Business.Sorting;
using Business.United;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Filter
{
    public static class FilterAndSortExtention
    {
        public static IQueryable<T> FilterAndSort<T>(this IQueryable<T> list, IFilterAndSort<T> filter)
            where T : class
        {
            var filtered = filter.Filter(list);
            var sorted = filter.Sort(filtered);
            return sorted;

        }
    }
}
