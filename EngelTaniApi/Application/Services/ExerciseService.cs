using EngelTaniApi.Application.Dtos;
using EngelTaniApi.Core.Interfaces;

namespace EngelTaniApi.Application.Services
{
    public class ExerciseService : IExerciseService
    {

       

        public Task<List<ExerciseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ExerciseDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(ExerciseDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, ExerciseDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

      
    }
    
}
