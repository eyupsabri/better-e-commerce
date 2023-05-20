using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public interface ICategoriesRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> AddCategory(Category cat);
        Task<Category> UpdateCategory(Category cat);
        Task<bool> DeleteCategory(int id);
        
    }
}
