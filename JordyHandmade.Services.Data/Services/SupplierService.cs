namespace JordyHandmade.Services.Data.Services
{
	using JordyHandmade.Data;
	using JordyHandmade.Services.Data.Interfaces;

	using JordyHandmade.Web.ViewModels.Supplier;
	using System.Threading.Tasks;

	public class SupplierService : ISupplierService
	{
		private readonly JordyHandmadeDbContext dbContext;

		public SupplierService(JordyHandmadeDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		
		public Task AddSupplierAsync(SupplierFormModel formModel)
		{
			throw new NotImplementedException();
		}
	}
}
