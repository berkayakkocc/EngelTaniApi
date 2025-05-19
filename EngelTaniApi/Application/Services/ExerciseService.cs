using EngelTaniApi.Application.Dtos;
using EngelTaniApi.Core.Entities;
using EngelTaniApi.Core.Interfaces;
using EngelTaniApi.Infrastructure.Data;

namespace Application.Services
{
    public class ExerciseService : BaseGenericService<Exercise, ExerciseDto>, IExerciseService
    {
        public ExerciseService(EngelTaniDbContext context) : base(context)
        {
        }

        protected override ExerciseDto MapToDto(Exercise entity)
        {
            return new ExerciseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                DurationInMinutes = entity.DurationInMinutes
            };
        }

        protected override Exercise MapToEntity(ExerciseDto dto)
        {
            return new Exercise
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                DurationInMinutes = dto.DurationInMinutes
            };
        }

        protected override void UpdateEntity(Exercise entity, ExerciseDto dto)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.DurationInMinutes = dto.DurationInMinutes;
        }
    }
}
