using System;
using System.Collections.Generic;
using System.Linq;
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
        object filterValues { get; set; }
    }
    public interface IPagedList<T>: IPagedList, IList<T> where T : class
    {
        //ISortable<T> sortModel { get; set; }
    }
}
