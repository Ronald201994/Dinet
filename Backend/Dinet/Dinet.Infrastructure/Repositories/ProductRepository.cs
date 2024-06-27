using Dinet.Application.Contracts.Persistence;
using Dinet.Domain;
using Dinet.Infrastructure.Persistence;

namespace Dinet.Infrastructure.Repositories
{
    public class ProductRepository: BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DinetContext context): base(context) 
        { 
        }
    }
}
