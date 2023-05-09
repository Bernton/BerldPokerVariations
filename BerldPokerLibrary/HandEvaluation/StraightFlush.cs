namespace BerldPokerLibrary.HandEvaluation
{
    public class StraightFlush : HandValue, IComparable<HandValue>, IComparable<StraightFlush>
    {
        public Rank Rank { get; }

        private StraightFlush(Rank rank)
        {
            Rank = rank;
        }

        internal new static StraightFlush? Determine(IEnumerable<Card> cards)
        {
            IEnumerable<Card>? flushCards = DetermineFlushCards(cards.ToList());

            if (flushCards is null)
            {
                return null;
            }

            IEnumerable<Rank> flushCardRanks = flushCards.Select(c => c.Rank).Distinct();
            Rank? straightRank = DetermineStraight(flushCardRanks);

            if (straightRank.HasValue)
            {
                return new StraightFlush(straightRank.Value);
            }
            else
            {
                return null;
            }
        }

        public override int CompareTo(HandValue? other)
        {
            if (other is StraightFlush otherStraightFlush)
            {
                return CompareTo(otherStraightFlush);
            }

            return base.CompareTo(other);
        }

        public int CompareTo(StraightFlush? other)
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
                return "Royal flush";
            }

            return $"{Rank} high straight flush";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rank);
        }
    }
}
