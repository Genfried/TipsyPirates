using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipsyPirates.Models
{
    public abstract class Tile
    {
        public Tile[] Neighbours { get { return _Neighbours; } }
        public static Tile DavyJonesLocker;

        static Tile() {
            DavyJonesLocker = new NormalTile();
            DavyJonesLocker.SetNeighbour(DavyJonesLocker,Enums.Direction.North);
            DavyJonesLocker.SetNeighbour(DavyJonesLocker,Enums.Direction.East);//can't escape the locker muhahaha!
        }

        private Tile[] _Neighbours  {get; set;}

        public Tile()
        {
            _Neighbours = new Tile[Enum.GetNames(typeof(Enums.Direction)).Length];
        }

        public void SetNeighbour(Tile tile, Enums.Direction direction)
        {
            _Neighbours[(int)direction] = tile;
            if (tile.Neighbours[(int)Enums.OppositeOf(direction)] != this)//automatic back linker
            {
                tile.SetNeighbour(this, Enums.OppositeOf(direction));
            }
        }

        public Tile GetNeighbour(Enums.Direction direction)
        {
            return _Neighbours[(int)direction];
        }

        public virtual void OnArrival(Ship ship) { }
        public virtual void OnEndPhase(Ship ship) { }

    }
}