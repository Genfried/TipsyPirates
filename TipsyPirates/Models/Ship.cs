using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipsyPirates.Models
{
    public class Ship
    {
        public Enums.Direction Direction { get { return _Direction; } }
        public virtual Tile Location { get { return _Location; } }
        
        private Enums.Direction _Direction { get; set; }
        private Tile _Location { get; set; }

        public Ship(Tile tile)
        {
            _Direction = Enums.Direction.North;
            _Location = tile;
        }

        public void Sail()
        {
            MoveTo(Location.GetNeighbour(Direction));
        }

        public void SailBackwards()
        {
            MoveTo(Location.GetNeighbour(Enums.OppositeOf(Direction)));
        }   

        public void TurnStarboard()
        {
            _Direction = Enums.RightOf(Direction);
        }

        public void TurnPort()
        {
            _Direction = Enums.OppositeOf(Enums.RightOf(Direction));
        }


        public void MoveTo(Tile tile)
        {
            if (IsValidLocation(tile))
            {
                _Location = tile;
                Location.OnArrival(this);
            }
        }

        public void Sink()
        {
            MoveTo(Tile.DavyJonesLocker);
        }


        private bool IsValidLocation(Tile tile)
        {
            return tile != null;
        }

        public void EndPhase()
        {
            Location.OnEndPhase(this);
        }
    }
}