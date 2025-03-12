using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer;
using Xunit;

namespace DungeonExplorer.Tests
{
    public class Tests
    {
        /// <summary>
        /// Tests that a room can be created
        /// </summary>
        [Fact]
        public void TestCreateRoom()
        {
            Room room = new Room("Test Room");
            Assert.Equal("Test Room", room.GetDescription());
        }

        /// <summary>
        /// Tests that an item can be added to a room
        /// </summary>
        [Fact]
        public void TestCreateItem()
        {
            Room room = new Room("Test Room");
            room.CreateItem("Test Item");
            Assert.Contains("Test Item", room.RoomItems);
        }

        /// <summary>
        /// Tests that an enemy can be added to a room
        /// </summary>
        [Fact]
        public void TestAddEnemy()
        {
            Room room = new Room("Test Room");
            room.AddEnemy("Test Enemy");
            Assert.Contains("Test Enemy", room.Enemies);
        }

        /// <summary>
        /// Tests that an item can be removed from a room
        /// </summary>
        [Fact]
        public void TestRemoveItem()
        {
            Room room = new Room("Test Room");
            room.CreateItem("Test Item");
            room.RemoveItem("Test Item");
            Assert.DoesNotContain("Test Item", room.RoomItems);
        }

        /// <summary>
        /// Tests that the player's health is set correctly
        /// </summary>
        [Fact]
        public void TestPlayerHealth()
        {
            Player player = new Player("Test Player", 100);
            Assert.Equal(100, player.Health);
        }

        /// <summary>
        /// Tests that the player's health is capped at 100
        /// </summary>
        [Fact]
        public void TestPlayerName()
        {
            Player player = new Player("Test player", 100);
            Assert.Equal("Test Player", player.Name);
        }

        /// <summary>
        /// Tests that the player can enter a room
        /// </summary>
        [Fact]
        public void TestPlayerEnterRoom()
        {
            Room room = new Room("Test Room");
            Player player = new Player("Test player", 100);
            player.EnterRoom(room);
            Assert.Equal(room, player.CurrentRoom);
        }
    }
}
