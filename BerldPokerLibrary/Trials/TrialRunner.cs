using BerldPokerLibrary.HandEvaluation;
using System.Collections.ObjectModel;

namespace BerldPokerLibrary.Trials
{
    public class TrialRunner
    {
        private List<TrialPlayer> _players;
        private List<Card> _boardCards;

        public int TrialAmount { get; private set; } = 0;

        public ReadOnlyCollection<TrialPlayer> Players => _players.AsReadOnly();

        public TrialRunner(List<TrialPlayer> players, List<Card> boardCards)
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
        }

        public void Start()
        {
            DoTrialsExhaustive();
        }

        public void Start(int randomTrialAmount)
        {
            DoTrialsRandom(randomTrialAmount);
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

        private void DoTrialsExhaustive()
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
                winners[j].TotalEquity += winnerEquity;
            }

            TrialAmount++;
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
    }
}
