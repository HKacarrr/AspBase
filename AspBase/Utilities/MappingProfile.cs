using AutoMapper;
using Entities.DTO.Product;
using Entities.Product;

namespace AspBase.Utilities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
    }
}