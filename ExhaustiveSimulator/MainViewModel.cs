using BerldPokerLibrary;
using BerldPokerLibrary.HandEvaluation;

namespace ExhaustiveSimulator
{
    internal class MainViewModel
    {
        internal event Action? AllEvaluatorsFinished;
        internal List<ExhaustiveHandEvaluator> Evaluators { get; set; }

        internal Dictionary<HandValue, int> MergedHandValueAmounts
        {
            get
            {
                Dictionary<HandValue, int> value = new();

                for (int i = 0; i < Evaluators.Count; i++)
                {
                    ExhaustiveHandEvaluator evaluator = Evaluators[i];

                    foreach (var entry in evaluator.HandValueAmounts)
                    {
                        HandValue handValue = entry.Key;

                        if (value.ContainsKey(handValue))
                        {
                            value[handValue] += entry.Value;
                        }
                        else
                        {
                            value[handValue] = entry.Value;
                        }
                    }
                }

                return value;
            }
        }

        internal MainViewModel()
        {
            Evaluators = new List<ExhaustiveHandEvaluator>();

            for (int i = 0; i < Deck.CardAmount; i++)
            {
                ExhaustiveHandEvaluator evaluator = new(i);
                evaluator.StartNew();
                Evaluators.Add(evaluator);
            }

            Task.Run(() =>
            {
                Task.WaitAll(Evaluators.Select(c => c.Task).ToArray());
                AllEvaluatorsFinished?.Invoke();
            });
        }
    }
}
