using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipsyPirates.Models
{
    public class Enums
    {
        public enum CommandType { Move = 0, TurnRight = 1, TurnLeft = 2, Backwards = 3 };

        public enum Direction { North = 0, East = 1, South = 2, West = 3 };

        public static Direction GetOppositeDirection(Direction direction)
        {
            if (direction == Direction.North)
            {
                return Direction.South;
            }
            if (direction == Direction.South)
            {
                return Direction.North;
            }
            if (direction == Direction.West)
            {
                return Direction.East;
            }
            return Direction.West;
        }
    }
}