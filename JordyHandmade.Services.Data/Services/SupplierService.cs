namespace JordyHandmade.Services.Data.Services
{
	using Microsoft.EntityFrameworkCore;
	using System.Threading.Tasks;

	using JordyHandmade.Data;
	using JordyHandmade.Data.Models;
	using JordyHandmade.Services.Data.Interfaces;
	using JordyHandmade.Web.ViewModels.Supplier;
	using System.Collections.Generic;
	using JordyHandmade.Web.ViewModels.Product;
	using System.Collections;

	public class SupplierService : ISupplierService
	{
		private readonly JordyHandmadeDbContext dbContext;

		public SupplierService(JordyHandmadeDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		
		public async Task AddSupplierAsync(SupplierFormModel formModel)
		{
			bool townExists = await this.dbContext
				.Towns.AnyAsync(t => t.ZipCode == formModel.ZipCode);

			if (!townExists)
			{
				 Town town = new Town()
				{
					TownName = formModel.TownName,
					ZipCode = formModel.ZipCode
				};

				await dbContext.Towns.AddAsync(town);
				await dbContext.SaveChangesAsync();
			}

			var supplierTown = await this.dbContext
				.Towns
				.Where(t => t.ZipCode == formModel.ZipCode)
				.FirstAsync();

			Supplier newSupplier = new Supplier()
			{
				SupplierName = formModel.SupplierName,
				Website = formModel.Website,
				Email = formModel.Email,
				PhoneNumber = formModel.PhoneNumber,
				IsActive = formModel.IsActive,
				Address = new Address()
				{
					StreetAddress = formModel.StreetAddress,
					TownId = supplierTown.Id
				}
			};

			await this.dbContext.AddAsync(newSupplier);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<SupplierAllViewModel>> GetAllSuppliersAsync()
		{
			IEnumerable<SupplierAllViewModel> allSuppliers = await this.dbContext
				.Suppliers
				.Where(s => s.IsActive)
				.Select(s => new SupplierAllViewModel() 
				{
					Id = s.Id.ToString(),
					SupplierName = s.SupplierName,
					Website = s.Website,
					Email = s.Email,
					PhoneNumber = s.PhoneNumber,
					TownName = s.Address.Town.TownName
				})
				.ToArrayAsync();
			
			return allSuppliers;
		}
	}
}
