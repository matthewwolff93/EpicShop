using EpicShop.Core.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace EpicShop.Core.Modules.Category.Models
{
    [ModelMetadataType(typeof(CategoryModel))]
    public class CategoryViewModel : BaseViewModel
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}