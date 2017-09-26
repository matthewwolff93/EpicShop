using AutoMapper;

namespace EpicShop.Core.Modules.Shop.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShopModel, ShopOutputViewModel>().ReverseMap();
            CreateMap<ShopModel, ShopInputViewModel>().ReverseMap();
        }
    }
}
