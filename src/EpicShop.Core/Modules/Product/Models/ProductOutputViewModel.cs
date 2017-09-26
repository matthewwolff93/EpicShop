using System;
using EpicShop.Core.Infrastructure.Data;

namespace EpicShop.Core.Modules.Product.Models
{
    public class ProductOutputViewModel : ProductInputViewModel, IHasOutputValues
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}