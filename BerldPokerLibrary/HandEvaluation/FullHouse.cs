namespace BerldPokerLibrary.HandEvaluation
{
    public class FullHouse : HandValue, IComparable<HandValue>, IComparable<FullHouse>
    {
        internal Rank ThreeOfAKind { get; }
        internal Rank Pair { get; }

        private FullHouse(Rank threeOfAKind, Rank pair)
        {
            ThreeOfAKind = threeOfAKind;
            Pair = pair;
        }

        internal new static FullHouse? Determine(IEnumerable<Card> cards)
        {
            Rank? threeOfAKind = null;
            Rank? pair = null;

            for (int i = RankExtensions.RankAmount - 1; i >= 0; i--)
            {
                Rank rank = (Rank)i;
                IEnumerable<Card> cardsOfRank = cards.Where(c => c.Rank == rank);

                if (!threeOfAKind.HasValue && cardsOfRank.Count() == 3)
                {
                    threeOfAKind = rank;
                }
                else if (!pair.HasValue && cardsOfRank.Count() >= 2)
                {
                    pair = rank;
                }

                if (threeOfAKind.HasValue && pair.HasValue)
                {
                    return new FullHouse(threeOfAKind.Value, pair.Value);
                }
            }

            return null;
        }

        public override int CompareTo(HandValue? other)
        {
            if (other is FullHouse otherFullHouse)
            {
                return CompareTo(otherFullHouse);
            }

            return base.CompareTo(other);
        }

        public int CompareTo(FullHouse? other)
        {
            if (other is null)
            {
                return 1;
            }

            int threeOfAKindComparison = ThreeOfAKind - other.ThreeOfAKind;

            if (threeOfAKindComparison != 0)
            {
                return threeOfAKindComparison;
            }

            return Pair - other.Pair;
        }

        public override string ToString()
        {
            return ToShortString();
        }

        public override string ToShortString()
        {
            return $"{ThreeOfAKind.ToPlural()} full of {Pair.ToPlural()}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ThreeOfAKind, Pair);
        }
    }
}
