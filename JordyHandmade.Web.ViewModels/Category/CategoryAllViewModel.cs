namespace JordyHandmade.Web.ViewModels.Category
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoryAllViewModel : CategorySelectViewModel
    {
        public string Description { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
