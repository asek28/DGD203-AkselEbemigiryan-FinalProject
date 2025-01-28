using MidTerm;
using System;

namespace MidTerm
{
    public class MainMenu
    {
        private GameController _controller; 
        private SaveManager _saveManager;
        private Inventory _inventory; 
        private int[,] _map; 
        private int[,] _map2; 
        private int _playerX; 
        private int _playerY; 

        public MainMenu()
        {
            _controller = new GameController();
            _saveManager = new SaveManager();
            _inventory = new Inventory();
            _map = new int[,] {  }; 
            _map2 = new int[,] {  }; 
            _playerX = 1;
            _playerY = 1;
        }
        public void ShowMenu()
        {
            bool menuActive = true;

            while (menuActive)
            {
                Console.Clear();
                Console.WriteLine("---- Main Menu ----");
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Load Game");
                Console.WriteLine("3. Credits");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StartGame();
                        menuActive = false;  // Oyun başlatıldıktan sonra menüyü kapat
                        break;
                    case "2":
                        LoadGame();
                        menuActive = false;  // Yükleme işlemi yapıldıktan sonra menüyü kapat
                        break;
                    case "3":
                        ShowCredits();
                        break;
                    case "4":
                        Console.WriteLine("Exiting game...");
                        menuActive = false;  // Çıkış yapılacak
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        private void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Starting the game...");
            _controller.StartGame(_playerX, _playerY, _inventory, _map, _map2); 
        }

        private void LoadGame()
        {
            // Load the game logic here
            Console.Clear();
            SaveManager saveManager = new SaveManager();
            SaveData loadedData = saveManager.LoadGame("save.json");

            if (loadedData != null)
            {
                Console.WriteLine("Game loaded successfully!");
                _playerX = loadedData.PlayerX;
                _playerY = loadedData.PlayerY;
                _inventory = loadedData.Inventory;
                _map = loadedData.Map;
                _map2 = loadedData.Map2;

                _controller.StartGame(_playerX, _playerY, _inventory, _map, _map2);
                
            }
            else
            {
                Console.WriteLine("No saved game found. Starting a new game.");
                StartGame();
                // Kaydedilmiş oyun yoksa yeni oyun başlatılabilir.
            }
        }

        private void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("=== Credits ===");
            Console.WriteLine("Game developed by: Aksel Ebemıgıryan");
            Console.WriteLine("Special thanks to: OpenAI for assistance(for this MainMenu class codes).");
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
