using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace BerldPokerLibrary
{
    public class Deck
    {
        public static readonly int CardAmount = RankExtensions.RankAmount * SuitExtensions.SuitAmount;

        internal ReadOnlyCollection<Card> Cards
        {
            get { return _cards.ToList().AsReadOnly(); }
        }

        private Card[] _cards = new Card[CardAmount];

        public Deck()
        {
            ArrangeInitially();
            Shuffle();
        }

        private void ArrangeInitially()
        {
            for (int i = 0; i < CardAmount; i++)
            {
                _cards[i] = new Card()
                {
                    Rank = (Rank)(i / SuitExtensions.SuitAmount),
                    Suit = (Suit)(i % SuitExtensions.SuitAmount)
                };
            }
        }

        internal void Shuffle()
        {
            Card[] cards = new Card[CardAmount];

            List<int> availableIndexes = new();

            for (int i = 0; i < CardAmount; i++)
            {
                availableIndexes.Add(i);
            }

            for (int i = 0; i < CardAmount; i++)
            {
                int chosenIndex = RandomNumberGenerator.GetInt32(availableIndexes.Count);
                int availableIndex = availableIndexes[chosenIndex];

                cards[availableIndex] = _cards[i];

                availableIndexes.RemoveAt(chosenIndex);
            }

            _cards = cards;
        }

        public Card this[int i]
        {
            get { return _cards[i]; }
        }
    }
}
