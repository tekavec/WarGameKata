using System.Collections.Generic;
using WarGameKata.Cards;

namespace WarGameKata
{
    public class Deck
    {
        readonly Stack<ICard> _Cards = new Stack<ICard>();

        public Deck(IEnumerable<ICard> cards)
        {
            foreach (var card in cards)
            {
                _Cards.Push(card);
            }
        }

        public Stack<ICard> Cards
        {
            get { return _Cards; }
        }
    }
}