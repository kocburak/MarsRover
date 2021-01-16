using System;

namespace MarsRover
{
    public class Rover
    {
        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public DirectionEnum CurrentDirection { get; set; }

        public void RotateLeft()
        {
            switch (CurrentDirection)
            {
                case DirectionEnum.N:
                    CurrentDirection = DirectionEnum.W;
                    break;
                case DirectionEnum.E:
                    CurrentDirection = DirectionEnum.N;
                    break;
                case DirectionEnum.S:
                    CurrentDirection = DirectionEnum.E;
                    break;
                case DirectionEnum.W:
                    CurrentDirection = DirectionEnum.S;
                    break;
            }
        }

        public void RotateRight()
        {
            switch (CurrentDirection)
            {
                case DirectionEnum.N:
                    CurrentDirection = DirectionEnum.E;
                    break;
                case DirectionEnum.E:
                    CurrentDirection = DirectionEnum.S;
                    break;
                case DirectionEnum.S:
                    CurrentDirection = DirectionEnum.W;
                    break;
                case DirectionEnum.W:
                    CurrentDirection = DirectionEnum.N;
                    break;
            }
        }

        public void GoForward()
        {
            switch (CurrentDirection)
            {
                case DirectionEnum.N:
                    PositionY += 1;
                    break;
                case DirectionEnum.E:
                    PositionX += 1;
                    break;
                case DirectionEnum.S:
                    PositionY -= 1;
                    break;
                case DirectionEnum.W:
                    PositionX -= 1;
                    break;
            }

            if (PositionX > MapSizeX || PositionX < 0 || PositionY < 0 || PositionY > MapSizeY)
            {
                throw new InvalidOperationException($"Rover is outside of the map. Rover is at ({PositionX}, {PositionY}), Map size is ({MapSizeX}, {MapSizeY})");
            }
        }
    }
}
