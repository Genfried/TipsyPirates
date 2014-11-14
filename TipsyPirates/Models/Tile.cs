using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipsyPirates.Models
{
    public abstract class Tile
    {
        public Tile[] Neighbours { get { return _Neighbours; } }

        private Tile[] _Neighbours  {get; set;}

        public Tile()
        {
            _Neighbours = new Tile[Enum.GetNames(typeof(Enums.Direction)).Length];
        }

        public void SetNeighbour(Tile tile, Enums.Direction direction)
        {
            Neighbours[(int)direction] = tile;
            if (tile.Neighbours[(int)Enums.GetOppositeDirection(direction)] != this)
            {
                tile.SetNeighbour(this, Enums.GetOppositeDirection(direction));
            }
        }
        
        public void OnArrival(Ship ship)
        {

        }

        public void OnDeparture(Ship ship)
        {

        }

        public void OnEndTurn(Ship ship)
        {

        }
    }
}