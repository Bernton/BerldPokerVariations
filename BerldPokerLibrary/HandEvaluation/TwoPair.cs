namespace BerldPokerLibrary.HandEvaluation
{
    public class TwoPair : HandValue, IComparable<HandValue>, IComparable<TwoPair>
    {
        internal Rank HigherPair { get; }
        internal Rank LowerPair { get; }
        internal Rank Kicker { get; }

        private TwoPair(Rank higherPair, Rank lowerPair, Rank kicker)
        {
            HigherPair = higherPair;
            LowerPair = lowerPair;
            Kicker = kicker;
        }

        internal new static TwoPair? Determine(IEnumerable<Card> cards)
        {
            Rank? higherPairRank = null;
            Rank? lowerPairRank = null;
            Rank? kicker = null;

            for (int i = RankExtensions.RankAmount - 1; i >= 0; i--)
            {
                Rank rank = (Rank)i;
                IEnumerable<Card> cardsOfRank = cards.Where(c => c.Rank == rank);

                if (!higherPairRank.HasValue && cardsOfRank.Count() == 2)
                {
                    higherPairRank = rank;
                }
                else if (!lowerPairRank.HasValue && cardsOfRank.Count() == 2)
                {
                    lowerPairRank = rank;
                }
                else if (!kicker.HasValue && cardsOfRank.Any())
                {
                    kicker = rank;
                }

                if (higherPairRank.HasValue && lowerPairRank.HasValue && kicker.HasValue)
                {
                    return new TwoPair(higherPairRank.Value, lowerPairRank.Value, kicker.Value);
                }
            }

            return null;
        }

        public override int CompareTo(HandValue? other)
        {
            if (other is TwoPair otherTwoPair)
            {
                return CompareTo(otherTwoPair);
            }

            return base.CompareTo(other);
        }

        public int CompareTo(TwoPair? other)
        {
            if (other is null)
            {
                return 1;
            }

            int higherPairComparison = HigherPair - other.HigherPair;

            if (higherPairComparison != 0)
            {
                return higherPairComparison;
            }

            int lowerPairComparison = LowerPair - other.LowerPair;

            if (lowerPairComparison != 0)
            {
                return lowerPairComparison;
            }

            return Kicker - other.Kicker;
        }

        public override string ToString()
        {
            return $"{ToShortString()} and {Kicker} kicker";
        }

        public override string ToShortString()
        {
            return $"{HigherPair.ToPlural()} up with {LowerPair.ToPlural()}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(HigherPair, LowerPair, Kicker);
        }
    }
}
