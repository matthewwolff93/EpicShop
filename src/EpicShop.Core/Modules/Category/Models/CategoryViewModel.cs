using EpicShop.Core.Infrastructure.Data;

namespace EpicShop.Core.Modules.Category.Models
{
    public class CategoryViewModel : BaseViewModel
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}