namespace JordyHandmade.Services.Data.Interfaces
{
    using JordyHandmade.Web.ViewModels.Town;

    public interface ITownService
    {
		Task<bool> TownExistsByZipAsync(string zipCode);

        Task<TownFormModel> GetTownByIdAsync(int id);

		Task AddTownAsync(TownFormModel inputModel);

        Task DeleteAsync(int id);

    }
}
