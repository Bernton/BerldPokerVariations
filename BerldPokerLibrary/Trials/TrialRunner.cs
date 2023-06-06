using BerldPokerLibrary.HandEvaluation;
using System.Collections.ObjectModel;

namespace BerldPokerLibrary.Trials
{
    public class TrialRunner
    {
        public const int DefaultRandomTrialAmount = 100000;

        private List<TrialPlayer> _players;
        private List<Card> _boardCards;

        public bool WereRandomTrials { get; private set; } = false;
        public bool RecordAdvancedStats { get; }
        public int TrialAmount { get; private set; } = 0;

        public ReadOnlyCollection<TrialPlayer> Players => _players.AsReadOnly();

        public TrialRunner(List<TrialPlayer> players, List<Card> boardCards, bool recordAdvancedStats)
        {
            List<Card> deadCards = new();

            deadCards.AddRange(boardCards);

            foreach (TrialPlayer player in players)
            {
                deadCards.AddRange(player.HoleCards);
            }

            if (deadCards.Count != deadCards.Distinct().Count())
            {
                throw new ArgumentException("There must be no duplicate cards.");
            }

            _players = players;
            _boardCards = boardCards;
            RecordAdvancedStats = recordAdvancedStats;
        }

        public void Start()
        {
            int unknownBoardCards = 5 - _boardCards.Count;

            int[] unknownPlayersCards = _players
                .Select(c => 2 - c.HoleCards.Count)
                .Where(c => c > 0)
                .OrderByDescending(c => c).ToArray();
            bool noPlayerCards = unknownPlayersCards.Length == 0;

            List<Card> aliveCards = GetAliveCards();

            if (
                unknownBoardCards == 0 &&
                noPlayerCards)
            {
                DoTrials_0();
            }
            else if (unknownBoardCards == 0 &&
                unknownPlayersCards.Length == 1 &&
                unknownPlayersCards[0] == 2)
            {
                DoTrials_0_2(aliveCards);
            }
            else if (
                unknownBoardCards == 1 &&
                noPlayerCards)
            {
                DoTrials_1(aliveCards);
            }
            else if (unknownBoardCards == 1 &&
                unknownPlayersCards.Length == 1 &&
                unknownPlayersCards[0] == 2)
            {
                DoTrials_1_2(aliveCards);
            }
            else if (
                unknownBoardCards == 2 &&
                noPlayerCards)
            {
                DoTrials_2(aliveCards);
            }
            else if (
                unknownBoardCards == 2 &&
                unknownPlayersCards.Length == 1 &&
                unknownPlayersCards[0] == 2)
            {
                DoTrials_2_2(aliveCards);
            }
            else if (
                unknownBoardCards == 3 &&
                noPlayerCards)
            {
                DoTrials_3(aliveCards);
            }
            else if (
                unknownBoardCards == 4 &&
                noPlayerCards)
            {
                DoTrials_4(aliveCards);
            }
            else if (
                unknownBoardCards == 5 &&
                noPlayerCards)
            {
                DoTrials_5(aliveCards);
            }
            else if (
                unknownBoardCards == 5 &&
                unknownPlayersCards.Length == 1 &&
                unknownPlayersCards[0] == 2)
            {
                DoTrials_5_2(aliveCards);
            }
            else
            {
                Start(DefaultRandomTrialAmount);
            }
        }

        public void Start(int randomTrialAmount)
        {
            WereRandomTrials = true;
            DoTrialsRandom(randomTrialAmount);
        }

        private void DoTrial(List<Card> assignedCards)
        {
            Stack<Card> cardsToAssign = new(assignedCards);
            List<Card> boardCards = new(_boardCards);

            while (boardCards.Count < 5)
            {
                boardCards.Add(cardsToAssign.Pop());
            }

            List<TrialPlayer> winners = new();

            foreach (TrialPlayer player in _players)
            {
                List<Card> holeCards = new(player.HoleCards);

                while (holeCards.Count < 2)
                {
                    holeCards.Add(cardsToAssign.Pop());
                }

                List<Card> cardsToEvaluate = new();
                cardsToEvaluate.AddRange(holeCards);
                cardsToEvaluate.AddRange(boardCards);

                player.CurrentValue = HandValue.Determine(cardsToEvaluate);

                if (winners.Count == 0)
                {
                    winners.Add(player);
                }
                else
                {
                    int comparisonResult = player.CurrentValue.CompareTo(winners[0].CurrentValue);

                    if (comparisonResult > 0)
                    {
                        winners.Clear();
                    }

                    if (comparisonResult >= 0)
                    {
                        winners.Add(player);
                    }
                }

                player.TrialAmount += 1;
            }

            double winnerEquity = 1.0 / winners.Count;

            for (int j = 0; j < winners.Count; j++)
            {
                TrialPlayer winner = winners[j];

                winner.TotalEquity += winnerEquity;

                switch (winner.CurrentValue)
                {
                    case StraightFlush straightFlush:
                        if (straightFlush.Rank == Rank.Ace)
                        {
                            winner.WinnerCount.RoyalFlush += winnerEquity;
                        }
                        else
                        {
                            winner.WinnerCount.StraightFlush += winnerEquity;
                        }
                        break;

                    case FourOfAKind:
                        winner.WinnerCount.FourOfAKind += winnerEquity;
                        break;

                    case FullHouse:
                        winner.WinnerCount.FullHouse += winnerEquity;
                        break;

                    case Flush:
                        winner.WinnerCount.Flush += winnerEquity;
                        break;

                    case Straight:
                        winner.WinnerCount.Straight += winnerEquity;
                        break;

                    case ThreeOfAKind:
                        winner.WinnerCount.ThreeOfAKind += winnerEquity;
                        break;

                    case TwoPair:
                        winner.WinnerCount.TwoPair += winnerEquity;
                        break;

                    case Pair:
                        winner.WinnerCount.Pair += winnerEquity;
                        break;

                    case HighCard:
                        winner.WinnerCount.HighCard += winnerEquity;
                        break;

                    default:
                        throw new Exception();
                }
            }

            TrialAmount++;
        }

        private void DoTrialsRandom(int trialAmount)
        {
            List<Card> deadCards = GetDeadCards();
            Deck deck = new(deadCards);

            for (int i = 0; i < trialAmount; i++)
            {
                deck.Shuffle();

                List<Card> assignedCards = new();
                int unknownCardAmount = GetUnknownCardAmount();

                for (int j = 0; j < unknownCardAmount; j++)
                {
                    assignedCards.Add(deck.Draw());
                }

                DoTrial(assignedCards);
            }
        }

        private void DoTrials_0()
        {
            DoTrial(new());
        }

        private void DoTrials_0_2(List<Card> cards)
        {
            int N = cards.Count;
            List<Card> assignedCards = new();

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    assignedCards.Clear();
                    assignedCards.Add(cards[i]);
                    assignedCards.Add(cards[j]);
                    DoTrial(assignedCards);
                }
            }
        }

        private void DoTrials_1(List<Card> cards)
        {
            int N = cards.Count;
            List<Card> assignedCards = new();

            for (int u = 0; u < N; u++)
            {
                assignedCards.Clear();
                assignedCards.Add(cards[u]);
                DoTrial(assignedCards);
            }
        }

        private void DoTrials_1_2(List<Card> cards)
        {
            int N = cards.Count;
            List<Card> assignedCards = new();

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    for (int u = 0; u < N; u++)
                    {
                        if (u == i || u == j) continue;

                        assignedCards.Clear();
                        assignedCards.Add(cards[i]);
                        assignedCards.Add(cards[j]);
                        assignedCards.Add(cards[u]);
                        DoTrial(assignedCards);
                    }
                }
            }
        }

        private void DoTrials_2(List<Card> cards)
        {
            int N = cards.Count;
            List<Card> assignedCards = new();

            for (int u = 0; u < N; u++)
            {
                for (int v = u + 1; v < N; v++)
                {
                    assignedCards.Clear();
                    assignedCards.Add(cards[u]);
                    assignedCards.Add(cards[v]);
                    DoTrial(assignedCards);
                }
            }
        }

        private void DoTrials_2_2(List<Card> cards)
        {
            int N = cards.Count;
            List<Card> assignedCards = new();

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    for (int u = 0; u < N; u++)
                    {
                        if (u == i || u == j) continue;

                        for (int v = u + 1; v < N; v++)
                        {
                            if (v == i || v == j) continue;

                            assignedCards.Clear();
                            assignedCards.Add(cards[i]);
                            assignedCards.Add(cards[j]);
                            assignedCards.Add(cards[u]);
                            assignedCards.Add(cards[v]);
                            DoTrial(assignedCards);
                        }
                    }
                }
            }
        }

        private void DoTrials_3(List<Card> cards)
        {
            int N = cards.Count;
            List<Card> assignedCards = new();

            for (int u = 0; u < N; u++)
            {
                for (int v = u + 1; v < N; v++)
                {
                    for (int w = v + 1; w < N; w++)
                    {
                        assignedCards.Clear();
                        assignedCards.Add(cards[u]);
                        assignedCards.Add(cards[v]);
                        assignedCards.Add(cards[w]);
                        DoTrial(assignedCards);
                    }
                }
            }
        }

        private void DoTrials_4(List<Card> cards)
        {
            int N = cards.Count;
            List<Card> assignedCards = new();

            for (int u = 0; u < N; u++)
            {
                for (int v = u + 1; v < N; v++)
                {
                    for (int w = v + 1; w < N; w++)
                    {
                        for (int x = w + 1; x < N; x++)
                        {
                            assignedCards.Clear();
                            assignedCards.Add(cards[u]);
                            assignedCards.Add(cards[v]);
                            assignedCards.Add(cards[w]);
                            assignedCards.Add(cards[x]);
                            DoTrial(assignedCards);
                        }
                    }
                }
            }
        }

        private void DoTrials_5(List<Card> cards)
        {
            int N = cards.Count;
            List<Card> assignedCards = new();

            for (int u = 0; u < N; u++)
            {
                for (int v = u + 1; v < N; v++)
                {
                    for (int w = v + 1; w < N; w++)
                    {
                        for (int x = w + 1; x < N; x++)
                        {
                            for (int y = x + 1; y < N; y++)
                            {
                                assignedCards.Clear();
                                assignedCards.Add(cards[u]);
                                assignedCards.Add(cards[v]);
                                assignedCards.Add(cards[w]);
                                assignedCards.Add(cards[x]);
                                assignedCards.Add(cards[y]);
                                DoTrial(assignedCards);
                            }
                        }
                    }
                }
            }
        }

        private void DoTrials_5_2(List<Card> cards)
        {
            int N = cards.Count;
            List<Card> assignedCards = new();

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    for (int u = 0; u < N; u++)
                    {
                        if (u == i || u == j) continue;

                        for (int v = u + 1; v < N; v++)
                        {
                            if (v == i || v == j) continue;

                            for (int w = v + 1; w < N; w++)
                            {
                                if (w == i || w == j) continue;

                                for (int x = w + 1; x < N; x++)
                                {
                                    if (x == i || x == j) continue;

                                    for (int y = x + 1; y < N; y++)
                                    {
                                        if (y == i || y == j) continue;

                                        assignedCards.Clear();
                                        assignedCards.Add(cards[i]);
                                        assignedCards.Add(cards[j]);
                                        assignedCards.Add(cards[u]);
                                        assignedCards.Add(cards[v]);
                                        assignedCards.Add(cards[w]);
                                        assignedCards.Add(cards[x]);
                                        assignedCards.Add(cards[y]);
                                        DoTrial(assignedCards);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private List<Card> GetDeadCards()
        {
            List<Card> deadCards = new();

            deadCards.AddRange(_boardCards);

            foreach (TrialPlayer player in _players)
            {
                deadCards.AddRange(player.HoleCards);
            }

            return deadCards;
        }

        private List<Card> GetAliveCards()
        {
            List<Card> deadCards = GetDeadCards();
            List<Card> aliveCards = new();

            for (int i = 0; i < Deck.CardAmount; i++)
            {
                aliveCards.Add(new Card(i));
            }

            return aliveCards.Except(deadCards).ToList();
        }

        private int GetUnknownCardAmount()
        {
            int unknownBoardCards = 5 - _boardCards.Count;
            int unknownPlayerCards = _players.Count * 2 - _players.Sum(c => c.HoleCards.Count);
            return unknownBoardCards + unknownPlayerCards;
        }

        /// <summary>
        /// Does not work with player whole cards, only on boards, keep here as reference
        /// </summary>
#pragma warning disable IDE0051 // Remove unused private members
        private void DoTrialsExhaustive()
#pragma warning restore IDE0051 // Remove unused private members
        {
            List<Card> aliveCards = GetAliveCards();
            int unknownCardAmount = GetUnknownCardAmount();

            int[] counters = new int[unknownCardAmount];

            for (int u = 0; u < unknownCardAmount; u++)
            {
                counters[u] = u;
            }

            bool breakOuter = false;
            int last = unknownCardAmount - 1;

            while (!breakOuter)
            {
                List<Card> assignedCards = new();

                for (int i = 0; i < unknownCardAmount; i++)
                {
                    assignedCards.Add(aliveCards[counters[i]]);
                }

                DoTrial(assignedCards);

                if (last < 0)
                {
                    break;
                }

                counters[last]++;

                for (int i = 0; i < unknownCardAmount; i++)
                {
                    int iLast = unknownCardAmount - i - 1;
                    int bound = aliveCards.Count - i;

                    if (counters[iLast] < bound)
                    {
                        break;
                    }
                    else
                    {
                        if (i == last)
                        {
                            breakOuter = true;
                            break;
                        }

                        int iSecondLast = iLast - 1;
                        counters[iSecondLast]++;

                        if (counters[iSecondLast] < bound - 1)
                        {
                            for (int j = 0; j <= i; j++)
                            {
                                counters[iSecondLast + 1 + j] = counters[iSecondLast + j] + 1;
                            }

                            break;
                        }
                    }
                }
            }
        }
    }
}
