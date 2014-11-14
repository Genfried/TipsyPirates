using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipsyPirates.Models
{
    public class SeaMonster:Tile
    {
        public override void OnArrival(Ship ship)
        {
            ship.Sink();
        }

    }
}