using System;
using MarsRover;
using Xunit;

namespace MarsRoverTest
{
    public class RoverTests
    {
        [Fact]
        public void Rover_RotateRight()
        {
            Rover rover = new Rover()
            {
                MapSizeX = 5,
                MapSizeY = 5,
                PositionX = 1,
                PositionY = 1,
                CurrentDirection = DirectionEnum.N
            };

            rover.RotateRight();
            Assert.Equal(DirectionEnum.E, rover.CurrentDirection);

            rover.RotateRight();
            Assert.Equal(DirectionEnum.S, rover.CurrentDirection);

            rover.RotateRight();
            Assert.Equal(DirectionEnum.W, rover.CurrentDirection);

            rover.RotateRight();
            Assert.Equal(DirectionEnum.N, rover.CurrentDirection);
        }

        [Fact]
        public void Rover_RotateLeft()
        {
            Rover rover = new Rover()
            {
                MapSizeX = 5,
                MapSizeY = 5,
                PositionX = 1,
                PositionY = 1,
                CurrentDirection = DirectionEnum.N
            };

            rover.RotateLeft();
            Assert.Equal(DirectionEnum.W, rover.CurrentDirection);

            rover.RotateLeft();
            Assert.Equal(DirectionEnum.S, rover.CurrentDirection);

            rover.RotateLeft();
            Assert.Equal(DirectionEnum.E, rover.CurrentDirection);

            rover.RotateLeft();
            Assert.Equal(DirectionEnum.N, rover.CurrentDirection);
        }


        [Fact]
        public void Rover_GoForward_N()
        {
            Rover rover = new Rover()
            {
                MapSizeX = 5,
                MapSizeY = 5,
                PositionX = 1,
                PositionY = 1,
                CurrentDirection = DirectionEnum.N
            };
            rover.GoForward();
            Assert.Equal(2, rover.PositionY);
        }

        [Fact]
        public void Rover_GoForward_S()
        {
            Rover rover = new Rover()
            {
                MapSizeX = 5,
                MapSizeY = 5,
                PositionX = 1,
                PositionY = 1,
                CurrentDirection = DirectionEnum.S
            };
            rover.GoForward();
            Assert.Equal(0, rover.PositionY);
        }

        [Fact]
        public void Rover_GoForward_W()
        {
            Rover rover = new Rover()
            {
                MapSizeX = 5,
                MapSizeY = 5,
                PositionX = 1,
                PositionY = 1,
                CurrentDirection = DirectionEnum.W
            };
            rover.GoForward();
            Assert.Equal(0, rover.PositionX);
        }

        [Fact]
        public void Rover_GoForward_E()
        {
            Rover rover = new Rover()
            {
                MapSizeX = 5,
                MapSizeY = 5,
                PositionX = 1,
                PositionY = 1,
                CurrentDirection = DirectionEnum.E
            };

            rover.GoForward();
            Assert.Equal(2, rover.PositionX);
        }
    }
}
