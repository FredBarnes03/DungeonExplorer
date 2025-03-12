using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a room in the game
    /// </summary>
    public class Room
    {
        private string description;
        public List<string> RoomItems { get; private set; }
        public List<string> Enemies { get; private set; }
        public Dictionary<string, Room> ConnectedRooms { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class
        /// </summary>
        /// <param name="description">The description of the room.</param>
        public Room(string description)
        {
            this.description = description;
            RoomItems = new List<string>();
            Enemies = new List<string>();
        }

        /// <summary>
        /// Gets the room's description
        /// </summary>
        /// <returns>The description of the room.</returns>
        public string GetDescription()
        {
            return description;
        }

        /// <summary>
        /// Adds an item to the room
        /// </summary>
        /// <param name="item">The item to place in the room.</param>
        public void CreateItem(string item)
        {
            RoomItems.Add(item);
        }

        /// <summary>
        /// Adds an enemy to the room
        /// </summary>
        /// <param name="enemy">The enemy to place in the room.</param>
        public void AddEnemy(string enemy)
        {
            Enemies.Add(enemy);
        }

        /// <summary>
        /// Removes an item from the room
        /// </summary>
        /// <param name="item">The item to remove from the room.</param>
        public void RemoveItem(string item)
        {
            RoomItems.Remove(item);
        }

        /// <summary>
        /// Removes an enemy from the room
        /// </summary>
        /// <param name="enemy">The enemy to remove from the room.</param>
        public void RemoveEnemy(string enemy)
        {
            Enemies.Remove(enemy);
        }

        /// <summary>
        /// Connects rooms together in a specified direction
        /// </summary>
        /// <param name="north">Room to the north.</param>
        /// <param name="south">Room to the south.</param>
        /// <param name="east">Room to the east.</param>
        /// <param name="west">Room to the west.</param>
        public void InstantiateMappings(Room north = null, Room south = null, Room east = null, Room west = null)
        {
            // Create a dictionary to store the connected rooms
            ConnectedRooms = new Dictionary<string, Room>();
            if (north != null)
            {
                ConnectedRooms["North"] =  north;
            }
            if (south != null)
            {
                ConnectedRooms["South"] = south;
            }
            if (east != null)
            {
                ConnectedRooms["East"] = east;
            }
            if (west != null)
            {
                ConnectedRooms["West"] = west;
            }
        }
    }
}