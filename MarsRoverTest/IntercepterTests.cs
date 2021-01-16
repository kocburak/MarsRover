using System;
using MarsRover;
using Xunit;

namespace MarsRoverTest
{
    public class IntercepterTests
    {
        [Theory, InlineData("5 5",5,5), InlineData("3 4",3,4)]
        public void Intercepter_InterpretMapLimits(string input, int mapSizeX, int mapSizeY)
        {
            Rover rover = new Rover();
            Interpreter interpreter = new Interpreter(rover);

            interpreter.InterpretMapLimits(input);

            Assert.Equal(mapSizeX, rover.MapSizeX);
            Assert.Equal(mapSizeY, rover.MapSizeY);
        }

        [Theory,
            InlineData("1 2 E", 1, 2, DirectionEnum.E),
            InlineData("3 3 W", 3, 3, DirectionEnum.W)]
        public void Intercepter_InterpretRoverPosition(string input, int positionX, int positionY, DirectionEnum direction)
        {
            Rover rover = new Rover()
            {
                MapSizeX = 5,
                MapSizeY = 5
            };
            Interpreter interpreter = new Interpreter(rover);

            interpreter.InterpretPosition(input);

            Assert.Equal(positionX, rover.PositionX);
            Assert.Equal(positionY, rover.PositionY);
            Assert.Equal(direction, rover.CurrentDirection);
        }

        [Theory, InlineData("4 4 2"), InlineData("3 E")]
        public void Intercepter_InterpretMapLimits_WithInvalidInputs(string input)
        {
            Rover rover = new Rover();
            Interpreter interpreter = new Interpreter(rover);

            Assert.Throws<ArgumentException>(() => interpreter.InterpretMapLimits(input));
        }

        [Theory, InlineData("1 2 X"), InlineData("4 4 2"), InlineData("3 E")]
        public void Intercepter_InterpretRoverPosition_WithInvalidDirection(string input)
        {
            Rover rover = new Rover()
            {
                MapSizeX = 5,
                MapSizeY = 5
            };
            Interpreter interpreter = new Interpreter(rover);

            Assert.Throws<ArgumentException>(() => interpreter.InterpretPosition(input));
        }

        [Theory,
            InlineData("LMLMLMLMM", 1, 3, DirectionEnum.N),
            InlineData("MMRMMRMRRM", 3, 4, DirectionEnum.N)
            ]
        public void Intercepter_InterpretCommands(string input, int positionX, int positionY, DirectionEnum direction)
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

            interpreter.InterpretCommands(input);

            Assert.Equal(positionX, rover.PositionX);
            Assert.Equal(positionY, rover.PositionY);
            Assert.Equal(direction, rover.CurrentDirection);
        }

        [Theory, InlineData("MMMMM"), InlineData("RMMMMM")]
        public void Intercepter_InterpretCommands_WithOutOfMap_ThrowsArgumentException(string input)
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

            Assert.Throws<InvalidOperationException>(() => interpreter.InterpretCommands(input));
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

        [Fact]
        public void Intercepter_InterpretLines()
        {
            Rover rover = new Rover();

            Interpreter interpreter = new Interpreter(rover);


            var input = new string[]
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            var expectedOutput = new string[]
            {
                "1 3 N",
                "5 1 E"
            };

            var actualOutput = interpreter.InterpretLines(input);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Intercepter_InterpretLines_WithInvalidMapSizeFormatInput_ThrowsArgumentException()
        {
            Rover rover = new Rover();

            Interpreter interpreter = new Interpreter(rover);


            var input = new string[]
            {
                "5 5 X",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };
            Assert.Throws<ArgumentException>(() => interpreter.InterpretLines(input));
        }

        [Fact]
        public void Intercepter_InterpretLines_WithInvalidRoverPositionInput_ThrowsArgumentException()
        {
            Rover rover = new Rover();

            Interpreter interpreter = new Interpreter(rover);


            var input = new string[]
            {
                "5 5",
                "1 S 2",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };
            Assert.Throws<ArgumentException>(() => interpreter.InterpretLines(input));
        }

        [Fact]
        public void Intercepter_InterpretLines_WithMissingInput_ThrowsArgumentException()
        {
            Rover rover = new Rover();

            Interpreter interpreter = new Interpreter(rover);


            var input = new string[]
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "MMRMMRMRRM"
            };
            Assert.Throws<ArgumentException>(() => interpreter.InterpretLines(input));
        }


    }
}
