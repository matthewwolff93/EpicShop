using EpicShop.Core.Infrastructure.Data;

namespace EpicShop.Core.Modules.Shop.Models
{
    public class ShopModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
    }
}
