namespace JordyHandmade.Services.Data.Interfaces
{
    using JordyHandmade.Web.ViewModels.Category;
    using JordyHandmade.Web.ViewModels.Town;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryAllViewModel>> GetAllCategoriesAsync();

        Task AddCategoryAsync(CategoryFormModel inputModel);

        Task<bool> ExistsByIdAsync(int id);

        Task<CategoryFormModel> GetCategoryByIdAsync(int id);

        Task UpdateCategoryAsync(int id, CategoryFormModel editModel);

        Task DeleteCategoryAsync(int id);

        Task<IEnumerable<CategorySelectViewModel>> GetAllCategoriesForSelectAsync();

        
    }
}
