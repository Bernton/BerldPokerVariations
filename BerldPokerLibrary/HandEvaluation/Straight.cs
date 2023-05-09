namespace BerldPokerLibrary.HandEvaluation
{
    public class Straight : HandValue, IComparable<HandValue>, IComparable<Straight>
    {
        public Rank Rank { get; }

        private Straight(Rank rank)
        {
            Rank = rank;
        }

        internal new static Straight? Determine(IEnumerable<Card> cards)
        {
            IEnumerable<Rank> cardRanks = cards.Select(c => c.Rank).Distinct();
            Rank? straightRank = DetermineStraight(cardRanks);

            if (straightRank.HasValue)
            {
                return new Straight(straightRank.Value);
            }
            else
            {
                return null;
            }
        }

        public override int CompareTo(HandValue? other)
        {
            if (other is Straight otherStraight)
            {
                return CompareTo(otherStraight);
            }

            return base.CompareTo(other);
        }

        public int CompareTo(Straight? other)
        {
            if (other is null)
            {
                return 1;
            }

            return Rank - other.Rank;
        }

        public override string ToString()
        {
            return ToShortString();
        }

        public override string ToShortString()
        {
            if (Rank == Rank.Ace)
            {
                return "Broadway straight";
            }
            else if (Rank == Rank.Five)
            {
                return "Wheel straight";
            }

            return $"{Rank} high straight";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rank);
        }
    }
}
