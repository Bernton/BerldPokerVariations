using System.Collections.ObjectModel;

namespace BerldPokerLibrary.HandEvaluation
{
    public class Flush : HandValue, IComparable<HandValue>, IComparable<Flush>
    {
        /// <summary>
        /// The 5 ranks, always sorted ascending
        /// </summary>
        internal ReadOnlyCollection<Rank> Ranks => _ranks.AsReadOnly();

        private readonly List<Rank> _ranks;

        private Flush(IEnumerable<Rank> ranks)
        {
            _ranks = ranks.ToList();
        }

        internal new static Flush? Determine(IEnumerable<Card> cards)
        {
            IEnumerable<Card>? flushCards = DetermineFlushCards(cards);

            if (flushCards is not null)
            {
                List<Rank> ranks = flushCards.Select(c => c.Rank).OrderBy(c => c).TakeLast(5).ToList();
                return new Flush(ranks);
            }

            return null;
        }

        public override int CompareTo(HandValue? other)
        {
            if (other is Flush otherFlush)
            {
                return CompareTo(otherFlush);
            }

            return base.CompareTo(other);
        }

        public int CompareTo(Flush? other)
        {
            if (other is null)
            {
                return 1;
            }

            for (int i = _ranks.Count - 1; i >= 0; i--)
            {
                int rankComparison = _ranks[i] - other._ranks[i];

                if (rankComparison != 0)
                {
                    return rankComparison;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            return $"{ToShortString()} with {_ranks[3]}, {_ranks[2]}, {_ranks[1]} and {_ranks[0]}";
        }

        public override string ToShortString()
        {
            Rank highestRank = _ranks[^1];
            return $"{highestRank} high flush";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_ranks[0], _ranks[1], _ranks[2], _ranks[3], _ranks[4]);
        }
    }
}