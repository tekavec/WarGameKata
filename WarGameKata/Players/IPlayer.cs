using System.Collections.Generic;
using WarGameKata.Cards;

namespace WarGameKata.Players
{
    public interface IPlayer
    {
        Stack<ICard> Hand();
        void RevealsTopCardIn(Round round);
        void PicksUpTheCards(List<ICard> cards);
    }
}