using EpicShop.Core.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace EpicShop.Core.Modules.Shop.Models
{
    [ModelMetadataType(typeof(ShopModel))]
    public class ShopViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
    }
}