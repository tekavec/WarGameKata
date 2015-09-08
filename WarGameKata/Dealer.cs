namespace WarGameKata
{
    public class Dealer
    {
        private Deck _Deck;
        private IShuffler _Shuffler;

        public Dealer(IShuffler shuffler)
        {
            _Shuffler = shuffler;
        }

        public void Shuffle(Deck deck)
        {
            _Deck = deck;
            _Shuffler.Shuffle(deck);
        }

        public IHands DealCards(Deck deck, int numberOfPlayers)
        {
            var hands = new Hands();
            int count = deck.Cards.Count;
            for (int i = 0; i < count; i = i+numberOfPlayers)
            {
                hands.HandOne.Add(deck.Cards.Pop());
                hands.HandTwo.Add(deck.Cards.Pop());
            }
            return hands;
        }
    }
}