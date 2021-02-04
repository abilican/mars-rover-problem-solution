using MarsRoverProblemSolution.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRoverProblemSolution.Tests
{
    public class PlateauTests
    {
        [Theory]
        [InlineData("3")]
        [InlineData("3 R")]
        [InlineData("32 K")]
        [InlineData("3 2 3")]
        [InlineData("")]
        public void Constructor_WrongPointsFormats_MustThrowAnException(string points)
        {
            Assert.Throws<Exception>(() => new Plateau(points));
        }

        [Theory]
        [InlineData(-1,0)]
        [InlineData(2,-2)]
        [InlineData(6,5)]
        [InlineData(2,7)]
        public void CheckRoverCurrentCoordinate_IsRoverOutOfArea_ReturnFalse(int x,int y)
        {
            //Arrage
            Plateau plateau = new Plateau("5 5");

            //Act
            bool result = plateau.CheckRoverCurrentCoordinate(new Coordinate(x, y));

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(0,2)]
        [InlineData(5,0)]
        [InlineData(5,5)]
        [InlineData(2,3)]
        public void CheckRoverCurrentCoordinate_IsRoverInArea_ReturnTrue(int x, int y)
        {
            //Arrage
            Plateau plateau = new Plateau("5 5");

            //Act
            bool result = plateau.CheckRoverCurrentCoordinate(new Coordinate(x, y));

            //Assert
            Assert.True(result);
        }
    }
}
