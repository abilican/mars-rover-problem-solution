using FluentValidation;

namespace MarsRoverProblemSolution.Infrastructure.Validations
{
    public class PlateauPointsValidation : AbstractValidator<string>
    {
        public PlateauPointsValidation()
        {
            RuleFor(x => x).NotNull().NotEmpty().Matches(@"^[1-9][0-9]* [1-9][0-9]*$")
                .WithMessage("Command line has invalid character");
        }
    }
}
