using Moq;
using NUnit.Framework;
using WarGameKata.Cards;
using WarGameKata.Extensions;
using WarGameKata.Players;

namespace WarGameKata.Tests
{
//given two players
//the deck is shuffled
//where player one is dealt a face-down hand containing:
//  - Jack of Spades
//and player two is dealt a face-down hand containing:
//  - King of Hearts
//player one will play the first card in their hand,
//which is the Jack of Spades
//then player two will play the first card in their hand,
//which is the King of Hearts
//player two wins the round
//player two picks up the cards
//player one has no cards left, so player two wins
    [TestFixture]
    public class WarGameKataTest
    {
        private Deck _Deck;
        private TwoPlayers _Players;
        private Game _Game;

        [TestFixtureSetUp]
        public void Init()
        {
            _Deck = new Deck(
                new[]
                {
                    King.Of(CardSuit.Hearts),
                    Jack.Of(CardSuit.Spades)
                }
                );
            _Players = new TwoPlayers();
            _Game = new Game(_Players);
        }

        [Test]
        public void TwoPlayersWithOneCardEach()
        {
            ShuffleAndDeal(_Deck, 2);

            Assert.That(_Players.PlayerOne.Hand(), Contains.Item(Jack.Of(CardSuit.Spades)));
            Assert.That(_Players.PlayerTwo.Hand(), Contains.Item(King.Of(CardSuit.Hearts)));

            var round = _Game.NextRound();

            _Players.PlayerOne.RevealsTopCardIn(round);
            _Players.PlayerTwo.RevealsTopCardIn(round);
            round.DetermineWinner();

            Assert.That(_Players.PlayerOne.Hand().IsEmpty());
            Assert.That(_Players.PlayerTwo.Hand().Count == 2);
            Assert.That(_Players.PlayerTwo.Hand().Contains(Jack.Of(CardSuit.Spades)));
            Assert.That(_Players.PlayerTwo.Hand().Contains(King.Of(CardSuit.Hearts)));

            Assert.That(_Game.Winner == _Players.PlayerTwo);
        }

        private void ShuffleAndDeal(Deck deck, int count)
        {
            var shuffler = new Mock<IShuffler>();
            shuffler.Setup(a => a.Shuffle(deck)).Returns(
                new[]
                {
                    Jack.Of(CardSuit.Spades),
                    King.Of(CardSuit.Hearts)
                });
            Dealer dealer = _Game.NewDealer(shuffler.Object);
            dealer.Shuffle(deck);
            dealer.DealCards(deck, count).To(_Players.PlayerOne, _Players.PlayerTwo);
        }

    }
}