namespace MarsRoverProblemSolution.Infrastructure.Extensions
{
    public static class DirectionExtension
    {
        public static string GetDirectionDescription(this Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return "N";
                case Direction.East:
                    return "E";
                case Direction.South:
                    return "S";
                case Direction.West:
                    return "W";
                default:
                    throw new System.Exception("Wrong direction input");
            }
        }
        public static Direction GetDirectionFromDescription(this string directionLetter)
        {
            switch (directionLetter)
            {
                case "N":
                    return Direction.North;
                case "E":
                    return Direction.East;
                case "S":
                    return Direction.South;
                case "W":
                    return Direction.West;
                default:
                    throw new System.Exception("Wrong direction input");
            }
        }
    }
}
