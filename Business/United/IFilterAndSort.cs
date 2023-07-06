using Business.Filter;
using Business.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.United
{
    public interface IFilterAndSort<T> : IFilterable<T>, ISortable<T> where T : class
    {

    }
}
