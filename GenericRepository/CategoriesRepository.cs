using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace GenericRepository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _db;


        public CategoriesRepository(AppDbContext appDbContext)
        {
            _db = appDbContext;

        }

        public async Task<Category> AddCategory(Category cat)
        {
            _db.Categories.Add(cat);
            await _db.SaveChangesAsync();

            return cat;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            _db.Categories.RemoveRange(_db.Categories.Where(temp => temp.CategoryId == id));
            int rowsDeleted = await _db.SaveChangesAsync();

            return rowsDeleted > 0;
        }


        public async Task<List<Category>> GetAllCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _db.Categories.FirstOrDefaultAsync(temp => temp.CategoryId == id);
        }

        public async Task<Category> UpdateCategory(Category cat)
        {
            Category? matchingCategory = await _db.Categories.FirstOrDefaultAsync(temp => temp.CategoryId == cat.CategoryId);

            if (matchingCategory == null)
                return cat;

            matchingCategory.CategoryName = cat.CategoryName;
          

            int countUpdated = await _db.SaveChangesAsync();

            return matchingCategory;
        }
    }
}