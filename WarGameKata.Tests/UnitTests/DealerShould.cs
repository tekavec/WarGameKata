using Moq;
using NUnit.Framework;
using WarGameKata.Cards;

namespace WarGameKata.Tests.UnitTests
{
    [TestFixture]
    public class DealerShould
    {
        private Deck _Deck;
        private Mock<IShuffler> _Shuffler;
        private Dealer _Dealer;

        [TestFixtureSetUp]
        public void Init()
        {
            _Deck = new Deck( new[]
                {
                    King.Of(CardSuit.Hearts),
                    Jack.Of(CardSuit.Spades)
                });
            _Shuffler = new Mock<IShuffler>();
            _Dealer = new Dealer(_Shuffler.Object);
        }

        [Test]
        public void ShouldShuffleCards()
        {
            _Dealer.Shuffle(_Deck);
            _Shuffler.Verify(a => a.Shuffle(_Deck));
        }

        [Test]
        public void DealCardsToHands()
        {
            var hands = _Dealer.DealCards(_Deck, 2);
            Assert.AreEqual(1, hands.HandOne.Count);
            Assert.AreEqual(1, hands.HandTwo.Count);
        }
    }
}