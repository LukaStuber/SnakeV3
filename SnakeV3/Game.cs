using System.ComponentModel;

namespace Snake
{
    class Game
    {
        enum GameState
        {
            MainMenu,
            Settings,
            SettingsBoard,
            SettingsSnake,
            SettingsApples,
            Start,
            Playing,
            GameOver,
            GameWon,
            Quit
        }

        struct Snake
        {
            public int x;
            public int y;
            public int length;
        }

        GameState gameState;
        int[,] board;
        readonly string version = "0.1.0";
        readonly string[] title =
        [
            "   ▄████████ ███▄▄▄▄      ▄████████    ▄█   ▄█▄    ▄████████",
            "  ███    ███ ███▀▀▀██▄   ███    ███   ███ ▄███▀   ███    ███",
            "  ███    █▀  ███   ███   ███    ███   ███▐██▀     ███    █▀ ",
            "  ███        ███   ███   ███    ███  ▄█████▀     ▄███▄▄▄    ",
            "▀███████████ ███   ███ ▀███████████ ▀▀█████▄    ▀▀███▀▀▀    ",
            "         ███ ███   ███   ███    ███   ███▐██▄     ███    █▄ ",
            "   ▄█    ███ ███   ███   ███    ███   ███ ▀███▄   ███    ███",
            " ▄████████▀   ▀█   █▀    ███    █▀    ███   ▀█▀   ██████████"
        ];
        readonly string[] mainMenuItems = ["Play", "Settings", "Quit"];    
        int mainMenuSelected = 0; // 0 = play, 1 = settings, 2 = quit
        readonly string[] settingsItems = ["Board", "Snake", "Apples", "Back"];
        int settingsSelected = 0; // 0 = board, 1 = snake, 2 = apples
        readonly string[] settingsBoardItems = ["Width", "Height"];
        int settingsBoardSelected = 0; // 0 = width, 1 = height
        ConsoleKey input;

        void DrawTitle()
        {
            for (int i = 0; i < title.Length; i++)
            {
                Console.CursorLeft = Console.WindowWidth / 2 - title[i].Length / 2;
                Console.ForegroundColor = i % 2 == 0 ? ConsoleColor.Red : ConsoleColor.DarkRed;
                Console.WriteLine(title[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        void DrawItems(string[] items, int selected)
        {
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine();
                }

                if (selected == i)
                {
                    Console.CursorLeft = Console.WindowWidth / 2 - (items[i].Length + 4) / 2;
                    Console.WriteLine($"[ {items[i]} ]");
                }
                else
                {
                    Console.CursorLeft = Console.WindowWidth / 2 - items[i].Length / 2;
                    Console.WriteLine(items[i]);
                }
            }
        }

        void DrawMainMenu()
        {
            Console.Clear();
            DrawTitle();
            DrawItems(mainMenuItems, mainMenuSelected);

            Console.ForegroundColor = ConsoleColor.White;
            input = Console.ReadKey(true).Key;

            if (input == ConsoleKey.DownArrow)
            {
                if (mainMenuSelected == mainMenuItems.Length - 1)
                {
                    mainMenuSelected = 0;
                }
                else
                {
                    mainMenuSelected++;
                }
            }
            else if (input == ConsoleKey.UpArrow)
            {
                if (mainMenuSelected == 0)
                {
                    mainMenuSelected = mainMenuItems.Length - 1;
                }
                else
                {
                    mainMenuSelected--;
                }
            }

            if (input == ConsoleKey.Enter)
            {
                switch (mainMenuSelected)
                {                   
                    case 0:
                        gameState = GameState.Start;
                        break;
                    case 1:
                        gameState = GameState.Settings;
                        break;
                    case 2:
                        gameState = GameState.Quit;
                        break;
                }
                mainMenuSelected = 0;
            }
        }

        void DrawSettings()
        {
            Console.Clear();
            DrawTitle();
            DrawItems(settingsItems, settingsSelected);

            input = Console.ReadKey(true).Key;

            if (input == ConsoleKey.DownArrow)
            {
                if (settingsSelected == settingsItems.Length - 1)
                {
                    settingsSelected = 0;
                }
                else
                {
                    settingsSelected++;
                }
            }
            else if (input == ConsoleKey.UpArrow)
            {
                if (settingsSelected == 0)
                {
                    settingsSelected = settingsItems.Length - 1;
                }
                else
                {
                    settingsSelected--;
                }
            }

            if (input == ConsoleKey.Enter)
            {
                switch (settingsSelected)
                {
                    case 0:
                        gameState = GameState.SettingsBoard;
                        break;
                    case 1:
                        gameState = GameState.SettingsSnake;
                        break;
                    case 2:
                        gameState = GameState.SettingsApples;
                        break;
                    case 3:
                        gameState = GameState.MainMenu;
                        break;
                }
                settingsSelected = 0;
            }
        }

        void DrawSettingsBoard()
        {
            Console.Clear();
            DrawTitle();
            DrawItems(settingsBoardItems, settingsBoardSelected);

            if (input == ConsoleKey.DownArrow)
            {
                if (settingsBoardSelected == settingsBoardItems.Length - 1)
                {
                    settingsBoardSelected = 0;
                }
                else
                {
                    settingsBoardSelected++;
                }
            }
            else if (input == ConsoleKey.UpArrow)
            {
                if (settingsBoardSelected == 0)
                {
                    settingsBoardSelected = settingsBoardItems.Length - 1;
                }
                else
                {
                    settingsBoardSelected--;
                }
            }
        }

        public void Run()
        {
            gameState = GameState.MainMenu;
            while (gameState != GameState.Quit)
            {
                switch (gameState)
                {
                    case GameState.MainMenu:
                        DrawMainMenu();
                        break;
                    case GameState.Settings:
                        DrawSettings();
                        break;
                    case GameState.SettingsBoard:
                        DrawSettingsBoard();
                        break;
                    case GameState.SettingsSnake:
                        break;
                    case GameState.SettingsApples:
                        break;
                    case GameState.Start:
                        break;
                    case GameState.Playing:
                        break;
                    case GameState.GameOver:
                        break;
                    case GameState.GameWon:
                        break;
                    default: break;
                }
            }
        }
    }
}
