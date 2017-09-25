using EpicShop.Core.Infrastructure.Data;

namespace EpicShop.Core.Modules.Product.Models
{
    public class ProductViewModel : BaseViewModel
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}