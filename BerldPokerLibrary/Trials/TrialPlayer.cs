namespace BerldPokerLibrary.Trials
{
    public class TrialPlayer
    {
        internal List<Card> HoleCards { get; }

        internal int TrialAmount { get; set; }

        public double Equity => TrialAmount > 0 ? TotalEquity / TrialAmount : 0;

        internal double TotalEquity { get; set; }

        public TrialPlayer(List<Card> holeCards)
        {
            if (holeCards is null)
            {
                throw new ArgumentNullException(nameof(holeCards));
            }

            if (holeCards.Count > 2)
            {
                throw new ArgumentException("Must have count of 2 or less.", nameof(holeCards));
            }

            HoleCards = holeCards;
        }
    }
}
