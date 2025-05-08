namespace Snake
{
    partial class Game
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
            Pause,
            GameOver,
            GameWon,
            Quit
        }

        struct Snake
        {
            public int X;
            public int Y;
            public int Length;
        }

        struct Item
        {
            public string Name;
            public bool IsField;

            public Item(string name)
            {
                Name = name;
                IsField = false;
            }

            public Item(string name, bool isField)
            {
                Name = name;
                IsField = isField;
            }
        }

        GameState gameState;
        int[,] board;
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
        readonly Item[] mainMenuItems = [new Item("Play"), new Item("Settings"), new Item("Leaderboard"), new Item("Quit")];    
        int mainMenuSelected = 0; // 0 = play, 1 = settings, 2 = quit
        readonly Item[] settingsItems = [new Item("Board"), new Item("Snake"), new Item("Apples"), new Item("Back")];
        int settingsSelected = 0; // 0 = board, 1 = snake, 2 = apples
        readonly Item[] settingsBoardItems = [new Item("Width: [ ]", true), new Item("Height: [ ]", true), new Item("Back")];
        int settingsBoardSelected = 0; // 0 = width, 1 = height, 2 = back
        readonly int minWidth = 4;
        readonly int minHeight = 3;  
        int width = 10;
        int height = 9;
        int startingLength = 3;
        int tempSnakeInit = 1;
        ConsoleKey input;
        Snake snake;

        void StartGame()
        {
            board = new int[width, height];
            snake.X = startingLength;
            snake.Y = height / 2;
            snake.Length = startingLength;

            for (int i = startingLength; i >= 0; i--)
            {
                board[i, snake.Y] = tempSnakeInit;
                tempSnakeInit++;
            }

            gameState = GameState.Playing;
        }

        void GameTick()
        {
            DrawBoardPerformance(board);
            Console.ReadLine();
        }

        public void Run()
        {
            Console.Title = "Snake";
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
                        StartGame();
                        break;
                    case GameState.Playing:
                        GameTick();
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
