using AutoMapper;
using InventoryManagement.Api.Dtos;
using InventoryManagement.Application.Models;

namespace InventoryManagement.Api.Mapping
{
    public class DtosMappingProfile : Profile
    {
        public DtosMappingProfile()
        {
            CreateMap<CreateProductDto, ProductModel>().ReverseMap();
            CreateMap<ProductDto, ProductModel>().ReverseMap();
        }
    }
}
