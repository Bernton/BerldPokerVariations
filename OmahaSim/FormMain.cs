using BerldPokerLibrary;

namespace OmahaSim
{
    public partial class FormMain : Form
    {
        private TrialRunner? _runner;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Start(List<Card> cards)
        {
            Stop();
            _runner = new TrialRunner();
            _runner.Start(cards);
        }

        private void Stop()
        {
            if (_runner is not null)
            {
                _runner.Dispose();
                _runner = null;
            }
        }

        private List<Card>? CardsFromText(string text)
        {
            if (text.Length != 8)
            {
                return null;
            }

            List<Card> cards = new();

            for (int i = 0; i < 8; i += 2)
            {
                char charRank = text[i];
                char charSuit = text[i + 1];

                Rank? rank = RankFromChar(charRank);
                Suit? suit = SuitFromChar(charSuit);

                if (rank.HasValue && suit.HasValue)
                {
                    cards.Add(new Card(rank.Value, suit.Value));
                }
                else
                {
                    return null;
                }
            }

            return cards;
        }

        private static Rank? RankFromChar(char charRank)
        {
            if (int.TryParse(charRank.ToString(), out int charRankNumber))
            {
                if (charRankNumber >= 2 && charRankNumber <= 9)
                {
                    return (Rank)(charRankNumber - 2);
                }
            }

            return charRank switch
            {
                'T' => Rank.Ten,
                'J' => Rank.Jack,
                'Q' => Rank.Queen,
                'K' => Rank.King,
                'A' => Rank.Ace,
                _ => null
            };
        }

        private static Suit? SuitFromChar(char charSuit)
        {
            return charSuit switch
            {
                'c' => Suit.Clubs,
                'h' => Suit.Hearts,
                'd' => Suit.Diamonds,
                's' => Suit.Spades,
                _ => null
            };
        }

        private void OnButtonStartClick(object sender, EventArgs e)
        {
            _labelCardsError.Text = string.Empty;

            List<Card>? cardsFromText = CardsFromText(_textBoxCards.Text);

            if (cardsFromText == null)
            {
                _labelCardsError.Text = "Invalid format for cards.";
            }
            else if (cardsFromText.Distinct().Count() != cardsFromText.Count)
            {
                _labelCardsError.Text = "Duplicate cards found.";
            }
            else
            {
                Start(cardsFromText);
            }
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            Stop();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (_runner is null)
            {
                return;
            }

            if (_runner.TotalEquity == 0)
            {
                _labelEquityValue.Text = string.Empty;
                return;
            }

            double equityRatio = 100.0 * _runner.Equity / _runner.TotalEquity;
            _labelEquityValue.Text = $"{equityRatio:0.00} %";
        }
    }
}