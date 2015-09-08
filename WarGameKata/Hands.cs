using System.Collections.Generic;
using WarGameKata.Cards;
using WarGameKata.Players;

namespace WarGameKata
{
    public class Hands : IHands
    {
        private IList<ICard> _HandOne = new List<ICard>();
        private IList<ICard> _HandTwo = new List<ICard>();

        public void To(IPlayer playerOne, IPlayer playerTwo)
        {
            foreach (var card in _HandOne)
            {
                playerOne.Hand().Push(card);
            }
            foreach (var card in _HandTwo)
            {
                playerTwo.Hand().Push(card);
            }
        }

        public IList<ICard> HandOne
        {
            get { return _HandOne; }
            set { _HandOne = value; }
        }

        public IList<ICard> HandTwo
        {
            get { return _HandTwo; }
            set { _HandTwo = value; }
        }
    }
}