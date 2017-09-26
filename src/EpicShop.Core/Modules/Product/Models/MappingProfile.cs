using AutoMapper;

namespace EpicShop.Core.Modules.Product.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, ProductInputViewModel>().ReverseMap();
            CreateMap<ProductModel, ProductOutputViewModel>().ReverseMap();
        }
    }
}
