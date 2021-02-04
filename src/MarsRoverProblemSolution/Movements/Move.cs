using MarsRoverProblemSolution.Infrastructure.Contracts;
using System;

namespace MarsRoverProblemSolution.Infrastructure.MoveDirections
{
    public class Move : IMovement
    {
        void IMovement.Execute(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.North:
                    rover.Coordinate.Y += 1;
                    break;
                case Direction.South:
                    rover.Coordinate.Y -= 1;
                    break;
                case Direction.East:
                    rover.Coordinate.X += 1;
                    break;
                case Direction.West:
                    rover.Coordinate.X -= 1;
                    break;
            }
            if (!rover.Plateau.CheckRoverCurrentCoordinate(rover.Coordinate))
            {
                throw new Exception("Rover getting out of plateau.");
            }
        }
    }
}
