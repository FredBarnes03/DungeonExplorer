using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public Room CurrentRoom { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            // Constructor
            Name = name;
            Health = health;
        }

        public void EnterRoom(Room newRoom)
        {
            CurrentRoom = newRoom;
        }

        /* not implemented yet
        public void Attack(Enemy enemy)
        {
            enemy.TakeDamage(10);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"You took {damage} damage. Your health is now {Health}");
        }

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"You healed {amount} health. Your health is now {Health}");
        }
        */

        public void DisplayStats()
        {
            // Display player stats
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Inventory: {InventoryContents()}");
        }

        public void Move(string direction)
        {
            // Move to a new room
            if (direction == "north" && CurrentRoom.North != null)
            {
                EnterRoom(CurrentRoom.North);
            }
            else if (direction == "south" && CurrentRoom.South != null)
            {
                EnterRoom(CurrentRoom.South);
            }
            else if (direction == "east" && CurrentRoom.East != null)
            {
                EnterRoom(CurrentRoom.East);
            }
            else if (direction == "west" && CurrentRoom.West != null)
            {
                EnterRoom(CurrentRoom.West);
            }
            else
            {
                Console.WriteLine("You can't go that way.");
            }
        }

        public void PickUpItem(string item)
        {
            // Pick up an item
            inventory.Add(item);
            Console.WriteLine($"You picked up a {item}");
        }

        public string InventoryContents()
        {
            // Return a comma-separated list of inventory items
            return string.Join(", ", inventory);
        }
    }
}