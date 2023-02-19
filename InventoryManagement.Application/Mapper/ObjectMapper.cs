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
                cfg.AddProfile<ModelsMapperProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class ModelsMapperProfile : Profile
    {
        public ModelsMapperProfile()
        {
            CreateMap<Product, ProductModel>()
                .ReverseMap();

            CreateMap<Inventory, InventoryModel>()
                .ReverseMap();

            CreateMap<Company, CompanyModel>()
                .ReverseMap();
        }
    }
}
