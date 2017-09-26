using AutoMapper;

namespace EpicShop.Core.Modules.Category.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryModel, CategoryInputViewModel>().ReverseMap();
        }
    }
}
