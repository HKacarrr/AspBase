using Entities.DTO.Auth.Profile;
using Entities.DTO.Auth.User;
using Entities.DTO.Category;
using Entities.DTO.Product;
using Entities.Models.Auth;
using Entities.Models.Category;
using Entities.Models.Product;
using AutoMapperProfile = AutoMapper.Profile;

namespace AspBase.Utilities;

public class MappingProfile : AutoMapperProfile
{
    public MappingProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<CreateProductDto, Product>().ReverseMap();
        
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<CreateCategoryDto, Category>().ReverseMap();
        
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<UserRegistrationDto, User>().ReverseMap();
        
        CreateMap<ProfileDto, Profile>().ReverseMap();
        CreateMap<ProfileRegistrationDto, Profile>().ReverseMap();
    }
}