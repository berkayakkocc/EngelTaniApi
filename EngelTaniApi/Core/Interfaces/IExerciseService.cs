using EngelTaniApi.Application.Dtos;

namespace EngelTaniApi.Core.Interfaces
{
    public interface IExerciseService
    {
        Task<List<ExerciseDto>> GetAllAsync();
        Task<ExerciseDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(ExerciseDto dto);
        Task<bool> UpdateAsync(int id, ExerciseDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
