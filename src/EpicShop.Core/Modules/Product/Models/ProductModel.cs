﻿using System.ComponentModel.DataAnnotations;
using EpicShop.Core.Infrastructure.Data;

namespace EpicShop.Core.Modules.Product.Models
{
    public class ProductModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
