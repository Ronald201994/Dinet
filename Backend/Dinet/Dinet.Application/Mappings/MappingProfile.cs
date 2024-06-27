using AutoMapper;
using Dinet.Application.Dtos;
using Dinet.Application.Features.Products.Commands.CreateProduct;
using Dinet.Domain;

namespace Dinet.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
