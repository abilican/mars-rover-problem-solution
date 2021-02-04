namespace MarsRoverProblemSolution.Infrastructure.Contracts
{
    public interface IRover
    {
        Plateau Plateau { get; set; }
        Coordinate Coordinate { get; set; }
        Direction Direction { get; set; }
        string RoverPosition { get; }
        void RunCommands(string commands);
    }
}
