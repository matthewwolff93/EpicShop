using AutoMapper;

namespace EpicShop.Core.Modules.Shop.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShopModel, ShopInputViewModel>().ReverseMap();
        }
    }
}
