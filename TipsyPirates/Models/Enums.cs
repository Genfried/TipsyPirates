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

        public static Direction RightOf(Direction direction)
        {
            return (Direction)(((int)direction + 1) % 4);
        }


        public static Direction OppositeOf(Direction direction)
        {
            return RightOf(RightOf(direction));
        }
    }
}