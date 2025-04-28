using Snake;

class Program
{
    static void Main() 
    {
        Console.Write("eingabe: ");
        Console.WriteLine(new string('-', Console.WindowWidth));


        Game game = new Game();
        game.Run();
        Console.ReadKey();
    }
}