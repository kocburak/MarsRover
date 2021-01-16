using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Interpreter
    {
        public Rover MarsRover { get; set; }

        public Interpreter(Rover rover)
        {
            MarsRover = rover;
        }

        public void InterpretPosition(string positions)
        {
            var splittedPosition = positions.Split(' ');

            if (splittedPosition.Length != 3)
            {
                throw new ArgumentException("Position is expected as 2 integer and Direction charater (N,E,S,W) with a space between them. Input :" + positions);
            }

            if (int.TryParse((string)splittedPosition[0], out int positionX))
            {

                MarsRover.PositionX = positionX;
            }
            else
            {
                throw new ArgumentException("Position is expected as 2 integer and Direction charater (N,E,S,W) with a space between them. Input :" + positions);
            }

            if (int.TryParse((string)splittedPosition[1], out int positionY))
            {

                MarsRover.PositionY = positionY;
            }
            else
            {
                throw new ArgumentException("Position is expected as 2 integer and Direction charater (N,E,S,W) with a space between them. Input :" + positions);
            }

            if (Enum.TryParse(splittedPosition[2], out DirectionEnum direction))
            {

                MarsRover.CurrentDirection = direction;
            }
            else
            {
                throw new ArgumentException("Position is expected as 2 integer and Direction charater (N,E,S,W) with a space between them. Input :" + positions);
            }
        }

        public void InterpretMapLimits(string mapSize)
        {
            var mapLimits = mapSize.Split(' ');

            if (mapLimits.Length != 2)
            {
                throw new ArgumentException("Map size is expected as 2 integer with a space between them. Input :" + mapSize);
            }

            if (int.TryParse(mapLimits[0], out int mapSizeX))
            {

                MarsRover.MapSizeX = mapSizeX;
            }
            else
            {
                throw new ArgumentException("Map size is expected as 2 integer with a space between them. Input :" + mapSize);
            }

            if (int.TryParse(mapLimits[1], out int mapSizeY))
            {

                MarsRover.MapSizeY = mapSizeY;
            }
            else
            {
                throw new ArgumentException("Map size is expected as 2 integer with a space between them. Input :" + mapSize);
            }
        }

        public void InterpretCommands(string commands)
        {
            foreach (char command in commands.ToCharArray())
            {
                if (command == 'L')
                {
                    MarsRover.RotateLeft();
                }
                else if (command == 'R')
                {
                    MarsRover.RotateRight();
                }
                else if (command == 'M')
                {
                    MarsRover.GoForward();
                }
                else
                {
                    throw new ArgumentException("Invalid move. Valid moves are L,R,M. Input: " + command);
                }
            }
        }

        public string[] InterpretLines(string[] lines)
        {
            var output = new List<string>();

            if (lines.Length < 3)
            {
                throw new ArgumentException("Input should contains at least 3 valid lines");
            }
            else if (lines.Length % 2 != 1)
            {
                throw new ArgumentException("Input should contains odd number of lines");
            }

            InterpretMapLimits(lines[0]);

            for (int i = 1; i < lines.Length; i += 2)
            {
                InterpretPosition(lines[i]);
                InterpretCommands(lines[i + 1]);
                output.Add($"{MarsRover.PositionX} {MarsRover.PositionY} {MarsRover.CurrentDirection}");
            }

            return output.ToArray();
        }

    }

}
