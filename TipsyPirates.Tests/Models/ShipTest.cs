using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipsyPirates.Models;

namespace TipsyPirates.Tests.Models
{
    [TestClass]
    public class ShipTest
    {
        [TestMethod]
        public void TestShipInitialisation()
        {
            Tile tile = new NormalTile();
            Ship ship = new Ship(tile);
            Assert.AreEqual(ship.CrewMembers, 10);
            Assert.AreEqual(ship.ReserveShips, 2);
            Assert.AreEqual(ship.Direction, Enums.Direction.North);
            Assert.AreEqual(ship.Location, tile);
        }

        [TestMethod]
        public void TestSailCorrect()
        {
            Tile tile = new NormalTile();
            tile = CreateSimpleBoard(tile);

            Ship ship = new Ship(tile);
            ship.Sail();
            Assert.AreEqual(ship.Location, tile.Neighbours[(int)Enums.Direction.North]);
        }

        [TestMethod]
        public void TestSailBackwards()
        {
            Tile tile = new NormalTile();
            tile = CreateSimpleBoard(tile);

            Ship ship = new Ship(tile);
            ship.SailBackwards();
            Assert.AreEqual(ship.Location, tile.Neighbours[(int)Enums.Direction.South]);
        }

        [TestMethod]
        public void TestSailWest()
        {
            Tile tile = new NormalTile();
            tile = CreateSimpleBoard(tile);

            Ship ship = new Ship(tile);
            ship.TurnLeft();
            ship.Sail();
            Assert.AreEqual(ship.Location, tile.Neighbours[(int)Enums.Direction.West]);
        } 

        [TestMethod]
        public void TestSailNoTile()
        {
            Tile tile = new NormalTile();
            Ship ship = new Ship(tile);
            ship.Sail();
            Assert.AreEqual(ship.Location, tile);
        }

        [TestMethod]
        public void TestTurnRight()
        {
            Tile tile = new NormalTile();
            Ship ship = new Ship(tile);
            ship.TurnRight();
            Assert.AreEqual(ship.Direction, Enums.Direction.East);
        }

        [TestMethod]
        public void TestTurnLeft()
        {
            Tile tile = new NormalTile();
            Ship ship = new Ship(tile);
            ship.TurnLeft();
            Assert.AreEqual(ship.Direction, Enums.Direction.West);
        }


        private Tile CreateSimpleBoard(Tile tile)
        {
            Tile newTile = new NormalTile();
            Tile eastTile = new NormalTile();
            Tile westTile = new NormalTile();
            Tile southTile = new NormalTile();

            tile.SetNeighbour(newTile, Enums.Direction.North);
            tile.SetNeighbour(eastTile, Enums.Direction.East);
            tile.SetNeighbour(westTile, Enums.Direction.West);
            tile.SetNeighbour(southTile, Enums.Direction.South);
            return tile;
        }
    }
}
