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
    public class PagedList<T> : List<T>, IPagedList<T> where T : class
    {
        public PagedList()
        {
            
        }
        public PagedList(IEnumerable<T> source, int index, int pageSize, int? totalCount = null)
            : this(source.AsQueryable(), index, pageSize, totalCount)
        {
            
        }

        public PagedList(IQueryable<T> source, int index, int pageSize, int? totalCount = null)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index", "Value can not be below 0.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", "Value can not be less than 1.");

            if (source == null)
                source = new List<T>().AsQueryable();

            int realTotalCount = 0;

            if (!totalCount.HasValue)
                realTotalCount = source.Count();

            PageSize = pageSize;
            PageIndex = index;
            TotalItemCount = totalCount.HasValue ? totalCount.Value : realTotalCount;
            PageCount = TotalItemCount > 0 ? (int)Math.Ceiling(TotalItemCount / (double)PageSize) : 0;

            HasPreviousPage = (PageIndex > 0);
            HasNextPage = (PageIndex < (PageCount - 1));
            IsFirstPage = (PageIndex <= 0);
            IsLastPage = (PageIndex >= (PageCount - 1));


            
            

            if (TotalItemCount <= 0)
                return;

            var realTotalPages = (int)Math.Ceiling(realTotalCount / (double)PageSize);

            if (realTotalPages <= PageIndex) //Degistirdim
            {
                AddRange(source.Skip((realTotalPages - 1) * PageSize).Take(PageSize));
                PageIndex--;
            }
                
            else
                AddRange(source.Skip(PageIndex * PageSize).Take(PageSize));
        }

        #region IPagedList Members
        public string? Url { get; set; }
        public int PageCount { get; private set; }
        public int TotalItemCount { get; private set; }
        public int PageIndex { get; private set; }
        public int PageNumber { get { return PageIndex + 1; } }
        public int PageSize { get; private set; }
        public bool HasPreviousPage { get; private set; }
        public bool HasNextPage { get; private set; }
        public bool IsFirstPage { get; private set; }
        public bool IsLastPage { get; private set; }
        public string OrderCol { get; set; }
        public bool OrderAsc { get; set; }
        public object filterValues { get; set; }
        public ISortable<T> sortModel { get; set; }

        #endregion
        public void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            //// ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
            filterValues = expandoDict;
        }

   
    }
}
