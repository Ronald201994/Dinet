using Dinet.Application.Contracts.Persistence;
using Dinet.Domain;
using Dinet.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dinet.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseDomainModel
    {
        protected readonly DinetContext _context;
        public BaseRepository(DinetContext context)
        {
            _context = context;        
        }
        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
