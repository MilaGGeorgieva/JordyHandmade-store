namespace JordyHandmade.Services.Data.Interfaces
{
	using JordyHandmade.Web.ViewModels.Supplier;
	using System.Threading.Tasks;

	public interface ISupplierService
	{
		Task AddSupplierAsync(SupplierFormModel formModel);
	}
}
