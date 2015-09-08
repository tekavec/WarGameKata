using System;
using System.Linq;
using WarGameKata.Cards;

namespace WarGameKata
{
    public class Shuffler : IShuffler
    {
        public ICard[] Shuffle(Deck deck)
        {
            return deck.Cards.OrderBy(a => Guid.NewGuid()).ToArray();
        }
    }
}