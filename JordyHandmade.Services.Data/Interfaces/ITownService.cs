namespace JordyHandmade.Services.Data.Interfaces
{
    using JordyHandmade.Web.ViewModels.Town;

    public interface ITownService
    {
		Task<IEnumerable<TownFormModel>> GetAllForSelectAsync();        
        
        Task<bool> TownExistsByZipAsync(string zipCode);

        Task<TownFormModel> GetTownByIdAsync(int id);

		Task AddTownAsync(TownFormModel inputModel);

        Task UpdateAsync(int id, TownFormModel editModel);

        Task DeleteAsync(int id);

    }
}
