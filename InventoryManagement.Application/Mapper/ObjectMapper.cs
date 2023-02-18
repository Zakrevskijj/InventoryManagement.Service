using AutoMapper;
using InventoryManagement.Application.Models;
using InventoryManagement.Core.Entities;

namespace InventoryManagement.Application.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapperProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<Product, ProductModel>()
                .ReverseMap();

            CreateMap<Inventory, InventoryModel>()
                .ReverseMap();
        }
    }
}
