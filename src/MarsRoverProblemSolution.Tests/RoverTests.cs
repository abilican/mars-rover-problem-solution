using MarsRoverProblemSolution.Infrastructure;
using MarsRoverProblemSolution.Infrastructure.Contracts;
using System;
using Xunit;

namespace MarsRoverProblemSolution.Tests
{
    public class RoverTests
    {
        [Theory]
        [InlineData("3")]
        [InlineData("3 R")]
        [InlineData("3 2 K")]
        [InlineData("3 2 3")]
        [InlineData("N L W")]
        public void Constructor_WrongStartPositionFormats_MustThrowAnException(string startPoints)
        {
            //Arrange
            Plateau plateau = new Plateau("5 5");

            //Act

            //Assert
            Assert.Throws<Exception>(() => new Rover(startPoints));
        }

        [Theory]
        [InlineData("3")]
        [InlineData("333")]
        [InlineData("LRWK")]
        public void RunCommands_HasWrongFormats_MustThrowException(string runCommands)
        {
            //Arrange
            Plateau plateau = new Plateau("5 5");
            Rover rover = new Rover( "0 0 W");
            plateau.AddNewRover(rover);

            //Act

            //Assert
            Assert.Throws<Exception>(() => rover.RunCommands(runCommands));
        }

        [Theory]
        [InlineData("MMMM")]
        [InlineData("RMMMM")]
        public void RunCommands_GettingOutOfPlateau_MustThrowException(string commands)
        {
            //Arrange
            Plateau plateau = new Plateau("5 5");
            Rover rover = new Rover("2 2 W");
            plateau.AddNewRover(rover);

            //Act

            //Assert
            Assert.Throws<Exception>(() => rover.RunCommands(commands));
        }

        [Fact]
        public void RoverDirectionNorth_TurnRight_BeEast()
        {
            //Arrange
            Plateau plateau = new Plateau("5 5");
            Rover rover = new Rover( "1 2 N");
            plateau.AddNewRover(rover);
            rover.RunCommands("R");

            //Act
            string result = rover.RoverPosition;

            //Assert
            Assert.Equal("1 2 E", result);
        }

        [Fact]
        public void RoverDirectionNorth_TurnLeft_BeWest()
        {
            //Arrange
            Plateau plateau = new Plateau("5 5");
            Rover rover = new Rover("1 2 N");
            plateau.AddNewRover(rover);
            rover.RunCommands("L");

            //Act
            string result = rover.RoverPosition;

            //Assert
            Assert.Equal("1 2 W", result);
        }

        [Fact]
        public void RoverDirectionNorth_Move_YCoordinateMustBeUp()
        {
            //Arrange
            Plateau plateau = new Plateau("5 5");
            Rover rover = new Rover("1 2 N");
            plateau.AddNewRover(rover);
            rover.RunCommands("M");

            //Act
            string result = rover.RoverPosition;

            //Assert
            Assert.Equal("1 3 N", result);
        }

        [Fact]
        public void RunCommands_RoverDirection_MustBeNorth()
        {
            //Arrange
            Plateau plateau = new Plateau("5 5");
            Rover rover = new Rover("1 2 N");
            plateau.AddNewRover(rover);
            rover.RunCommands("LMLMLMLMM");

            //Act
            string result = rover.RoverPosition;
                        
            //Assert
            Assert.Equal("1 3 N", result);
        }

        [Fact]
        public void RunCommands_RoverDirection_MustBeEast()
        {
            //Arrange
            Plateau plateau = new Plateau("5 5");
            Rover rover = new Rover("3 3 E");
            plateau.AddNewRover(rover);
            rover.RunCommands("MMRMMRMRRM");

            //Act
            string result = rover.RoverPosition;

            //Assert
            Assert.Equal("5 1 E", result);
        }

        [Fact]
        public void When_NewRoverFallDownToExistingRover_ThrowInvalidStartPointException()
        {
            //Arrange
            Plateau plateau = new Plateau("5 5");
            plateau.AddNewRover("3 3 E")
                    .RunCommands("MM");

            //Act
            var rover = new Rover("5 3 E");
            
            //Assert            
            Assert.Throws<Exception>(() => plateau.AddNewRover(rover));
        }
    }
}
