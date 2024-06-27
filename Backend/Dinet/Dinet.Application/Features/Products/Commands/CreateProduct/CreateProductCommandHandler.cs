using AutoMapper;
using Dinet.Application.Contracts.Persistence;
using Dinet.Domain;
using MediatR;

namespace Dinet.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            _unitOfWork.Repository<Product>().AddEntity(product);

            var result = await _unitOfWork.Complete();

            return product.Id;
        }
    }
}
