using MarsRoverProblemSolution.Infrastructure.Validations;
using System;
using System.Linq;

namespace MarsRoverProblemSolution.Infrastructure
{
    public class Plateau
    {
        public Coordinate MaximumCoodinatePoints { get; set; }

        public Plateau(Coordinate coordinate)
        {
            MaximumCoodinatePoints = coordinate;
        }

        public Plateau(string plateauPoints)
        {
            SetPlateauPoints(plateauPoints);
        }

        public bool CheckRoverCurrentCoordinate(Coordinate coordinate)
        {
            if(coordinate.X < 0 || coordinate.Y < 0)
            {
                return false;
            }

            if (coordinate.X > MaximumCoodinatePoints.X || coordinate.Y > MaximumCoodinatePoints.Y )
            {
                return false;
            }

            return true;
        }

        private void SetPlateauPoints(string plateauPoints)
        {
            var validation = new PlateauPointsValidation().Validate(plateauPoints);
            if (!validation.IsValid)
            {
                throw new Exception(validation.Errors.Select(a => a.ErrorMessage).FirstOrDefault());
            }

            var points = plateauPoints.Split(' ');
            int.TryParse(points[0], out int x);
            int.TryParse(points[1], out int y);

            MaximumCoodinatePoints = new Coordinate(x,y);
        }
    }
}
