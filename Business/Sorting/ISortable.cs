using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sorting
{
    public interface ISortable<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Sort(IQueryable<TEntity> list);
    }
}
