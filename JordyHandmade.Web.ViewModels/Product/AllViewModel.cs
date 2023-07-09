using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordyHandmade.Web.ViewModels.Product
{
    public class AllViewModel
    {
        public string Id { get; set; } = null!;
                
        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
