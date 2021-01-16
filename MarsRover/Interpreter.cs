using System;

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

    }

}
