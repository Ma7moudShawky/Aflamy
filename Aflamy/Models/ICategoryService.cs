using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aflamy.Models
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        List<Category> GetCategoriesListByID(List<int> IDs);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);

    }
}
