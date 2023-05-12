using BerldPokerLibrary.HandEvaluation;

namespace BerldPokerLibrary.Omaha
{
    public class OmahaHand
    {
        internal const int HoleCardAmount = 4;
        internal const int CommunityCardAmount = 5;

        private static readonly List<(int First, int Second)> _possibleHoleCardIndexes;

        static OmahaHand()
        {
            _possibleHoleCardIndexes = new List<(int first, int second)>
            {
                (0, 1),
                (0, 2),
                (0, 3),
                (1, 2),
                (1, 3),
                (2, 3),
            };
        }

        public static HandValue Determine(IEnumerable<Card> holeCards, IEnumerable<Card> communityCards)
        {
            if (holeCards is null || holeCards.Count() != HoleCardAmount)
            {
                throw new ArgumentOutOfRangeException(nameof(holeCards), $"There must be {HoleCardAmount} cards.");
            }

            if (communityCards is null || communityCards.Count() != CommunityCardAmount)
            {
                throw new ArgumentOutOfRangeException(nameof(communityCards), $"There must be {CommunityCardAmount} cards.");
            }

            return Determine(holeCards.ToList(), communityCards.ToList());
        }

        private static HandValue Determine(List<Card> holeCards, List<Card> communityCards)
        {
            HandValue? bestHandValue = null;

            foreach ((int first, int second) in _possibleHoleCardIndexes)
            {
                List<Card> cards = new()
                {
                    holeCards[first],
                    holeCards[second]
                };

                cards.AddRange(communityCards);

                HandValue handValue = HandValue.Determine(cards);

                if (bestHandValue is null || handValue.CompareTo(bestHandValue) > 0)
                {
                    bestHandValue = handValue;
                }
            }

            if (bestHandValue is null)
            {
                throw new Exception($"{bestHandValue} must not be null here.");
            }

            return bestHandValue;
        }
    }
}
