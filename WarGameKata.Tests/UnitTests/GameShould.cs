using NUnit.Framework;
using WarGameKata.Players;

namespace WarGameKata.Tests.UnitTests
{
    [TestFixture]
    public class GameShould
    {
        private Game _Game;

        [TestFixtureSetUp]
        public void Init()
        {
            _Game = new Game(
                new TwoPlayers());
        }

        [Test]
        public void CreateANewDealer()
        {
            IShuffler shuffler = new Shuffler();

            Assert.That(_Game.NewDealer(shuffler), Is.TypeOf(typeof(Dealer)));
        }

        [Test]
        public void CreateNextRound()
        {
            Assert.That(_Game.NextRound(), Is.TypeOf(typeof(Round)));
        }
    }
}