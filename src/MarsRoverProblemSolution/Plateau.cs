using MarsRoverProblemSolution.Infrastructure.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverProblemSolution.Infrastructure
{
    public class Plateau
    {
        public Coordinate MaximumCoodinatePoints { get; set; }
        public List<Rover> Rovers { get; set; }

        public Plateau(string plateauPoints)
        {
            SetPlateauPoints(plateauPoints);
            Rovers = new List<Rover>();
        }

        /// <summary>
        /// check rover coordinate and return a boolean result accourding to plateau limits
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// add new rover to plateau
        /// </summary>
        /// <param name="rover"></param>
        public void AddNewRover(Rover rover)
        {
            if (CheckExistingRoversEndPoint(rover))
            {
                throw new Exception("There is already a rover that point!");
            }
            rover.Plateau = this;
            this.Rovers.Add(rover);
        }

        /// <summary>
        /// add rover with fluently
        /// </summary>
        /// <param name="startPoints"></param>
        /// <returns></returns>
        public Rover AddNewRover(string startPoints)
        {
            var rover = new Rover(startPoints);
            if (CheckExistingRoversEndPoint(rover))
            {
                throw new Exception("There is already a rover that point!");
            }
            rover.Plateau = this;
            this.Rovers.Add(rover);
            return rover;
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

        private bool CheckExistingRoversEndPoint(Rover rover)
        {
            return this.Rovers.Any(r => r.Coordinate.Equals(rover.Coordinate));
        }
    }
}
