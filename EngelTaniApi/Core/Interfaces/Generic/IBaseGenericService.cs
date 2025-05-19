using EngelTaniApi.Application.Dtos;
using EngelTaniApi.Core.Common;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IBaseGenericService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        // Temel CRUD
        Task<DataResult<List<TDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<DataResult<TDto?>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<DataResult<int>> CreateAsync(TDto dto, CancellationToken cancellationToken = default);
        Task<DataResult<bool>> CreateRangeAsync(List<TDto> dtos, CancellationToken cancellationToken = default);
        Task<DataResult<bool>> UpdateAsync(int id, TDto dto, CancellationToken cancellationToken = default);
        Task<DataResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default);

        // Ekstra işlemler
        Task<DataResult<int>> AddRangeAsync(List<TDto> dtos, CancellationToken cancellationToken = default);
        Task<DataResult<bool>> DeleteByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default);
        Task<bool> IsExistByIdAsync(int id, CancellationToken cancellationToken = default);

        // Query & Filtering
        IQueryable<TEntity> AsQueryable();
        Task<DataResult<List<TDto>>> GetFilteredAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        // Pagination
        Task<DataResult<PaginatedResult<TDto>>> GetPaginatedAsync(PaginationRequest request, CancellationToken cancellationToken = default);
    }
}
