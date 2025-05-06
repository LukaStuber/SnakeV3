namespace Snake
{
    partial class Game
    {
        void DrawBoard(int[,] board)
        {
            Console.Clear();
            for (int y = 0; y < height / 2; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    Console.Write("▀");
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }

            if (height % 2 != 0)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.Write("▀");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }

        // Menus
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

        void DrawItems(Item[] items, int selected)
        {
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine();
                }

                if (selected == i)
                {
                    Console.CursorLeft = Console.WindowWidth / 2 - (items[i].Name.Length + 4) / 2;
                    Console.WriteLine($"[ {items[i].Name} ]");
                }
                else
                {
                    Console.CursorLeft = Console.WindowWidth / 2 - items[i].Name.Length / 2;
                    Console.WriteLine(items[i].Name);
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

            input = Console.ReadKey().Key;

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

            if (input == ConsoleKey.Enter)
            {
                switch (settingsBoardSelected)
                {
                    case 0:

                        break;
                    case 1:

                        break;
                    case 2:
                        gameState = GameState.Settings;
                        break;

                }
                settingsSelected = 0;
            }
        }
    }
}
