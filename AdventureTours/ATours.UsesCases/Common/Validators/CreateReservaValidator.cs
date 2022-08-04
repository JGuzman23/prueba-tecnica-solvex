using ATours.UseCasesDtos.CreateReserva;
using FluentValidation;

namespace ATours.UseCases.Common.Validators
{
    public class CreateReservaValidator : AbstractValidator<CreateReservaParams>
    {
        public CreateReservaValidator()
        {
            RuleFor(c => c.ClienteId).NotEmpty()
                .WithMessage("Debes iniciar seccion");

            RuleFor(c => c.StartDay).NotEmpty()
                .WithMessage("Debes Seleccionar una fecha de entrada");

            RuleFor(c => c.EndDay).NotEmpty()
                .WithMessage("Debes Seleccionar una fecha de salida");


        }
    }
}
