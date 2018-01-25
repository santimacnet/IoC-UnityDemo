namespace ConsoleApp1
{
    public class Tablero
    {
        private IGame game;

        public Tablero(IGame game)
        {
            this.game = game;
        }

        public string GameStatus()
        {
            return game.result();
        }

        public void AddPlayer()
        {
            game.addPlayer();
        }

        public void RemovePlayer()
        {
            game.removePlayer();
        }

        public void Play()
        {
            game.play();
        }
    }
}
