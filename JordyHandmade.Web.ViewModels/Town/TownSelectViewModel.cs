namespace JordyHandmade.Web.ViewModels.Town
{
    public class TownSelectViewModel
    {
        public int Id { get; set; }

        public IEnumerable<TownFormModel>? Towns { get; set; }
    }
}
