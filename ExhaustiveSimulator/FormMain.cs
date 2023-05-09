using System.Text;

namespace ExhaustiveSimulator
{
    public partial class FormMain : Form
    {
        private readonly MainViewModel _vm;
        private DateTime _startTime;
        private DateTime? _endTime;

        public FormMain()
        {
            _vm = new MainViewModel();
            Restart(7);
            InitializeComponent();
        }

        private void EvaluatorsHandler()
        {
            Task.WaitAll(_vm.Evaluators.Select(c => c.Task).ToArray());

            _endTime = DateTime.Now;

            int totalAmount = _vm.Evaluators.Sum(c => c.HandValueAmount);

            if (totalAmount == _vm.Evaluators.First().AmountOfCards)
            {
                var values = _vm.MergedHandValueAmounts;

                var sortedValues = values.ToList().OrderBy(c => c.Key);

                StringBuilder stringBuilder = new();

                foreach (var value in sortedValues)
                {
                    stringBuilder.AppendLine(value.Key.ToString() + "; " + value.Value.ToString());
                }

                File.WriteAllText("values.csv", stringBuilder.ToString());
            }
        }

        private void OnTimerUpdateValuesTick(object sender, EventArgs e)
        {
            List<ExhaustiveHandEvaluator> evaluators = _vm.Evaluators;

            int royalFlushAmount = evaluators.Sum(c => c.RoyalFlushAmount);
            int straightFlushAmount = evaluators.Sum(c => c.StraightFlushAmount);
            int fourOfAKindAmount = evaluators.Sum(c => c.FourOfAKindAmount);
            int fullHouseAmount = evaluators.Sum(c => c.FullHouseAmount);
            int flushAmount = evaluators.Sum(c => c.FlushAmount);
            int straightAmount = evaluators.Sum(c => c.StraightAmount);
            int threeOfAKindAmount = evaluators.Sum(c => c.ThreeOfAKindAmount);
            int twoPairAmount = evaluators.Sum(c => c.TwoPairAmount);
            int pairAmount = evaluators.Sum(c => c.PairAmount);
            int highCardAmount = evaluators.Sum(c => c.HighCardAmount);
            int totalAmount = evaluators.Sum(c => c.HandValueAmount);

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

            int totalRatioValue = (int)(totalAmount / (double)evaluators.First().Combinations * 1000.0);
            _progressBar.Value = totalRatioValue;

            if (evaluators.Any())
            {
                _labelCombinationsAmount.Text = evaluators.First().Combinations.ToString();
            }

            DateTime time = _endTime ?? DateTime.Now;
            TimeSpan timeEllapsed = time - _startTime;
            _labelTime.Text = timeEllapsed.TotalSeconds.ToString("0.0000 s");
        }

        private static string FormatToPercetage(double number)
        {
            double percent = number * 100;
            return $"{percent:0.0000} %";
        }

        private void OnButtonRestartClick(object sender, EventArgs e)
        {
            if (int.TryParse(_labelAmountOfCardsValue.Text, out int cardAmount) && cardAmount >= 5)
            {
                Restart(cardAmount);
            }
        }

        private void Restart(int cardAmount)
        {
            _startTime = DateTime.Now;
            _endTime = null;
            _vm.StartEvaluations(cardAmount, true);
            Task.Run(EvaluatorsHandler);
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            _vm.StopEvaluators();
        }
    }
}
