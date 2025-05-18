using EngelTaniApi.Core.Common;

namespace EngelTaniApi.Application.Dtos
{
    public class ExerciseDto:BaseIdDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int DurationInMinutes { get; set; }

    }
}
