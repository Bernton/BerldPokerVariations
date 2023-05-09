using BerldPokerLibrary;
using BerldPokerLibrary.HandEvaluation;

namespace ExhaustiveSimulator
{
    internal class ExhaustiveHandEvaluator : IDisposable
    {
        internal int Combinations { get; private set; }

        internal int RoyalFlushAmount { get; private set; }
        internal int StraightFlushAmount { get; private set; }
        internal int FourOfAKindAmount { get; private set; }
        internal int FullHouseAmount { get; private set; }
        internal int FlushAmount { get; private set; }
        internal int StraightAmount { get; private set; }
        internal int ThreeOfAKindAmount { get; private set; }
        internal int TwoPairAmount { get; private set; }
        internal int PairAmount { get; private set; }
        internal int HighCardAmount { get; private set; }
        internal int HandValueAmount { get; private set; }

        internal Dictionary<HandValue, int> HandValueAmounts { get; } = new Dictionary<HandValue, int>();

        public int AmountOfCards { get; private set; }
        public int? AssignedUpperMostIndex { get; private set; }

        internal Task Task { get; private set; }

        private CancellationTokenSource _tokenSource;
        private bool isInitalStart = true;

        public ExhaustiveHandEvaluator(int amountOfCards, int? assignedUpperMostIndex = null)
        {
            AmountOfCards = amountOfCards;
            AssignedUpperMostIndex = assignedUpperMostIndex;
            Combinations = (int)GetBinCoeff(52, amountOfCards);

            _tokenSource = new CancellationTokenSource();
            Task = new Task(SimulateHand, _tokenSource.Token);
        }

        public static long GetBinCoeff(long N, long K)
        {
            // This function gets the total number of unique combinations based upon N and K.
            // N is the total number of items.
            // K is the size of the group.
            // Total number of unique combinations = N! / ( K! (N - K)! ).
            // This function is less efficient, but is more likely to not overflow when N and K are large.
            // Taken from:  http://blog.plover.com/math/choose.html
            //
            long r = 1;
            long d;
            if (K > N) return 0;
            for (d = 1; d <= K; d++)
            {
                r *= N--;
                r /= d;
            }
            return r;
        }

        internal void StartNew()
        {
            if (!isInitalStart)
            {
                isInitalStart = false;
                Stop();
            }

            Start();
        }


        internal void Stop()
        {
            if (!_tokenSource.IsCancellationRequested)
            {
                _tokenSource.Cancel();
                _tokenSource.Dispose();
            }
        }

        private void Start()
        {
            _tokenSource = new CancellationTokenSource();
            Task = new Task(SimulateHand, _tokenSource.Token);
            Task.Start();
        }

        private void SimulateHand()
        {
            if (_tokenSource is null)
            {
                return;
            }

            int amountOfCards = AmountOfCards;
            int[] indexes = new int[amountOfCards];
            Card[] cards = new Card[amountOfCards];

            if (AssignedUpperMostIndex.HasValue)
            {
                indexes[0] = AssignedUpperMostIndex.Value;
            }
            else
            {
                indexes[0] = 0;

            }

            for (int i = 1; i < amountOfCards; i++)
            {
                indexes[i] = indexes[i - 1] + 1;
            }

            while (true)
            {
                for (int i = 0; i < amountOfCards; i++)
                {
                    cards[i] = new Card(indexes[i]);
                }

                HandValue handValue = HandValue.Determine(cards);

                if (handValue is StraightFlush straightFlush)
                {
                    if (straightFlush.Rank == Rank.Ace)
                    {
                        RoyalFlushAmount += 1;
                    }

                    StraightFlushAmount += 1;
                }
                else if (handValue is FourOfAKind)
                {
                    FourOfAKindAmount += 1;
                }
                else if (handValue is FullHouse)
                {
                    FullHouseAmount += 1;
                }
                else if (handValue is Flush)
                {
                    FlushAmount += 1;
                }
                else if (handValue is Straight)
                {
                    StraightAmount += 1;
                }
                else if (handValue is ThreeOfAKind)
                {
                    ThreeOfAKindAmount += 1;
                }
                else if (handValue is TwoPair)
                {
                    TwoPairAmount += 1;
                }
                else if (handValue is Pair)
                {
                    PairAmount += 1;
                }
                else if (handValue is HighCard)
                {
                    HighCardAmount += 1;
                }
                else
                {
                    throw new InvalidOperationException($"{nameof(handValue)} has no expected type.");
                }

                if (HandValueAmounts.ContainsKey(handValue))
                {
                    HandValueAmounts[handValue] += 1;
                }
                else
                {
                    HandValueAmounts[handValue] = 1;
                }

                HandValueAmount += 1;

                indexes[^1] += 1;

                for (int i = 0; i < amountOfCards; i++)
                {
                    int reverse = amountOfCards - 1 - i;

                    if (indexes[reverse] == Deck.CardAmount - i)
                    {
                        if (reverse == 0 || (AssignedUpperMostIndex.HasValue && reverse == 1))
                        {
                            return;
                        }

                        indexes[reverse - 1] += 1;
                    }
                }

                for (int i = 0; i < amountOfCards; i++)
                {
                    int reverse = amountOfCards - 1 - i;

                    if (indexes[i] == Deck.CardAmount - reverse)
                    {
                        indexes[i] = indexes[i - 1] + 1;
                    }
                }
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
