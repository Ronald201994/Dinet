using Dinet.Domain;

namespace Dinet.Application.Contracts.Persistence
{
    public interface IBaseRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        void AddEntity(T entity);
    }
}
