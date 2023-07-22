using Business.DTOs;
using Entities;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoriesRepository CategoriesRepo;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            this.CategoriesRepo = categoriesRepository;
        }

        public async Task<List<CategoryResponse>> GetAllCategories()
        {
            List<Category> allCategories = await CategoriesRepo.GetAllCategories();
            List<CategoryResponse> categories = allCategories.Select(temp => temp.ToCategoryResponse()).ToList();
            return categories;
        }

        public async Task<bool> DeleteCategoryById(int id)
        {
            return await CategoriesRepo.DeleteCategory(id);
        }

        public async Task <bool> AddCategory(CategoryAddRequest cat)
        {
            return await CategoriesRepo.AddCategory(cat.ToCategory());
        }
    }
}
