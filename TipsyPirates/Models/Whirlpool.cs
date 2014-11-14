using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipsyPirates.Models
{
    public class ClockwiseWhirlpool : Tile
    {
        public override void OnEndPhase(Ship ship)
        {
            ship.TurnStarboard();
        }
    }

    public class CounterclockwiseWhirlpool : Tile
    {
        public override void OnEndPhase(Ship ship)
        {
            ship.TurnPort();
        }
    }
}