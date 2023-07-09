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
    }
}
