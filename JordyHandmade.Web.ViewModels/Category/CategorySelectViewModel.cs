using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordyHandmade.Web.ViewModels.Category
{
    public class CategorySelectViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
