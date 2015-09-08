using WarGameKata.Extensions;
using WarGameKata.Players;

namespace WarGameKata
{
    public class Game
    {
        private readonly TwoPlayers _Players;

        public Game(TwoPlayers players)
        {
            _Players = players;
        }

        public IPlayer Winner
        {
            get
            {
                if (_Players.PlayerOne.Hand().IsEmpty())
                {
                    return _Players.PlayerTwo;
                }
                if (_Players.PlayerTwo.Hand().IsEmpty())
                {
                    return _Players.PlayerOne;
                }
                return null;
            }
        }

        public Round NextRound()
        {
            return new Round();
        }


        public Dealer NewDealer(IShuffler shuffler)
        {
            return new Dealer(shuffler);
        }
    }
}