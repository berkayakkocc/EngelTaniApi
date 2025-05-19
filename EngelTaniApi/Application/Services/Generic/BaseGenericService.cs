using Core.Interfaces;
using EngelTaniApi.Application.Dtos;
using EngelTaniApi.Core.Common;
using EngelTaniApi.Core.Common.MessagesConstants;
using EngelTaniApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Services
{
    public abstract class BaseGenericService<TEntity, TDto> : IBaseGenericService<TEntity, TDto>
     where TEntity : BaseEntity, new()
     where TDto : BaseIdDto, new()
    {
        protected readonly EngelTaniDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseGenericService(EngelTaniDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<DataResult<List<TDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var list = await _dbSet
    .Where(e => !e.IsDeleted)
    .ToListAsync(cancellationToken);
            return DataResult<List<TDto>>.Success(
     list.Select(MapToDto).ToList(),
     SuccessMessages.Listed
 );
        }

        public async Task<DataResult<TDto?>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity == null)
                return DataResult<TDto?>.Fail(ErrorMessages.NotFound);

            return DataResult<TDto?>.Success(MapToDto(entity));
        }

        public async Task<DataResult<int>> CreateAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            var entity = MapToEntity(dto);
            _dbSet.Add(entity);
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);
            return DataResult<int>.Success(entity.Id, SuccessMessages.Created);
        }
        public async Task<DataResult<bool>> CreateRangeAsync(List<TDto> dtos, CancellationToken cancellationToken = default)
        {
            var entities = dtos.Select(MapToEntity).ToList();
            await _dbSet.AddRangeAsync(entities, cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return DataResult<bool>.Success(result > 0, string.Format(SuccessMessages.BatchCreated, result));
        }

        public async Task<DataResult<bool>> UpdateAsync(int id, TDto dto, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity == null)
                return DataResult<bool>.Fail(ErrorMessages.NotFound);

            UpdateEntity(entity, dto);
            await _context.SaveChangesAsync(cancellationToken);
            return DataResult<bool>.Success(true, SuccessMessages.Updated);
        }

        public async Task<DataResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity == null)
                return DataResult<bool>.Fail(ErrorMessages.NotFound);

            // Soft delete
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return DataResult<bool>.Success(true, SuccessMessages.Deleted);
        }

        public async Task<DataResult<int>> AddRangeAsync(List<TDto> dtos, CancellationToken cancellationToken = default)
        {
            var entities = dtos.Select(MapToEntity).ToList();
            await _dbSet.AddRangeAsync(entities, cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return DataResult<int>.Success(result, string.Format(SuccessMessages.BatchCreated, result));

        }

        public async Task<DataResult<bool>> DeleteByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default)
        {
            var entities = await _dbSet.Where(e => ids.Contains(e.Id)).ToListAsync(cancellationToken);
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
            return DataResult<bool>.Success(true, string.Format(SuccessMessages.BatchDeleted, entities.Count));
        }

        public async Task<bool> IsExistByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<DataResult<List<TDto>>> GetFilteredAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var list = await _dbSet.Where(predicate).ToListAsync(cancellationToken);
            return DataResult<List<TDto>>.Success(list.Select(MapToDto).ToList());
        }

        public async Task<DataResult<PaginatedResult<TDto>>> GetPaginatedAsync(PaginationRequest request, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.Where(e => !e.IsDeleted).AsQueryable();

            var total = await query.CountAsync(cancellationToken);
            var pageData = await query
                .Skip(request.Skip)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var result = new PaginatedResult<TDto>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = total,
                Items = pageData.Select(MapToDto).ToList()
            };

            return DataResult<PaginatedResult<TDto>>.Success(result, SuccessMessages.Listed);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        // 🔽 Harici sınıflar tarafından implement edilecek
        protected abstract TDto MapToDto(TEntity entity);
        protected abstract TEntity MapToEntity(TDto dto);
        protected abstract void UpdateEntity(TEntity entity, TDto dto);
    }
}
