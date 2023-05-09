using System.Collections.ObjectModel;

namespace BerldPokerLibrary.HandEvaluation
{
    public class Pair : HandValue, IComparable<HandValue>, IComparable<Pair>
    {
        internal Rank Rank { get; }

        /// <summary>
        /// The 3 kickers, always sorted ascending
        /// </summary>
        internal ReadOnlyCollection<Rank> Kickers => _kickers.AsReadOnly();

        private readonly List<Rank> _kickers;

        private Pair(Rank rank, IEnumerable<Rank> kickers)
        {
            Rank = rank;
            _kickers = kickers.ToList();
        }

        internal new static Pair? Determine(IEnumerable<Card> cards)
        {
            Rank? pairRank = null;
            Rank? bestKicker = null;
            Rank? secondBestKicker = null;
            Rank? thirdBestKicker = null;

            for (int i = RankExtensions.RankAmount - 1; i >= 0; i--)
            {
                Rank rank = (Rank)i;
                IEnumerable<Card> cardsOfRank = cards.Where(c => c.Rank == rank);

                if (!pairRank.HasValue && cardsOfRank.Count() == 2)
                {
                    pairRank = rank;
                }
                else if (!bestKicker.HasValue && cardsOfRank.Any())
                {
                    bestKicker = rank;
                }
                else if (!secondBestKicker.HasValue && cardsOfRank.Any())
                {
                    secondBestKicker = rank;
                }
                else if (!thirdBestKicker.HasValue && cardsOfRank.Any())
                {
                    thirdBestKicker = rank;
                }

                if (pairRank.HasValue &&
                    bestKicker.HasValue &&
                    secondBestKicker.HasValue &&
                    thirdBestKicker.HasValue)
                {
                    return new Pair(pairRank.Value, new List<Rank>
                    {
                        thirdBestKicker.Value,
                        secondBestKicker.Value,
                        bestKicker.Value
                    });
                }
            }

            return null;
        }

        public override int CompareTo(HandValue? other)
        {
            if (other is Pair otherPair)
            {
                return CompareTo(otherPair);
            }

            return base.CompareTo(other);
        }

        public int CompareTo(Pair? other)
        {
            if (other is null)
            {
                return 1;
            }

            int rankComparison = Rank - other.Rank;

            if (rankComparison != 0)
            {
                return rankComparison;
            }

            for (int i = _kickers.Count - 1; i >= 0; i--)
            {
                int kickerComparison = _kickers[i] - other._kickers[i];

                if (kickerComparison != 0)
                {
                    return kickerComparison;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            return $"{ToShortString()} with {_kickers[2]}, {_kickers[1]} and {_kickers[0]} kickers";
        }

        public override string ToShortString()
        {
            return $"Pair of {Rank.ToPlural()}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rank, _kickers[0], _kickers[1], _kickers[2]);
        }
    }
}
