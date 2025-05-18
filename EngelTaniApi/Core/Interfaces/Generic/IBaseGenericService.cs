using EngelTaniApi.Application.Dtos;
using EngelTaniApi.Core.Common;

namespace EngelTaniApi.Core.Interfaces.Generic
{
    public interface IBaseGenericService<TEntity, TDto>
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(TDto dto);
        Task<bool> UpdateAsync(int id, TDto dto);
        Task<bool> DeleteAsync(int id);
        IQueryable<TEntity> AsQueryable();
        Task<PaginatedResult<TDto>> GetPaginatedAsync(PaginationRequest request);
    }
}
