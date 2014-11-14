using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipsyPirates.Models
{
    public class Current:Tile
    {
        public Enums.Direction Direction { get { return _Direction; } }

        private Enums.Direction _Direction { get; set; }

        public Current(Enums.Direction direction)
        {
            _Direction = direction;
        }

        public override void OnEndPhase(Ship ship)
        {
            ship.MoveTo(GetNeighbour(Direction)); 
        }
    }

    public class LeftCurrent : Current
    {
        public LeftCurrent(Enums.Direction direction) : base(direction) { }

        public override void OnEndPhase(Ship ship)
        {
            ship.TurnPort();
            base.OnEndPhase(ship);
        }
    }

    public class RightCurrent : Current
    {
        public RightCurrent(Enums.Direction direction) : base(direction) { }

        public override void OnEndPhase(Ship ship)
        {
            ship.TurnStarboard();
            base.OnEndPhase(ship);
        }
    }
}