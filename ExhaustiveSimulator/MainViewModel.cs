using BerldPokerLibrary;
using BerldPokerLibrary.HandEvaluation;
using System.Diagnostics;

namespace ExhaustiveSimulator
{
    internal class MainViewModel
    {
        internal ExhaustiveHandEvaluator? Evaluator { get; set; }

        internal void StartEvaluation(int amountOfCards)
        {
            Evaluator?.Dispose();

            ExhaustiveHandEvaluator evaluator = new(amountOfCards);
            evaluator.StartNew();
            Evaluator = evaluator;
        }

        internal void StopEvaluation()
        {
            Evaluator?.Dispose();
        }
    }
}
