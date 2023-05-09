using System.Text;

namespace ExhaustiveSimulator
{
    public partial class FormMain : Form
    {
        private readonly MainViewModel _vm;
        private readonly DateTime _startTime;
        private DateTime? _endTime;

        public FormMain()
        {
            _vm = new MainViewModel();
            _startTime = DateTime.Now;
            _vm.AllEvaluatorsFinished += OnAllEvaluatorsFinished;

            //var v1 = HandValue.Determine(new List<Card>
            //{
            //    new Card(Rank.Four, Suit.Spades),
            //    new Card(Rank.Four, Suit.Hearts),
            //    new Card(Rank.Four, Suit.Diamonds),
            //    new Card(Rank.Tray, Suit.Clubs),
            //    new Card(Rank.Deuce, Suit.Spades),
            //    new Card(Rank.Five, Suit.Spades),
            //    new Card(Rank.Queen, Suit.Spades)
            //});

            //var v2 = HandValue.Determine(new List<Card>
            //{
            //    new Card(Rank.Four, Suit.Spades),
            //    new Card(Rank.Four, Suit.Hearts),
            //    new Card(Rank.Four, Suit.Diamonds),
            //    new Card(Rank.Tray, Suit.Clubs),
            //    new Card(Rank.Deuce, Suit.Spades),
            //    new Card(Rank.Five, Suit.Spades),
            //    new Card(Rank.Queen, Suit.Spades)
            //});

            //var v1H = v1.GetHashCode();
            //var v2H = v2.GetHashCode();

            //var isEqual = v1H.Equals(v2H);

            InitializeComponent();
        }

        private void OnAllEvaluatorsFinished()
        {
            _endTime = DateTime.Now;

            var values = _vm.MergedHandValueAmounts;

            var sortedValues = values.ToList().OrderBy(c => c.Key);

            StringBuilder stringBuilder = new();

            foreach (var value in sortedValues)
            {
                stringBuilder.AppendLine(value.Key.ToString() + "; " + value.Value.ToString());
            }

            File.WriteAllText("values.csv", stringBuilder.ToString());
        }

        private void OnTimerUpdateValuesTick(object sender, EventArgs e)
        {
            int royalFlushAmount = _vm.Evaluators.Sum(c => c.RoyalFlushAmount);
            int straightFlushAmount = _vm.Evaluators.Sum(c => c.StraightFlushAmount);
            int fourOfAKindAmount = _vm.Evaluators.Sum(c => c.FourOfAKindAmount);
            int fullHouseAmount = _vm.Evaluators.Sum(c => c.FullHouseAmount);
            int flushAmount = _vm.Evaluators.Sum(c => c.FlushAmount);
            int straightAmount = _vm.Evaluators.Sum(c => c.StraightAmount);
            int threeOfAKindAmount = _vm.Evaluators.Sum(c => c.ThreeOfAKindAmount);
            int twoPairAmount = _vm.Evaluators.Sum(c => c.TwoPairAmount);
            int pairAmount = _vm.Evaluators.Sum(c => c.PairAmount);
            int highCardAmount = _vm.Evaluators.Sum(c => c.HighCardAmount);
            int totalAmount = _vm.Evaluators.Sum(c => c.HandValueAmount);

            _labelRoyalFlushAmount.Text = royalFlushAmount.ToString();
            _labelStraightFlushAmount.Text = straightFlushAmount.ToString();
            _labelFourOfAKindAmount.Text = fourOfAKindAmount.ToString();
            _labelFullHouseAmount.Text = fullHouseAmount.ToString();
            _labelFlushAmount.Text = flushAmount.ToString();
            _labelStraightAmount.Text = straightAmount.ToString();
            _labelThreeOfAKindAmount.Text = threeOfAKindAmount.ToString();
            _labelTwoPairAmount.Text = twoPairAmount.ToString();
            _labelPairAmount.Text = pairAmount.ToString();
            _labelHighCardAmount.Text = highCardAmount.ToString();
            _labelTotalAmount.Text = totalAmount.ToString();

            double royalFlushRatio = royalFlushAmount / (double)totalAmount;
            double straightFlushRatio = straightFlushAmount / (double)totalAmount;
            double fourOfAKindRatio = fourOfAKindAmount / (double)totalAmount;
            double fullHouseRatio = fullHouseAmount / (double)totalAmount;
            double flushRatio = flushAmount / (double)totalAmount;
            double straightRatio = straightAmount / (double)totalAmount;
            double threeOfAKindRatio = threeOfAKindAmount / (double)totalAmount;
            double twoPairRatio = twoPairAmount / (double)totalAmount;
            double pairRatio = pairAmount / (double)totalAmount;
            double highCardRatio = highCardAmount / (double)totalAmount;

            _labelRoyalFlushRatio.Text = FormatToPercetage(royalFlushRatio);
            _labelStraightFlushRatio.Text = FormatToPercetage(straightFlushRatio);
            _labelFourOfAKindRatio.Text = FormatToPercetage(fourOfAKindRatio);
            _labelFullHouseRatio.Text = FormatToPercetage(fullHouseRatio);
            _labelFlushRatio.Text = FormatToPercetage(flushRatio);
            _labelStraightRatio.Text = FormatToPercetage(straightRatio);
            _labelThreeOfAKindRatio.Text = FormatToPercetage(threeOfAKindRatio);
            _labelTwoPairRatio.Text = FormatToPercetage(twoPairRatio);
            _labelPairRatio.Text = FormatToPercetage(pairRatio);
            _labelHighCardRatio.Text = FormatToPercetage(highCardRatio);

            int totalRatioValue = (int)(totalAmount / (double)ExhaustiveHandEvaluator.CombinationsWith7 * 1000.0);
            _progressBar.Value = totalRatioValue;

            DateTime time = _endTime ?? DateTime.Now;
            TimeSpan timeEllapsed = time - _startTime;
            _labelTime.Text = timeEllapsed.TotalSeconds.ToString("0.0000 s");
        }

        private static string FormatToPercetage(double number)
        {
            double percent = number * 100;
            return $"{percent:0.0000} %";
        }
    }
}
