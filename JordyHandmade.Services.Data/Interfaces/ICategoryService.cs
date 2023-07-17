namespace JordyHandmade.Services.Data.Interfaces
{
    using JordyHandmade.Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<CategorySelectViewModel>> GetAllCategoriesAsync();
    }
}
