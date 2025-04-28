namespace Snake
{
    class Game
    {
        enum GameState
        {
            MainMenu,
            Settings,
            Playing,
            GameOver,
            GameWon,
            Quit
        }

        private struct Snake
        {
            public int x;
            public int y;
            public int length;
        }

        private struct Version
        {
            public int major;
            public int minor;
            public int patch;
        }

        private GameState gameState;

        private Version version;
        version.major = 0;
        version.minor = 0;
        version.patch = 0;


        

        private void MainMenu()
        {
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("hi");
        }

        public void Run()
        {
            gameState = GameState.MainMenu;
            switch (gameState)
            {
                case GameState.MainMenu:
                    MainMenu();
                    break;

            }
        }
    }
}
