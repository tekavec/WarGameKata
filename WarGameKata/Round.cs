using System.Collections.Generic;
using System.Linq;
using WarGameKata.Cards;
using WarGameKata.Players;

namespace WarGameKata
{
    public class Round
    {
        private readonly IDictionary<IPlayer, ICard> _Table = new Dictionary<IPlayer, ICard>();

        public int CardsOnTable
        {
            get { return _Table.Count; }
        }

        public void PutCardOnTable(IPlayer player, ICard card)
        {
            _Table.Add(player, card);
        }

        public void DetermineWinner()
        {
            var winner = WinnerOfRound();
            if (winner != null)
            {
                winner.PicksUpTheCards(_Table.Select(a => a.Value).ToList());
            }
        }

        private IPlayer WinnerOfRound()
        {
            IPlayer winner = null;
            int highestCard = 0;
            foreach (var cardOfPlayer in _Table)
            {
                if (cardOfPlayer.Value.Rank == highestCard)
                {
                    winner = null;
                }
                if (cardOfPlayer.Value.Rank > highestCard)
                {
                    highestCard = cardOfPlayer.Value.Rank;
                    winner = cardOfPlayer.Key;
                }
            }
            return winner;
        }

    }
}