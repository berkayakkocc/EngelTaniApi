using EngelTaniApi.Application.Dtos;
using EngelTaniApi.Core.Common;

namespace EngelTaniApi.Core.Entities
{
    public class Exercise:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int DurationInMinutes { get; set; }

    }
}
