using AutoMapper;
using Entities.DTO.Category;
using Entities.DTO.Product;
using Entities.Models.Category;
using Entities.Models.Product;

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