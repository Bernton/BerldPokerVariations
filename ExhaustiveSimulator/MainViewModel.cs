using BerldPokerLibrary;
using BerldPokerLibrary.HandEvaluation;
using System.Diagnostics;

namespace ExhaustiveSimulator
{
    internal class MainViewModel
    {
        internal List<ExhaustiveHandEvaluator> Evaluators { get; set; } = new List<ExhaustiveHandEvaluator>();

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

        internal void StartEvaluations(int amountOfCards, bool distribute)
        {
            foreach (ExhaustiveHandEvaluator evaluator in Evaluators)
            {
                evaluator.Dispose();
            }

            List<ExhaustiveHandEvaluator> newEvaluators = new();

            if (distribute)
            {
                for (int i = 0; i < Deck.CardAmount - amountOfCards + 1; i++)
                {
                    ExhaustiveHandEvaluator evaluator = new(amountOfCards, i);
                    evaluator.StartNew();
                    newEvaluators.Add(evaluator);
                }
            }
            else
            {
                ExhaustiveHandEvaluator evaluator = new(amountOfCards);
                evaluator.StartNew();
                newEvaluators.Add(evaluator);
            }

            Evaluators = newEvaluators;
        }

        internal void StopEvaluators()
        {
            foreach (ExhaustiveHandEvaluator evaluator in Evaluators)
            {
                evaluator.Dispose();
            }
        }
    }
}
