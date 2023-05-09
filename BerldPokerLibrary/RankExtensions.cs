namespace BerldPokerLibrary
{
    internal static class RankExtensions
    {
        internal static readonly int RankAmount;

        static RankExtensions()
        {
            RankAmount = Enum.GetNames(typeof(Rank)).Length;
        }

        internal static string ToPlural(this Rank rank)
        {
            if (rank == Rank.Six)
            {
                return $"{rank}es";
            }

            return $"{rank}s";
        }
    }
}
