namespace JordyHandmade.Services.Data.Interfaces
{
    using JordyHandmade.Web.ViewModels.Town;

    public interface ITownService
    {
        Task AddTownAsync(TownFormModel inputModel);

        Task<bool> TownExistsByZipAsync(string zipCode); 
    }
}
