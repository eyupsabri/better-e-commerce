using Business.Sorting;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.PageList
{
    public interface IPagedList
    {
        public string? Url { get; set; }
        int PageCount { get; }
        int TotalItemCount { get; }
        int PageIndex { get; }
        int PageNumber { get; }
        int PageSize { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFirstPage { get; }
        bool IsLastPage { get; }
        public object filterValues { get; set; }

        
        void AddProperty(ExpandoObject expando, string propertyName, object propertyValue);
        
        
        
    }
    public interface IPagedList<T>: IPagedList, IList<T> where T : class
    {
        ISortable<T> sortModel { get; set; }
        
    }
}
