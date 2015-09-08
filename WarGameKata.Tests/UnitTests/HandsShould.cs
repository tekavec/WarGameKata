using NUnit.Framework;
using WarGameKata.Cards;
using WarGameKata.Players;

namespace WarGameKata.Tests.UnitTests
{
    [TestFixture]
    public class HandsShould
    {

        [Test]
        public void BePickedByPlayers()
        {
            var players = new TwoPlayers();
            var hands = new Hands();
            hands.HandOne.Add(Jack.Of(CardSuit.Spades));
            hands.HandTwo.Add(King.Of(CardSuit.Hearts));

            hands.To(players.PlayerOne, players.PlayerTwo);

            Assert.AreEqual(1, players.PlayerOne.Hand().Count);
            Assert.AreEqual(1, players.PlayerTwo.Hand().Count);
        }
         
    }
}