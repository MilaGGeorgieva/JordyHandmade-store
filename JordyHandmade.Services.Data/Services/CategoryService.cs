namespace JordyHandmade.Services.Data.Services
{
    using Microsoft.EntityFrameworkCore;

    using JordyHandmade.Data;
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Category;
    

    public class CategoryService : ICategoryService
    {
        private readonly JordyHandmadeDbContext dbContext;

        public CategoryService(JordyHandmadeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Categories
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<IEnumerable<CategorySelectViewModel>> GetAllCategoriesAsync()
        {
            IEnumerable<CategorySelectViewModel> allCategories = await this.dbContext
                .Categories
                .Select(c => new CategorySelectViewModel() 
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                })
                .ToArrayAsync();

            return allCategories;
        }
    }
}
