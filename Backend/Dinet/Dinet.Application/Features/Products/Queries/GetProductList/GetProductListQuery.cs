using Dinet.Application.Dtos;
using MediatR;

namespace Dinet.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQuery: IRequest<List<ProductDto>>
    {

    }
}
