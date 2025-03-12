using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents the player character
    /// </summary>
    public class Player
    {

        public string Name { get; private set; }
        private int health;
        private const int maxHealth = 100;
        public Room CurrentRoom { get; private set; }

        private List<string> inventory = new List<string>();

        /// <summary>
        /// Gets or sets the player's health, ensuring it stays within the bounds of 0 and 100
        /// </summary>
        public int Health
        {
            get { return health; }
            set
            {
                // Ensure health stays within bounds, setting it to the max or min if exceeded
                if (value > maxHealth)
                {
                    health = maxHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class
        /// </summary>
        /// <param name="name">Player name.</param>
        /// <param name="health">Player health.</param>
        public Player(string name, int health) 
        {
            // Constructor
            Name = name;
            Health = health;
        }

        /// <summary>
        /// Moves the player to a new room
        /// </summary>
        /// <param name="newRoom"></param>
        public void EnterRoom(Room newRoom)
        {
            CurrentRoom = newRoom;
        }

        /* Not implemented yet
        /// <summary>
        /// Attacks an enemy and deals damage
        /// </summary>
        /// <param name="enemy">Which enemy to attack.</param>
        public void Attack(Enemy enemy)
        {
            enemy.TakeDamage(10);
        }

        /// <summary>
        /// Damages the player by a specified amount
        /// </summary>
        /// <param name="damage">The amount of damage to take.</param>
        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"You took {damage} damage. Your health is now {Health}");
        }

        /// <summary>
        /// Heals the player by a specified amount
        /// </summary>
        /// <param name="amount">The amount of health to restore.</param>
        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"You healed {amount} health. Your health is now {Health}");
        }
        */

        /// <summary>
        /// Displays the player's stats
        /// </summary>
        public void DisplayStats()
        {
            // Display player stats
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Inventory: {InventoryContents()}");
        }

        /// <summary>
        /// Moves the player to a new room in a specified direction if possible
        /// </summary>
        /// <param name="direction">The cardinal direction to move.</param>
        public void Move(string direction)
        {
            // Move the player to a new room
            if (CurrentRoom.ConnectedRooms.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.ConnectedRooms[direction];
                Console.WriteLine($"You moved {direction} and entered a different room");
                Console.WriteLine(CurrentRoom.GetDescription());
            }
            else
            {
                Console.WriteLine("You cannot move in that direction");
            }
        }

        /// <summary>
        /// Picks up an item and adds it to the player's inventory
        /// </summary>
        /// <param name="item">Which item to pickup.</param>
        public void PickUpItem(string item)
        {
            // Pick up an item
            inventory.Add(item);
            Console.WriteLine($"You picked up a {item}");
        }

        /// <summary>
        /// Returns a comma-separated list of inventory items
        /// </summary>
        /// <returns>A string of the items in the players inventory.</returns>
        public string InventoryContents()
        {
            // Return a comma-separated list of inventory items
            return string.Join(", ", inventory);
        }
    }
}