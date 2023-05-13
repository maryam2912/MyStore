using Store.Model;
using Store.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.Services
{
    public class CategoryService : ICategoryService
    {
        private List<Category> categories = new List<Category>();

        public void AddCategory(Category category)
        {
            categories.Add(category);
        }

        public void EditCategory(Category category)
        {
            Category existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
            }
        }

        public void DeleteCategory(int categoryId)
        {
            Category category = categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                categories.Remove(category);
            }
        }
        public Category GetCategoryById(int categoryId)
        {
            return categories.FirstOrDefault(c => c.Id == categoryId);
        }

        public List<Category> GetAllCategories()
        {
            return categories;
        }
    }
}