using BerldPokerLibrary;
using BerldPokerLibrary.HandEvaluation;
using BerldPokerLibrary.Omaha;

namespace OmahaSim
{
    internal class TrialRunner : IDisposable
    {
        public const int CardCount = 4;

        private List<Card> _cards;

        private readonly Task _task;
        private readonly CancellationTokenSource _tokenSource;

        public int Equity { get; private set; }
        public int TotalEquity { get; private set; }

        public IReadOnlyCollection<Card> Cards => _cards.AsReadOnly();

        public TrialRunner()
        {
            _cards = new List<Card>();
            _tokenSource = new CancellationTokenSource();
            _task = new Task(RunTrial, _tokenSource.Token);
        }

        public void Start(IEnumerable<Card> cards)
        {
            if (_cards.Any())
            {
                throw new InvalidOperationException($"This {nameof(TrialRunner)} instance was already started.");
            }

            if (cards.Count() != CardCount)
            {
                throw new ArgumentException($"{nameof(cards)} must have count of {CardCount}.");
            }

            _cards = cards.ToList();
            _task.Start();
        }

        public void Stop()
        {
            if (_cards is not null)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _tokenSource.Cancel();
            _tokenSource.Dispose();
        }

        private void RunTrial()
        {
            if (_cards.Count == 0)
            {
                return;
            }

            Deck deck = new(_cards);

            while (!_tokenSource.IsCancellationRequested)
            {
                deck.Shuffle();

                List<Card> otherCards = new()
                {
                    deck[0],
                    deck[1],
                    deck[2],
                    deck[3]
                };

                List<Card> communityCards = new()
                {
                    deck[5],
                    deck[6],
                    deck[7],
                    deck[9],
                    deck[11]
                };

                HandValue handValue = OmahaHand.Determine(_cards, communityCards);
                HandValue otherHandValue = OmahaHand.Determine(otherCards, communityCards);

                int comparison = handValue.CompareTo(otherHandValue);

                if (comparison > 0)
                {
                    Equity += 2;
                }
                else if (comparison == 0)
                {
                    Equity += 1;
                }

                TotalEquity += 2;
            }
        }
    }
}
