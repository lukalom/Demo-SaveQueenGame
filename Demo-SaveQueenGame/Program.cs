namespace game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new GameController(new Player());
            game.Run();
        }

    }
}
