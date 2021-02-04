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

        public Rover(string startPoints)
        {
            SetStartPosition(startPoints);
        }
       
        /// <summary>
        /// entry a new command to rover.
        /// </summary>
        /// <param name="commands"></param>
        public void RunCommands(string commands)
        {
            var validation = new RunCommandsValidation().Validate(commands);
            if (!validation.IsValid)
            {
                throw new Exception(validation.Errors.Select(a => a.ErrorMessage).FirstOrDefault());
            }

            if (this.Plateau == null)
            {
                throw new Exception("Rover have to assign a plateau!");
            }

            foreach (var command in commands)
            {
                var commandExecuter = MovementFactory.Get(command);
                commandExecuter.Execute(this);
            }
        }

        /// <summary>
        /// set start positions from string input to rover.
        /// </summary>
        /// <param name="positionInput"></param>
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
