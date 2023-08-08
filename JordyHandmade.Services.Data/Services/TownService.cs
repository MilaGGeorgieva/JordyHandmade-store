namespace JordyHandmade.Services.Data.Services
{
    using JordyHandmade.Data;
    using JordyHandmade.Data.Models;
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Category;
    using JordyHandmade.Web.ViewModels.Town;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class TownService : ITownService 
    {
        private readonly JordyHandmadeDbContext dbContext;

        public TownService(JordyHandmadeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TownFormModel>> GetAllForSelectAsync()
        {
            IEnumerable<TownFormModel> allTowns = await this.dbContext
                .Towns
                .Select(t => new TownFormModel() 
                {
                    Id = t.Id,
                    TownName = t.TownName,
                    ZipCode = t.ZipCode
                })
                .ToArrayAsync();              

            return allTowns;
        }

        public async Task AddTownAsync(TownFormModel inputModel)
        {
            Town town = new Town() 
            {
                TownName = inputModel.TownName,
                ZipCode = inputModel.ZipCode,
            };

            await dbContext.Towns.AddAsync(town);
            await dbContext.SaveChangesAsync();
        }

		public async Task DeleteAsync(int id)
		{
			Town townToDelete = await this.dbContext
				.Towns.FirstAsync(t => t.Id == id);

            dbContext.Towns.Remove(townToDelete);
            await dbContext.SaveChangesAsync();
		}		

		public async Task<bool> TownExistsByZipAsync(string zipCode)
        {
            bool result = await this.dbContext
                .Towns.AnyAsync(t => t.ZipCode == zipCode);

            return result;
        }

		public async Task<TownFormModel> GetTownByIdAsync(int id)
		{
			Town town = await this.dbContext
                .Towns.FirstAsync(t => t.Id == id);

            return new TownFormModel()
            {
                Id = town.Id,
                TownName = town.TownName,
                ZipCode = town.ZipCode,
            };
		}

        public async Task UpdateAsync(int id, TownFormModel editModel)
        {
            Town townToUpdate = await this.dbContext
                .Towns.FirstAsync(t => t.Id == id);

            townToUpdate.TownName = editModel.TownName;
            townToUpdate.ZipCode = editModel.ZipCode;

            await this.dbContext.SaveChangesAsync();
        }
    }
    
}
