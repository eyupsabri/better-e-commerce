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
    public interface IPaging<T> where T : class
    {
        IList<T> dtos { get; }
        int PageIndex { get;  }
        int PageCount { get;  }
        
    }
}
