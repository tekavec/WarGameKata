using WarGameKata.Cards;

namespace WarGameKata
{
    public interface IShuffler
    {
        ICard[] Shuffle(Deck deck);
    }
}