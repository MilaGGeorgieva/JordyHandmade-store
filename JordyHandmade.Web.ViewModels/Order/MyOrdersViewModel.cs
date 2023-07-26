namespace JordyHandmade.Web.ViewModels.Order
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MyOrdersViewModel
    {
        public string Id { get; set; } = null!;

        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public string StartDate { get; set; } = null!;

        public string Status { get; set; } = null!;
               
        public int? Discount { get; set; }
                
        public decimal TotalAmount { get; set; }        
    }
}
