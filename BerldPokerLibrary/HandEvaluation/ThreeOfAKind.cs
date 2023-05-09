using System;
using System.Collections.ObjectModel;

namespace BerldPokerLibrary.HandEvaluation
{
    public class ThreeOfAKind : HandValue, IComparable<HandValue>, IComparable<ThreeOfAKind>
    {
        internal Rank Rank { get; }

        /// <summary>
        /// The 2 kickers, always sorted ascending
        /// </summary>
        internal ReadOnlyCollection<Rank> Kickers => _kickers.AsReadOnly();

        private readonly List<Rank> _kickers;

        private ThreeOfAKind(Rank rank, IEnumerable<Rank> kickers)
        {
            Rank = rank;
            _kickers = kickers.ToList();
        }

        internal new static ThreeOfAKind? Determine(IEnumerable<Card> cards)
        {
            Rank? threeOfAKind = null;
            Rank? bestKicker = null;
            Rank? secondBestKicker = null;

            for (int i = RankExtensions.RankAmount - 1; i >= 0; i--)
            {
                Rank rank = (Rank)i;
                IEnumerable<Card> cardsOfRank = cards.Where(c => c.Rank == rank);

                if (!threeOfAKind.HasValue && cardsOfRank.Count() == 3)
                {
                    threeOfAKind = rank;
                }
                else if (!bestKicker.HasValue && cardsOfRank.Any())
                {
                    bestKicker = rank;
                }
                else if (!secondBestKicker.HasValue && cardsOfRank.Any())
                {
                    secondBestKicker = rank;
                }

                if (threeOfAKind.HasValue && bestKicker.HasValue && secondBestKicker.HasValue)
                {
                    return new ThreeOfAKind(threeOfAKind.Value, new List<Rank>
                    {
                        secondBestKicker.Value,
                        bestKicker.Value
                    });
                }
            }

            return null;
        }

        public override int CompareTo(HandValue? other)
        {
            if (other is ThreeOfAKind otherThreeOfAKind)
            {
                return CompareTo(otherThreeOfAKind);
            }

            return base.CompareTo(other);
        }

        public int CompareTo(ThreeOfAKind? other)
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
            return $"{ToShortString()} with {_kickers[1]}, {_kickers[0]} kickers";
        }

        public override string ToShortString()
        {
            return $"Three of a kind, {Rank.ToPlural()}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rank, _kickers[0], _kickers[1]);
        }
    }
}
