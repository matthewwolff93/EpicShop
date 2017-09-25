using System.ComponentModel.DataAnnotations;
using EpicShop.Core.Infrastructure.Data;

namespace EpicShop.Core.Modules.Shop.Models
{
    public class ShopViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string OwnerName { get; set; }

        [Required]
        [MaxLength(200)]
        public string OwnerEmail { get; set; }
    }
}