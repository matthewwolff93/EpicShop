using System.ComponentModel.DataAnnotations;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Modules.Product.Models;

namespace EpicShop.Core.Modules.Category.Models
{
    public class CategoryModel : BaseModel
    {
        [Required]
        public int ShopId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}