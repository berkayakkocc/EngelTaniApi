
using EngelTaniApi.Application.Dtos;
using EngelTaniApi.Core.Common;
using EngelTaniApi.Core.Interfaces.Generic;
using EngelTaniApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<TDto>> GetAllAsync()
        {
            var list = await _dbSet.ToListAsync();
            return list.Select(MapToDto).ToList();
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }


        public async Task<TDto?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return null;
            return MapToDto(entity);
        }

        public async Task<int> CreateAsync(TDto dto)
        {
            var entity = MapToEntity(dto);
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(int id, TDto dto)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            UpdateEntity(entity, dto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // Bunlar subclass tarafından override edilir
        protected abstract TDto MapToDto(TEntity entity);
        protected abstract TEntity MapToEntity(TDto dto);
        protected abstract void UpdateEntity(TEntity entity, TDto dto);

        public virtual async Task<PaginatedResult<TDto>> GetPaginatedAsync(PaginationRequest request)
        {
            var query = _dbSet.AsQueryable();

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip(request.Skip)
                .Take(request.PageSize)
                .ToListAsync();

            return new PaginatedResult<TDto>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                Items = items.Select(MapToDto).ToList()
            };
        }

    }
}
