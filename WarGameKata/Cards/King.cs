namespace WarGameKata.Cards
{
    public struct King : ICard
    {
        private CardSuit _CardSuit;

        public int Rank { get { return 13; } }

        public static ICard Of(CardSuit cardSuit)
        {
            var king = new King
            {
                _CardSuit = cardSuit
            };
            return king;
        }
    }
}