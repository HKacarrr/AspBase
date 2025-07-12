using Entities.DTO.Auth;
using Entities.DTO.Category;
using Entities.DTO.Product;
using Entities.Models.Auth;
using Entities.Models.Category;
using Entities.Models.Product;
using Profile = AutoMapper.Profile;

namespace AspBase.Utilities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<CreateProductDto, Product>().ReverseMap();
        
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<CreateCategoryDto, Category>().ReverseMap();
        
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<ProfileDto, Profile>().ReverseMap();
    }
}