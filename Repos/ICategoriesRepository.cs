using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public interface ICategoriesRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<bool> AddCategory(Category cat);
        Task<Category> UpdateCategory(Category cat);
        Task<bool> DeleteCategory(int id);
        
    }
}
