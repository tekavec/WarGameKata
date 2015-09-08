namespace WarGameKata.Players
{
    public class TwoPlayers
    {
        private IPlayer _PlayerOne = new Player();
        private IPlayer _PlayerTwo = new Player();

        public IPlayer PlayerOne
        {
            get { return _PlayerOne; }
            set { _PlayerOne = value; }
        }

        public IPlayer PlayerTwo
        {
            get { return _PlayerTwo; }
            set { _PlayerTwo = value; }
        }
    }
}