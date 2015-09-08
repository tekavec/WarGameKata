using System.Collections.Generic;
using WarGameKata.Cards;
using WarGameKata.Players;

namespace WarGameKata
{
    public interface IHands
    {
        void To(IPlayer playerOne, IPlayer playerTwo);
        IList<ICard> HandOne { get; set; }
        IList<ICard> HandTwo { get; set; }
    }
}