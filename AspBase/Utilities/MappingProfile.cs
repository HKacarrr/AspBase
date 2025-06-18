using AutoMapper;
using Entities.Category;
using Entities.DTO.Category;
using Entities.DTO.Product;
using Entities.Product;

namespace AspBase.Utilities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<CreateProductDto, Product>().ReverseMap();
        
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<CreateCategoryDto, Category>().ReverseMap();
    }
}