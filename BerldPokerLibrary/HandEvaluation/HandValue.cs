namespace BerldPokerLibrary.HandEvaluation
{
    public abstract class HandValue : IEquatable<HandValue>, IComparable<HandValue>
    {
        internal const int HandValueCardAmount = 5;

        private static void ValidateCards(IEnumerable<Card> cards)
        {
            if (cards is null || cards.Count() < HandValueCardAmount)
            {
                throw new ArgumentException($"There must {HandValueCardAmount} cards or more.", nameof(cards));
            }

            if (cards.Count() != cards.Distinct().Count())
            {
                throw new ArgumentException("There must be no duplicate cards.");
            }
        }

        public static HandValue Determine(IEnumerable<Card> cardsToEvaluate)
        {
            ValidateCards(cardsToEvaluate);

            HandValue? straightFlush = StraightFlush.Determine(cardsToEvaluate);

            if (straightFlush is not null)
            {
                return straightFlush;
            }

            HandValue? fourOfAKind = FourOfAKind.Determine(cardsToEvaluate);

            if (fourOfAKind is not null)
            {
                return fourOfAKind;
            }

            HandValue? fullHouse = FullHouse.Determine(cardsToEvaluate);

            if (fullHouse is not null)
            {
                return fullHouse;
            }

            HandValue? flush = Flush.Determine(cardsToEvaluate);

            if (flush is not null)
            {
                return flush;
            }

            HandValue? straight = Straight.Determine(cardsToEvaluate);

            if (straight is not null)
            {
                return straight;
            }

            HandValue? threeOfAKind = ThreeOfAKind.Determine(cardsToEvaluate);

            if (threeOfAKind is not null)
            {
                return threeOfAKind;
            }

            HandValue? twoPair = TwoPair.Determine(cardsToEvaluate);

            if (twoPair is not null)
            {
                return twoPair;
            }

            HandValue? pair = Pair.Determine(cardsToEvaluate);

            if (pair is not null)
            {
                return pair;
            }

            return HighCard.Determine(cardsToEvaluate);
        }

        private static int GetHandStrength(HandValue? handValue)
        {
            return handValue switch
            {
                HighCard => 0,
                Pair => 1,
                TwoPair => 2,
                ThreeOfAKind => 3,
                Straight => 4,
                Flush => 5,
                FullHouse => 6,
                FourOfAKind => 7,
                StraightFlush => 8,
                _ => -1
            };
        }

        protected static IEnumerable<Card>? DetermineFlushCards(IEnumerable<Card> cards)
        {
            for (int i = 0; i < SuitExtensions.SuitAmount; i++)
            {
                IEnumerable<Card> cardsOfSuit = cards.Where(c => c.Suit == (Suit)i);

                if (cardsOfSuit.Count() >= 5)
                {
                    return cardsOfSuit;
                }
            }

            return null;
        }

        protected static Rank? DetermineStraight(IEnumerable<Rank> cardRanks)
        {
            List<Rank> ranksDescending = cardRanks.OrderByDescending(c => c).ToList();
            Rank highestRank = ranksDescending[0];
            List<Rank> straightRanks = new() { highestRank };

            for (int i = 1; i < ranksDescending.Count; i++)
            {
                Rank rank = ranksDescending[i];
                Rank lastRank = straightRanks[^1];

                if (lastRank - rank != 1)
                {
                    straightRanks.Clear();
                }

                straightRanks.Add(rank);

                Rank highestStraightRank = straightRanks[0];

                if (straightRanks.Count == 4 &&
                    highestStraightRank == Rank.Five &&
                    highestRank == Rank.Ace)
                {
                    straightRanks.Add(highestRank);
                }

                if (straightRanks.Count >= 5)
                {
                    return highestStraightRank;
                }
            }

            return null;
        }


        public override bool Equals(object? obj)
        {
            if (obj is HandValue otherHandValue)
            {
                return Equals(otherHandValue);
            }

            return false;
        }

        public bool Equals(HandValue? other)
        {
            return CompareTo(other) == 0;
        }

        public virtual int CompareTo(HandValue? other)
        {
            if (other is null)
            {
                return 1;
            }

            return GetHandStrength(this) - GetHandStrength(other);
        }

        public abstract string ToShortString();

        public override abstract int GetHashCode();
    }
}
