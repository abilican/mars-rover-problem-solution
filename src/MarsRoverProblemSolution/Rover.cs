using MarsRoverProblemSolution.Infrastructure.Contracts;
using MarsRoverProblemSolution.Infrastructure.Extensions;
using MarsRoverProblemSolution.Infrastructure.Validations;
using System;
using System.Linq;

namespace MarsRoverProblemSolution.Infrastructure
{
    public class Rover: IRover
    {
        public Plateau Plateau { get; set; }
        public Coordinate Coordinate { get; set; }
        public Direction Direction { get; set; }
        public string RoverPosition
        {
            get
            {
                return $"{Coordinate.X} {Coordinate.Y} {this.Direction.GetDirectionDescription()}";
            }
        }

        public Rover(Plateau plateau,string startPoints)
        {
            Plateau = plateau;
            SetStartPosition(startPoints);
        }
       
        public void RunCommands(string commands)
        {
            var validation = new RunCommandsValidation().Validate(commands);
            if (!validation.IsValid)
            {
                throw new Exception(validation.Errors.Select(a => a.ErrorMessage).FirstOrDefault());
            }

            foreach (var command in commands)
            {
                var commandExecuter = MovementFactory.Get(command);
                commandExecuter.Execute(this);
            }
        }

        private void SetStartPosition(string positionInput)
        {
            var validation = new RoverPositionValidation().Validate(positionInput);
            if (!validation.IsValid)
            {
                throw new Exception(validation.Errors.Select(a => a.ErrorMessage).FirstOrDefault());
            }

            var positions = positionInput.Split(' ');
            int.TryParse(positions[0], out int x);
            int.TryParse(positions[1], out int y);

            Coordinate = new Coordinate(x, y);
            Direction = DirectionExtension.GetDirectionFromDescription(positions[2]);
        }
    }
}
