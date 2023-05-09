
namespace BerldPokerLibrary.HandEvaluation
{
    public class FourOfAKind : HandValue, IComparable<HandValue>, IComparable<FourOfAKind>
    {
        internal Rank Rank { get; }
        internal Rank Kicker { get; }

        private FourOfAKind(Rank rank, Rank kicker)
        {
            Rank = rank;
            Kicker = kicker;
        }

        internal new static FourOfAKind? Determine(IEnumerable<Card> cards)
        {
            Rank? fourOfAKind = null;
            Rank? kicker = null;

            for (int i = RankExtensions.RankAmount - 1; i >= 0; i--)
            {
                Rank rank = (Rank)i;
                IEnumerable<Card> cardsOfRank = cards.Where(c => c.Rank == rank);

                if (!fourOfAKind.HasValue && cardsOfRank.Count() == 4)
                {
                    fourOfAKind = rank;
                }
                else if (!kicker.HasValue && cardsOfRank.Any())
                {
                    kicker = rank;
                }

                if (fourOfAKind.HasValue && kicker.HasValue)
                {
                    return new FourOfAKind(fourOfAKind.Value, kicker.Value);
                }
            }

            return null;
        }

        public override int CompareTo(HandValue? other)
        {
            if (other is FourOfAKind otherFourOfAKind)
            {
                return CompareTo(otherFourOfAKind);
            }

            return base.CompareTo(other);
        }

        public int CompareTo(FourOfAKind? other)
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

            return Kicker - other.Kicker;
        }

        public override string ToString()
        {
            return $"{ToShortString()} with {Kicker} kicker";
        }

        public override string ToShortString()
        {
            return $"Four of a kind, {Rank.ToPlural()}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rank, Kicker);
        }
    }
}
