using System.ComponentModel.DataAnnotations;
using EpicShop.Core.Infrastructure.Data;

namespace EpicShop.Core.Modules.Category.Models
{
    public class CategoryInputViewModel : BaseViewModel
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