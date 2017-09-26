using System;
using EpicShop.Core.Infrastructure.Data;

namespace EpicShop.Core.Modules.Category.Models
{
    public class CategoryOutputViewModel : CategoryInputViewModel, IHasOutputValues
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}