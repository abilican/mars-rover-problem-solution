using MarsRoverProblemSolution.Infrastructure.Contracts;

namespace MarsRoverProblemSolution.Infrastructure.Movements
{
    public class Left : IMovement
    {
        public void Execute(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.North:
                    rover.Direction = Direction.West;
                    break;
                case Direction.South:
                    rover.Direction = Direction.East;
                    break;
                case Direction.East:
                    rover.Direction = Direction.North;
                    break;
                case Direction.West:
                    rover.Direction = Direction.South;
                    break;
            }
        }
    }
}
