using MarsRoverProblemSolution.Infrastructure.Contracts;

namespace MarsRoverProblemSolution.Infrastructure.MoveDirections
{
    public class Right : IMovement
    {
        public void Execute(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.North:
                    rover.Direction = Direction.East;
                    break;
                case Direction.South:
                    rover.Direction = Direction.West;
                    break;
                case Direction.East:
                    rover.Direction = Direction.South;
                    break;
                case Direction.West:
                    rover.Direction = Direction.North;
                    break;
            }
        }
    }
}
