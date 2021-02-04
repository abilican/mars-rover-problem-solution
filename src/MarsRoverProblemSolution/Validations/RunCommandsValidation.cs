using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProblemSolution.Infrastructure.Validations
{
    public class RunCommandsValidation: AbstractValidator<string>
    {
        public RunCommandsValidation()
        {
            RuleFor(x => x).NotNull().NotEmpty().Matches(@"^[LRM]+$")
                .WithMessage("Command line has invalid character");
        }
    }
}
