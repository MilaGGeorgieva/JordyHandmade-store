using JordyHandmade.Web.ViewModels.Customer;
using JordyHandmade.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JordyHandmade.Common.EntityValidationConstants.Product;

namespace JordyHandmade.Web.ViewModels.Order
{
    public class OrderFormModel
    {
        public DetailsViewModel? ProductToBuy { get; set; }

        [Range(QuantityInStockMinValue, QuantityInStockMaxValue)]
        public int Quantity { get; set; }
    }
}
