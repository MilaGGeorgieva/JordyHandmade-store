using JordyHandmade.Web.ViewModels.Home;
using JordyHandmade.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordyHandmade.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeProductsAsync();

        Task<IEnumerable<AllViewModel>> GetAllAsync();

        Task<DetailsViewModel> GetDetailsAsync(string id);

        Task<bool> ExistsByIdAsync(string id);

        Task<int> GetQuantityInStockByIdAsync(string id);

        Task AddProductAsync(ProductFormModel formModel);

        Task<ProductFormModel> GetProductToEditAsync(string id);

        Task UpdateAsync(string id, ProductFormModel editModel);

        Task<AllViewModel> GetProductToDeleteAsync(string id);

        Task DeleteAsync(string id);
    }
}
