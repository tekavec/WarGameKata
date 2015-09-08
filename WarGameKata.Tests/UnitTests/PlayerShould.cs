using System.Collections.Generic;
using NUnit.Framework;
using WarGameKata.Cards;
using WarGameKata.Players;

namespace WarGameKata.Tests.UnitTests
{
    [TestFixture]
    public class PlayerShould
    {
        private Player _PlayerOne;
        private Round _Round;

        [SetUp]
        public void Init()
        {
            _PlayerOne = new Player();
            _Round = new Round();
        }

        [Test]
        public void RevealsHisTopCardInTheRound()
        {
            var jackOfSpades = Jack.Of(CardSuit.Spades);
            _PlayerOne.Hand().Push(jackOfSpades);
            var kingOfHearts = King.Of(CardSuit.Hearts);
            _PlayerOne.Hand().Push(kingOfHearts);
            
            _PlayerOne.RevealsTopCardIn(_Round);

            Assert.That(_PlayerOne.Hand().Count == 1);
            Assert.That(_Round.CardsOnTable == 1);
            Assert.That(_PlayerOne.Hand().Peek(), Is.EqualTo(jackOfSpades));
        }

        [Test]
        public void NotRevealHisTopCardInTheRoundIfHisHandIsEmpty()
        {
            _PlayerOne.RevealsTopCardIn(_Round);

            Assert.AreEqual(0, _Round.CardsOnTable);
        }

        [Test]
        public void PickUpTheCards()
        {
            var cards = new List<ICard>
            {
                Jack.Of(CardSuit.Spades), 
                King.Of(CardSuit.Hearts)
            };

            _PlayerOne.PicksUpTheCards(cards);

            Assert.That(_PlayerOne.Hand().Count == 2);
        }
    }
}