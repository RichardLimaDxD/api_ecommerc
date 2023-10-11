using AutoMapper;
using API.Helper;
using Ecom.Core.Dtos;
using Ecom.Core.Entities;

namespace API.MappingProfiles {
    public class MappingProduct : Profile {
        public MappingProduct() {
            CreateMap<Product, ProductDto>()
                 .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name))
                 .ForMember(d => d.ProductPicture, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
