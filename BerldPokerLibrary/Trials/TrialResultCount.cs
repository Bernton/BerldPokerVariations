using System.Text;

namespace BerldPokerLibrary.Trials
{
    public class TrialResultCount
    {
        private readonly double[] _counts = new double[10];

        public double RoyalFlush
        {
            get => _counts[0];
            set => _counts[0] = value;
        }

        public double StraightFlush
        {
            get => _counts[1];
            set => _counts[1] = value;
        }

        public double FourOfAKind
        {
            get => _counts[2];
            set => _counts[2] = value;
        }

        public double FullHouse
        {
            get => _counts[3];
            set => _counts[3] = value;
        }

        public double Flush
        {
            get => _counts[4];
            set => _counts[4] = value;
        }

        public double Straight
        {
            get => _counts[5];
            set => _counts[5] = value;
        }

        public double ThreeOfAKind
        {
            get => _counts[6];
            set => _counts[6] = value;
        }


        public double TwoPair
        {
            get => _counts[7];
            set => _counts[7] = value;
        }

        public double Pair
        {
            get => _counts[8];
            set => _counts[8] = value;
        }

        public double HighCard
        {
            get => _counts[9];
            set => _counts[9] = value;
        }

        public string ToString(double totalEquity)
        {
            StringBuilder builder = new();

            for (int i = 0; i < _counts.Length; i++)
            {
                double percentage = _counts[i] / totalEquity * 100.0;
                builder.AppendLine($"{NameForIndex(i)}: {_counts[i]} ({percentage:G2}%)");
            }

            return builder.ToString();
        }

        public override string ToString()
        {
            double sum = _counts.Sum();
            return ToString(sum);
        }

        private static string NameForIndex(int index)
        {
            return index switch
            {
                0 => "Royal flush",
                1 => "Straight flush",
                2 => "Four of a kind",
                3 => "Full house",
                4 => "Flush",
                5 => "Straight",
                6 => "Three of a kind",
                7 => "Two pair",
                8 => "Pair",
                9 => "High card",
                _ => throw new IndexOutOfRangeException()
            };
        }
    }
}
