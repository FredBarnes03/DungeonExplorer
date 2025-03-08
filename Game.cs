using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Create rooms
            Room room1 = new Room("A dark room with an exit to the North");
            Room room2 = new Room("A room with a monster and an exit to the East");
            Room room3 = new Room("A room with a treasure chest");
            // Create items
            room1.CreateItem("Sword");
            room3.CreateItem("Coin");

            // Connect rooms
            room1.North = room2;
            room2.South = room1;
            room2.East = room3;
            room3.West = room2;

            // Create player
            Console.WriteLine("Enter player name");
            string playerName = Console.ReadLine();
            player = new Player(playerName, 100);
            player.EnterRoom(room1);

        }
        public void Start()
        {
            while (player.Health > 0)
            {
                // Display room description
                Console.WriteLine("Please choose an action.");
                Console.WriteLine("1) View room description");
                Console.WriteLine("2) Battle an enemy");
                Console.WriteLine("3) Pickup an item");
                Console.WriteLine("4) Display stats");
                Console.WriteLine("5) Enter a new room");
                string action = Console.ReadLine();

                if (action == "1")
                {
                    // Display room description
                    Console.WriteLine(player.CurrentRoom.GetDescription());
                }

                else if (action == "2")
                {
                    // Battle an enemy, not yet implemented
                    Console.WriteLine("Not yet implemented.");
                }

                else if (action == "3")
                {
                    if (player.CurrentRoom.RoomItem != null)
                    {
                        // Pick up item
                        player.PickUpItem(player.CurrentRoom.RoomItem);
                        player.CurrentRoom.RoomItem = null;
                    }

                    else
                    {
                        Console.WriteLine("There is no item to pick up");
                    }
                }

                else if (action == "4")
                {
                    // Display player stats
                    Console.WriteLine($"Player: {player.Name}");
                    Console.WriteLine($"Health: {player.Health}");
                    Console.WriteLine($"Inventory: {player.InventoryContents()}");
                }

                else if (action == "5")
                {
                    // Move to a new room
                    Console.WriteLine("Which direction would you like to go?");
                    Console.WriteLine("1) North");
                    Console.WriteLine("2) East");
                    Console.WriteLine("3) South");
                    Console.WriteLine("4) West");
                    string direction = Console.ReadLine();

                    switch (direction)
                    {
                        case "1":
                            player.Move("north");
                            break;
                        case "2":
                            player.Move("east");
                            break;
                        case "3":
                            player.Move("south");
                            break;
                        case "4":
                            player.Move("west");
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
        }
    }
}