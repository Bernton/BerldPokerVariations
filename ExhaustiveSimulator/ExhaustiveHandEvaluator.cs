using BerldPokerLibrary;
using BerldPokerLibrary.HandEvaluation;

namespace ExhaustiveSimulator
{
    internal class ExhaustiveHandEvaluator
    {
        internal const int CombinationsWith7 = 133784560;
        internal const int CombinationsWith5 = 2598960;

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

        public int? AssignedUpperMostIndex { get; private set; }

        internal Task Task { get; private set; }

        private CancellationTokenSource _tokenSource;
        private bool isInitalStart = true;

        public ExhaustiveHandEvaluator(int? assignedUpperMostIndex = null)
        {
            AssignedUpperMostIndex = assignedUpperMostIndex;

            _tokenSource = new CancellationTokenSource();
            Task = new Task(SimulateHand7, _tokenSource.Token);
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
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
            Task?.Dispose();
        }

        private void Start()
        {
            _tokenSource = new CancellationTokenSource();
            Task = new Task(SimulateHand7, _tokenSource.Token);
            Task.Start();
        }

        private void SimulateHand5()
        {
            if (_tokenSource is null)
            {
                return;
            }

            Card[] cards = new Card[5];

            for (int i = 0; i < Deck.CardAmount; i++)
            {
                if (AssignedUpperMostIndex.HasValue)
                {
                    i = AssignedUpperMostIndex.Value;
                }

                for (int j = i + 1; j < Deck.CardAmount; j++)
                {
                    for (int k = j + 1; k < Deck.CardAmount; k++)
                    {
                        for (int l = k + 1; l < Deck.CardAmount; l++)
                        {
                            for (int m = l + 1; m < Deck.CardAmount; m++)
                            {
                                if (_tokenSource.IsCancellationRequested)
                                {
                                    return;
                                }

                                cards[0] = new Card(i);
                                cards[1] = new Card(j);
                                cards[2] = new Card(k);
                                cards[3] = new Card(l);
                                cards[4] = new Card(m);

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
                            }
                        }
                    }
                }

                if (AssignedUpperMostIndex.HasValue)
                {
                    break;
                }
            }
        }

        private void SimulateHand6()
        {
            if (_tokenSource is null)
            {
                return;
            }

            Card[] cards = new Card[6];

            for (int i = 0; i < Deck.CardAmount; i++)
            {
                if (AssignedUpperMostIndex.HasValue)
                {
                    i = AssignedUpperMostIndex.Value;
                }

                for (int j = i + 1; j < Deck.CardAmount; j++)
                {
                    for (int k = j + 1; k < Deck.CardAmount; k++)
                    {
                        for (int l = k + 1; l < Deck.CardAmount; l++)
                        {
                            for (int m = l + 1; m < Deck.CardAmount; m++)
                            {
                                for (int n = m + 1; n < Deck.CardAmount; n++)
                                {
                                    if (_tokenSource.IsCancellationRequested)
                                    {
                                        return;
                                    }

                                    cards[0] = new Card(i);
                                    cards[1] = new Card(j);
                                    cards[2] = new Card(k);
                                    cards[3] = new Card(l);
                                    cards[4] = new Card(m);
                                    cards[5] = new Card(n);

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
                                }
                            }
                        }
                    }
                }

                if (AssignedUpperMostIndex.HasValue)
                {
                    break;
                }
            }
        }

        private void SimulateHand7()
        {
            if (_tokenSource is null)
            {
                return;
            }

            Card[] cards = new Card[7];

            for (int i = 0; i < Deck.CardAmount; i++)
            {
                if (AssignedUpperMostIndex.HasValue)
                {
                    i = AssignedUpperMostIndex.Value;
                }

                for (int j = i + 1; j < Deck.CardAmount; j++)
                {
                    for (int k = j + 1; k < Deck.CardAmount; k++)
                    {
                        for (int l = k + 1; l < Deck.CardAmount; l++)
                        {
                            for (int m = l + 1; m < Deck.CardAmount; m++)
                            {
                                for (int n = m + 1; n < Deck.CardAmount; n++)
                                {
                                    for (int o = n + 1; o < Deck.CardAmount; o++)
                                    {
                                        if (_tokenSource.IsCancellationRequested)
                                        {
                                            return;
                                        }

                                        cards[0] = new Card(i);
                                        cards[1] = new Card(j);
                                        cards[2] = new Card(k);
                                        cards[3] = new Card(l);
                                        cards[4] = new Card(m);
                                        cards[5] = new Card(n);
                                        cards[6] = new Card(o);

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
                                    }
                                }
                            }
                        }
                    }
                }

                if (AssignedUpperMostIndex.HasValue)
                {
                    break;
                }
            }
        }
    }
}
