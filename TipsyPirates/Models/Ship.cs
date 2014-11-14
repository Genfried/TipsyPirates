using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipsyPirates.Models
{
    public class Ship
    {
        public int CrewMembers { get { return _CrewMembers; } }
        public int ReserveShips { get { return _ReserveShips; } }
        public Enums.Direction Direction { get { return _Direction; } }
        public virtual Tile Location { get { return _Location; } }
        
        private int _CrewMembers { get; set; }
        private int _ReserveShips { get; set; }
        private Enums.Direction _Direction { get; set; }
        private Tile _Location { get; set; }

        public Ship(Tile tile)
        {
            _CrewMembers = 10;
            _ReserveShips = 2;
            _Direction = Enums.Direction.North;
            _Location = tile;
        }

        public void Sail()
        {
            Tile[] tiles = _Location.Neighbours;
            Tile destinationtile = tiles[(int)Direction];            

            if (IsValidDirectionToSail(destinationtile))
            {
                DepartFromTile(_Location);
                ArriveOnTile(destinationtile);
                _Location = destinationtile;
            }
        }

        public void SailBackwards()
        {
            Tile[] tiles = _Location.Neighbours;
            Tile destinationtile = tiles[(int)Enums.GetOppositeDirection(Direction)];

            if (IsValidDirectionToSail(destinationtile))
            {
                DepartFromTile(_Location);
                ArriveOnTile(destinationtile);
                _Location = destinationtile;
            }
        }   

        public void TurnRight()
        {
            int direction = GetRightDirection(Direction);
            _Direction = (Enums.Direction)direction;
        }

        public void TurnLeft()
        {
            int direction = GetLeftDirection(Direction);
            _Direction = (Enums.Direction)direction;
        }

        private int GetRightDirection(Enums.Direction Direction)
        {
            return ((int)Direction + 1) % Enum.GetNames(typeof(Enums.Direction)).Length;
        }

        private int GetLeftDirection(Enums.Direction Direction)
        {
            return GetRightDirection((Enums.Direction)GetRightDirection((Enums.Direction)GetRightDirection(Direction)));
        }

        private Tile GetOriginalTile(Tile tile)
        {
            return tile.Neighbours[(int)Enums.GetOppositeDirection(Direction)];
        }

        private void DepartFromTile(Tile tile)
        {
            tile.OnDeparture(this);
        }

        private void ArriveOnTile(Tile tile)
        {
            tile.OnArrival(this);
        }

        private bool IsValidDirectionToSail(Tile tile)
        {
            return tile != null;
        }
    }
}