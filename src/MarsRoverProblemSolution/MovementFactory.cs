using MarsRoverProblemSolution.Infrastructure.Contracts;
using MarsRoverProblemSolution.Infrastructure.MoveDirections;
using MarsRoverProblemSolution.Infrastructure.Movements;
using System;

namespace MarsRoverProblemSolution.Infrastructure
{
    public class MovementFactory
    {
        public static IMovement Get(char moveType)
        {
            switch (moveType)
            {
                case 'L':
                    return new Left();
                case 'R':
                    return new Right();
                case 'M':
                    return new Move();
                default:
                    throw new Exception("entered move types has incorrect letter");
            }
        }
    }
}
