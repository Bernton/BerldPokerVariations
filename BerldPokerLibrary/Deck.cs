using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace BerldPokerLibrary
{
    public class Deck
    {
        public static readonly int CardAmount = RankExtensions.RankAmount * SuitExtensions.SuitAmount;

        public int AliveCardAmount => _aliveCardAmount;

        public ReadOnlyCollection<Card> Cards
        {
            get { return _cards.AsReadOnly(); }
        }

        private readonly int _aliveCardAmount;
        private List<Card> _cards = new();
        private readonly List<Card> _deadCards;

        public Deck()
        {
            _aliveCardAmount = CardAmount;
            _deadCards = new List<Card>();
            ArrangeInitially();
            Shuffle();
        }

        public Deck(IEnumerable<Card> deadCards)
        {
            _deadCards = deadCards.ToList();
            _aliveCardAmount = CardAmount - _deadCards.Count;
            ArrangeInitially();
            Shuffle();
        }

        private void ArrangeInitially()
        {
            _cards.Clear();

            for (int i = 0; i < CardAmount; i++)
            {
                Card card = new()
                {
                    Rank = (Rank)(i / SuitExtensions.SuitAmount),
                    Suit = (Suit)(i % SuitExtensions.SuitAmount)
                };

                if (!_deadCards.Contains(card))
                {
                    _cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            Card[] cards = new Card[AliveCardAmount];
            List<int> availableIndexes = new();

            for (int i = 0; i < AliveCardAmount; i++)
            {
                availableIndexes.Add(i);
            }

            for (int i = 0; i < AliveCardAmount; i++)
            {
                int chosenIndex = RandomNumberGenerator.GetInt32(availableIndexes.Count);
                int availableIndex = availableIndexes[chosenIndex];

                cards[availableIndex] = _cards[i];

                availableIndexes.RemoveAt(chosenIndex);
            }

            _cards = cards.ToList();
        }

        public Card this[int i]
        {
            get { return _cards[i]; }
        }
    }
}
