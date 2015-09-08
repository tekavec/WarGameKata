using Moq;
using NUnit.Framework;
using WarGameKata.Cards;
using WarGameKata.Extensions;
using WarGameKata.Players;

namespace WarGameKata.Tests.UnitTests
{
    [TestFixture]
    public class RoundShould
    {
        private Round _Round;
        private TwoPlayers _Players;

        [SetUp]
        public void Init()
        {
            _Players = new TwoPlayers();
            _Round = new Round();
        }

        [Test]
        public void PutACardOnATable()
        {
            var kingOfSpades = new King();
            _Round.PutCardOnTable(_Players.PlayerOne, kingOfSpades);

            Assert.AreEqual(1, _Round.CardsOnTable);
        }

        [Test]
        public void DetermineAWinnerIfOnePlayerHasBetterCardThanTheOther()
        {
            var shuffler = new Mock<IShuffler>();

            var dealer = new Dealer(shuffler.Object);
            var deck = new Deck(new[]
            {
                King.Of(CardSuit.Hearts), 
                Jack.Of(CardSuit.Spades)
            });
            shuffler.Setup(a => a.Shuffle(deck)).Returns(new[]
            {
                Jack.Of(CardSuit.Spades),
                King.Of(CardSuit.Hearts)
            });
            dealer.Shuffle(deck);
            dealer.DealCards(deck, 2).To(_Players.PlayerOne, _Players.PlayerTwo);
            _Players.PlayerOne.RevealsTopCardIn(_Round);
            _Players.PlayerTwo.RevealsTopCardIn(_Round);

            _Round.DetermineWinner();

            Assert.That(_Players.PlayerOne.Hand().IsEmpty());
            Assert.That(_Players.PlayerTwo.Hand().Count, Is.EqualTo(2));
        }

        [Test]
        public void DoesntDetermineAWinnerIfBothPlayersHasCardsWithEqualRank()
        {
            var shuffler = new Mock<IShuffler>();

            var dealer = new Dealer(shuffler.Object);
            var deck = new Deck(new[]
            {
                Jack.Of(CardSuit.Hearts), 
                Jack.Of(CardSuit.Spades)
            });
            shuffler.Setup(a => a.Shuffle(deck)).Returns(new[]
            {
                Jack.Of(CardSuit.Spades),
                Jack.Of(CardSuit.Hearts)
            });
            dealer.Shuffle(deck);
            dealer.DealCards(deck, 2).To(_Players.PlayerOne, _Players.PlayerTwo);
            _Players.PlayerOne.RevealsTopCardIn(_Round);
            _Players.PlayerTwo.RevealsTopCardIn(_Round);

            _Round.DetermineWinner();

            Assert.That(_Players.PlayerOne.Hand().IsEmpty());
            Assert.That(_Players.PlayerTwo.Hand().IsEmpty());
        }
    }
}