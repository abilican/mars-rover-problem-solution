using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProblemSolution.Infrastructure.Validations
{
    public class RoverPositionValidation : AbstractValidator<string>
    {
        public RoverPositionValidation()
        {
            RuleFor(x => x).NotNull().NotEmpty().Matches(@"^[0-9]+ [0-9]+ [NSWE]$")
                .WithMessage("Command line has invalid character");
        }
    }
}
