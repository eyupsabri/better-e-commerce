using Business.DTOs;
using Business.PageList;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.APIPaging
{
    public class Paging<T>: IPaging<T> where T : class
    {
        public int PageIndex { get ;  }
        public int PageCount { get; }

        public IList<T> dtos { get; }

        
        public Paging(IPagedList<T> list)
        {
            dtos = new List<T>();
            foreach (var item in list)
            {
                dtos.Add(item);
            }
            PageIndex = list.PageIndex;
            PageCount = list.PageCount;
        }


    }
}
