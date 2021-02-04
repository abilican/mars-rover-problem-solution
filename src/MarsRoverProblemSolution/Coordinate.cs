namespace MarsRoverProblemSolution.Infrastructure
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x,int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object j)
        {
            Coordinate c = (Coordinate)j;
            if (c.X == X && c.Y == Y)
            {
                return true;
            }
            return false;
        }
    }
}
