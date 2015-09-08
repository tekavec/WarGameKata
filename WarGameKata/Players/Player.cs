using System.Collections.Generic;
using WarGameKata.Cards;

namespace WarGameKata.Players
{
    public class Player : IPlayer
    {
        private readonly Stack<ICard> _Cards = new Stack<ICard>();

        public Stack<ICard> Hand()
        {
            return _Cards;
        }

        public void RevealsTopCardIn(Round round)
        {
            if (_Cards.Count > 0)
            {
                round.PutCardOnTable(this, _Cards.Pop());
            }
        }

        public void PicksUpTheCards(List<ICard> cards)
        {
            foreach (var card in cards)
            {
                Hand().Push(card);
            }
        }
    }


}