using System;
using MarsRover;
using Xunit;

namespace MarsRoverTest
{
    public class IntercepterTests
    {
        [Fact]
        public void Intercepter_InterpretMapLimits()
        {
            Rover rover = new Rover();
            Interpreter interpreter = new Interpreter(rover);

            interpreter.InterpretMapLimits("5 5");

            Assert.Equal(5, rover.MapSizeX);
            Assert.Equal(5, rover.MapSizeY);


            interpreter.InterpretMapLimits("3 4");

            Assert.Equal(3, rover.MapSizeX);
            Assert.Equal(4, rover.MapSizeY);
        }

        [Fact]
        public void Intercepter_InterpretRoverPosition_12E()
        {
            Rover rover = new Rover()
            {
                MapSizeX = 5,
                MapSizeY = 5
            };
            Interpreter interpreter = new Interpreter(rover);

            interpreter.InterpretPosition("1 2 E");

            Assert.Equal(1, rover.PositionX);
            Assert.Equal(2, rover.PositionY);
            Assert.Equal(DirectionEnum.E, rover.CurrentDirection);


            interpreter.InterpretPosition("3 3 W");

            Assert.Equal(3, rover.PositionX);
            Assert.Equal(3, rover.PositionY);
            Assert.Equal(DirectionEnum.W, rover.CurrentDirection);
        }

        [Fact]
        public void Intercepter_InterpretMapLimits_WithInvalidInputs()
        {
            Rover rover = new Rover();
            Interpreter interpreter = new Interpreter(rover);

            Assert.Throws<ArgumentException>(() => interpreter.InterpretMapLimits("4 4 2"));
            Assert.Throws<ArgumentException>(() => interpreter.InterpretMapLimits("3 E"));
        }



        [Fact]
        public void Intercepter_InterpretRoverPosition_WithInvalidDirection()
        {
            Rover rover = new Rover()
            {
                MapSizeX = 5,
                MapSizeY = 5
            };
            Interpreter interpreter = new Interpreter(rover);

            Assert.Throws<ArgumentException>(() => interpreter.InterpretPosition("1 2 X"));
        }


        [Fact]
        public void Intercepter_InterpretCommands_12N_LMLMLMLMM_13N()
        {
            Rover rover = new Rover()
            {
                CurrentDirection = DirectionEnum.N,
                PositionX = 1,
                PositionY = 2,
                MapSizeX = 5,
                MapSizeY = 5
            };
            Interpreter interpreter = new Interpreter(rover);

            interpreter.InterpretCommands("LMLMLMLMM");

            Assert.Equal(1, rover.PositionX);
            Assert.Equal(3, rover.PositionY);
            Assert.Equal(DirectionEnum.N, rover.CurrentDirection);
        }


        [Fact]
        public void Intercepter_InterpretCommands_33N_MMRMMRMRRM_51E()
        {
            Rover rover = new Rover()
            {
                CurrentDirection = DirectionEnum.E,
                PositionX = 3,
                PositionY = 3,
                MapSizeX = 5,
                MapSizeY = 5
            };

            Interpreter interpreter = new Interpreter(rover);

            interpreter.InterpretCommands("MMRMMRMRRM");

            Assert.Equal(5, rover.PositionX);
            Assert.Equal(1, rover.PositionY);
            Assert.Equal(DirectionEnum.E, rover.CurrentDirection);
        }

        [Fact]
        public void Intercepter_InterpretCommands_WithOutOfMap_33E_MMMMM_ThrowsArgumentException()
        {
            Rover rover = new Rover()
            {
                CurrentDirection = DirectionEnum.E,
                PositionX = 3,
                PositionY = 3,
                MapSizeX = 5,
                MapSizeY = 5
            };

            Interpreter interpreter = new Interpreter(rover);

            Assert.Throws<InvalidOperationException>(() => interpreter.InterpretCommands("MMMMM"));
        }


        [Fact]
        public void Intercepter_InterpretCommands_WithOutOfMap_33E_RMMMMM_ThrowsArgumentException()
        {
            Rover rover = new Rover()
            {
                CurrentDirection = DirectionEnum.E,
                PositionX = 3,
                PositionY = 3,
                MapSizeX = 5,
                MapSizeY = 5
            };

            Interpreter interpreter = new Interpreter(rover);

            Assert.Throws<InvalidOperationException>(() => interpreter.InterpretCommands("RMMMMM"));
        }

        [Fact]
        public void Intercepter_InterpretCommands_WithInvalidCommand_33E_RMMMX_ThrowsArgumentException()
        {
            Rover rover = new Rover()
            {
                CurrentDirection = DirectionEnum.E,
                PositionX = 3,
                PositionY = 3,
                MapSizeX = 5,
                MapSizeY = 5
            };

            Interpreter interpreter = new Interpreter(rover);

            Assert.Throws<ArgumentException>(() => interpreter.InterpretCommands("RMMX"));
        }
    }
}
