using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repos
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _db;


        public CategoriesRepository(AppDbContext appDbContext)
        {
            _db = appDbContext;

        }

        public async Task<bool> AddCategory(Category cat)
        {
            _db.Categories.Add(cat);
            int i = await _db.SaveChangesAsync();

            return i > 0;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            Category? cat = _db.Categories.Where(temp => temp.CategoryId == id).FirstOrDefault();
            cat.IsDeleted = true;
            int rowsDeleted = await _db.SaveChangesAsync();

            return rowsDeleted > 0;
        }


        public async Task<List<Category>> GetAllCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        //public async Task<Category?> GetCategoryById(int id)
        //{
        //    return await _db.Categories.FirstOrDefaultAsync(temp => temp.CategoryId == id);
        //}

        //public async Task<Category> UpdateCategory(Category cat)
        //{
        //    Category? matchingCategory = await _db.Categories.FirstOrDefaultAsync(temp => temp.CategoryId == cat.CategoryId);

        //    if (matchingCategory == null)
        //        return cat;

        //    matchingCategory.CategoryName = cat.CategoryName;
          

        //    int countUpdated = await _db.SaveChangesAsync();

        //    return matchingCategory;
        //}
    }
}