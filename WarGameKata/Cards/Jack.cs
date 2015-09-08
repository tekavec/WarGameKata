namespace WarGameKata.Cards
{
    public struct Jack : ICard
    {
        private CardSuit _CardSuit;
        
        public static ICard Of(CardSuit cardSuit)
        {
            var jack = new Jack
            {
                _CardSuit = cardSuit
            };
            return jack;
        }

        public int Rank { get { return 11; } }
    }
}