using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProblemSolution.Infrastructure.Contracts
{
    public interface IMovement
    {
        void Execute(Rover rover);
    }
}
