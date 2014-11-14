using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipsyPirates.Models;

namespace TipsyPirates.Tests.Models
{
    [TestClass]
    public class TileTest
    {
        [TestMethod]
        public void TestTileInitialisation()
        {
            Tile tile = new NormalTile();
            Tile[] tiles = new Tile[(Enum.GetNames(Enums.Direction.East.GetType()).Length)];
            for (int i = 0; i < tiles.Length; i++)
            {
                Assert.AreEqual(tile.Neighbours[i], tiles[i]);
            }
            Assert.AreEqual(tile.Neighbours.Length, tiles.Length);
        }

        [TestMethod]
        public void TestSailingIntoCurrent()
        {
            //setup
            Current current = new Current(Enums.Direction.East);
            Tile east = new NormalTile();
            current.SetNeighbour(east, Enums.Direction.East);
            Ship ship = new Ship(current);

            //test
            ship.EndPhase();
            Assert.AreSame(east, ship.Location);
        }

        [TestMethod]
        public void TestLongCurrents() //the ship should rest on the tile after the current, even if this tile is a current.
        {
            //setup
            Current current = new Current(Enums.Direction.North);
            Current current2 = new Current(Enums.Direction.North);
            Tile north = new NormalTile();
            current.SetNeighbour(current2, Enums.Direction.North);
            current2.SetNeighbour(north, Enums.Direction.East);
            Ship ship = new Ship(current);

            //test
            ship.EndPhase();
            Assert.AreSame(current2, ship.Location);
        }


        //also test that currents are active when a ship turns in it.
        [TestMethod]
        public void TestTurningInCurrent()
        {
            //setup
            Current current = new Current(Enums.Direction.North);
            Tile north = new NormalTile();
            current.SetNeighbour(north, Enums.Direction.North);
            Ship ship = new Ship(current);

            //test
            ship.TurnPort();
            ship.EndPhase();
            Assert.AreSame(north, ship.Location);
        }

        [TestMethod]
        public void TestSinking()
        {
            //setup
            Tile tile = new NormalTile();
            Ship ship = new Ship(tile);

            //test
            ship.Sink();
            Assert.AreSame(Tile.DavyJonesLocker, ship.Location);
        }

        [TestMethod]
        public void TestSeaMonster()
        {
            //setup
            Tile kraken = new SeaMonster();
            Tile south = new NormalTile();
            kraken.SetNeighbour(south, Enums.Direction.South);
            Ship ship = new Ship(south);

            //test
            ship.Sail(); //the ship winds up in the locker anyway
            Assert.AreSame(Tile.DavyJonesLocker, ship.Location);
        }

        [TestMethod]
        public void TestWhirlPools()
        {
            //setup
            Tile whirlLeft = new CounterclockwiseWhirlpool();
            Tile whirlRight = new ClockwiseWhirlpool();
            Tile south = new NormalTile();
            Tile north = new NormalTile();
            south.SetNeighbour(whirlRight, Enums.Direction.North);
            whirlRight.SetNeighbour(whirlLeft, Enums.Direction.East);
            whirlLeft.SetNeighbour(north, Enums.Direction.North);
            Ship ship = new Ship(south);

            //test
            ship.Sail();
            ship.EndPhase();
            ship.Sail();
            ship.EndPhase();
            ship.Sail();
            ship.EndPhase();
            Assert.AreSame(north, ship.Location);
        }

 


    }
}
