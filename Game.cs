using System;
using System.Media;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents the games main logic
    /// </summary>
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class
        /// Sets up the rooms, items, and player
        /// </summary>
        public Game()
        {
            // Create rooms
            Room room1 = new Room("A dark room with an exit to the North");
            Room room2 = new Room("A room with a goblin and an exit to the East");
            Room room3 = new Room("A room with a treasure chest");

            // Create items
            room1.CreateItem("Sword");
            room1.CreateItem("Shield");
            room3.CreateItem("Bag of coins");

            // Create enemies
            room2.AddEnemy("Goblin");

            // Instantiate room mappings
            room1.InstantiateMappings(north: room2);
            room2.InstantiateMappings(south: room1, east: room3);
            room3.InstantiateMappings(west: room2);

            // Create player and prompt for name
            Console.WriteLine("Enter player name");
            string playerName = Console.ReadLine();

            // Validate player name and ensure there are no empty names
            while (string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("Name cannot be empty. Please enter name again:");
                playerName = Console.ReadLine();
            }

            // Create player and enter the first room
            player = new Player(playerName, 100);
            player.EnterRoom(room1);

        }

        /// <summary>
        /// Starts the game loop
        /// The game will continue until the player's health reaches 0
        /// </summary>
        public void Start()
        {
            // Game loop to continue until player's health reaches 0
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

                // Perform action based on user input
                switch (action)
                {
                    case "1":
                        // Display room description
                        Console.WriteLine(player.CurrentRoom.GetDescription());
                        break;

                    case "2":
                        // Battle an enemy, not yet implemented
                        Console.WriteLine("Not yet implemented.");
                        break;

                    case "3":
                        if (player.CurrentRoom.RoomItems.Count > 0)
                        {
                            // Display room items
                            Console.WriteLine("Here are the available items in the room:");
                            for (int i = 0; i < player.CurrentRoom.RoomItems.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}) {player.CurrentRoom.RoomItems[i]}");
                            }

                            // Prompt user for item choice
                            Console.WriteLine("Enter the number of the item you would like to pick up");
                            string itemChoice = Console.ReadLine();
                            int itemIndex;

                            // Validate user input
                            if (int.TryParse(itemChoice, out itemIndex) && itemIndex > 0 && itemIndex <= player.CurrentRoom.RoomItems.Count)
                            {
                                // Add item to player inventory
                                player.PickUpItem(player.CurrentRoom.RoomItems[itemIndex - 1]);
                                player.CurrentRoom.RemoveItem(player.CurrentRoom.RoomItems[itemIndex - 1]);
                            }

                            else
                            {
                                Console.WriteLine("Invalid choice");
                            }
                        }

                        else
                        {
                            Console.WriteLine("There is no item to pick up");
                        }
                        break;

                    case "4":
                        // Display player stats
                        Console.WriteLine($"Player: {player.Name}");
                        Console.WriteLine($"Health: {player.Health}");
                        Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        break;

                    case "5":
                        // Prompt user for direction
                        Console.WriteLine("Which direction would you like to go?");
                        Console.WriteLine("1) North");
                        Console.WriteLine("2) East");
                        Console.WriteLine("3) South");
                        Console.WriteLine("4) West");

                        string direction = Console.ReadLine();

                        // Move player in specified direction
                        switch (direction)
                        {
                            case "1":
                                player.Move("North");
                                break;
                            case "2":
                                player.Move("East");
                                break;
                            case "3":
                                player.Move("South");
                                break;
                            case "4":
                                player.Move("West");
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}