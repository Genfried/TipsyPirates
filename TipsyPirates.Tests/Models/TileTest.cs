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
    }
}
