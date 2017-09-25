using EpicShop.Core.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace EpicShop.Core.Modules.Product.Models
{
    [ModelMetadataType(typeof(ProductModel))]
    public class ProductViewModel : BaseViewModel
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}