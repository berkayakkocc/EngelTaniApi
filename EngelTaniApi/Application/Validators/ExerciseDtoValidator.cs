using EngelTaniApi.Application.Dtos;
using FluentValidation;

namespace EngelTaniApi.Application.Validators
{
    public class ExerciseDtoValidator:AbstractValidator<ExerciseDto>
    {
        public ExerciseDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Egzersiz adı boş olamaz.")
                .MaximumLength(100).WithMessage("Egzersiz adı en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.DurationInMinutes)
               .GreaterThan(0).WithMessage("Süre 0'dan büyük olmalıdır");
        }
    }
   
}
