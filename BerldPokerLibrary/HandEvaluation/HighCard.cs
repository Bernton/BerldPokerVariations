using System.Collections.ObjectModel;

namespace BerldPokerLibrary.HandEvaluation
{
    public class HighCard : HandValue, IComparable<HandValue>, IComparable<HighCard>
    {
        /// <summary>
        /// The 5 ranks, always sorted ascending
        /// </summary>
        internal ReadOnlyCollection<Rank> Ranks => _ranks.AsReadOnly();

        private readonly List<Rank> _ranks;

        private HighCard(IEnumerable<Rank> ranks)
        {
            _ranks = ranks.ToList();
        }

        internal new static HighCard Determine(IEnumerable<Card> cards)
        {
            List<Rank> ranks = cards.Select(c => c.Rank).OrderBy(c => c).TakeLast(5).ToList();
            return new HighCard(ranks);
        }

        public override int CompareTo(HandValue? other)
        {
            if (other is HighCard otherHighCard)
            {
                return CompareTo(otherHighCard);
            }

            return base.CompareTo(other);
        }

        public int CompareTo(HighCard? other)
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
            return $"{highestRank} high";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_ranks[0], _ranks[1], _ranks[2], _ranks[3], _ranks[4]);
        }
    }
}