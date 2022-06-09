using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Aflamy.Models
{
    public class CategoryService : ICategoryService
    {
        public CategoryService(AppDBContext appDBContext)
        {
            AppDBContext = appDBContext;
        }

        public AppDBContext AppDBContext { get; }

        public void Add(Category category)
        {
            if (category != null)
            {
                AppDBContext.Categories.Add(category);
                AppDBContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var DeletedCategory = AppDBContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (DeletedCategory != null)
            {
                AppDBContext.Categories.Remove(DeletedCategory);
                AppDBContext.SaveChanges();
            }
        }

        public Category Get(int id)
        {
            return AppDBContext.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return AppDBContext.Categories.Include(c => c.Movies).OrderBy(c => c.CategoryName).ToList();
        }

        public List<Category> GetCategoriesListByID(List<int> IDs)
        {
            List<Category> categories = new List<Category>();
            foreach (var categoryID in IDs)
            {
                categories.Add(Get(categoryID));
            }
            return categories;
        }

        public void Update(Category category)
        {
            var entry = AppDBContext.Entry(category);
            entry.State = EntityState.Modified;
            AppDBContext.SaveChanges();
        }
    }
}
