using AutoMapper;
using Dinet.Application.Contracts.Persistence;
using Dinet.Application.Dtos;
using MediatR;

namespace Dinet.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler: IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetProductListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var productList = await _unitOfWork.ProductRepository.GetAllAsync();

            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
