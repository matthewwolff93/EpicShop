using System;

namespace EpicShop.Core.Infrastructure.Data
{
    public interface IHasOutputValues
    {
        int Id { get; set; }
        DateTime CreatedDateTime { get; set; }
        DateTime UpdatedDateTime { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}