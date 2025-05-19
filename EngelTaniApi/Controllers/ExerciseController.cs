using EngelTaniApi.Application.Dtos;
using EngelTaniApi.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EngelTaniApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _exerciseService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _exerciseService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExerciseDto dto, CancellationToken cancellationToken)
        {
            var result = await _exerciseService.CreateAsync(dto, cancellationToken);
            return Ok(result);
        }
        [HttpPost("create-many")]
        public async Task<IActionResult> CreateMany([FromBody] List<ExerciseDto> dtos, CancellationToken cancellationToken)
        {
            var result = await _exerciseService.CreateRangeAsync(dtos, cancellationToken);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ExerciseDto dto, CancellationToken cancellationToken)
        {
            var result = await _exerciseService.UpdateAsync(id, dto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _exerciseService.DeleteAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost("paginated")]
        public async Task<IActionResult> GetPaginated([FromBody] PaginationRequest request, CancellationToken cancellationToken)
        {
            var result = await _exerciseService.GetPaginatedAsync(request, cancellationToken);
            return Ok(result);
        }
    }
}
