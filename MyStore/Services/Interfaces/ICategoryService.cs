using Store.Model;
using System.Collections.Generic;

namespace Store.Services.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void EditCategory(Category updatedCategory);
        void DeleteCategory(int categoryId);
        Category GetCategoryById(int categoryId);
        List<Category> GetAllCategories();
    }
}