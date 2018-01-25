namespace ConsoleApp1
{
    public class TicTacToe : IGame
    {
        private string _status;

        public TicTacToe()
        {
            Name = "Tres en Raya";
            CurrentPlayers = 0;
            MinPlayers = 2;
            MaxPlayers = 2;
            _status = "Sin juego activo";
        }

        #region IGame Members

        public string Name { get; set; }

        public int CurrentPlayers { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public void addPlayer()
        {
            CurrentPlayers++;
        }

        public void removePlayer()
        {
            CurrentPlayers--;
        }

        public void play()
        {
            if ((CurrentPlayers > MaxPlayers) || (CurrentPlayers < MinPlayers))
                _status = string.Format("{0}: No es posible jugar con {1} jugadores.", Name, CurrentPlayers);
            else
                _status = string.Format("{0}: Jugando con {1} jugadores.", Name, CurrentPlayers);
        }

        public string result()
        {
            return _status;
        }

        #endregion
    }
}
