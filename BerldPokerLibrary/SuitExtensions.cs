namespace BerldPokerLibrary
{
    internal static class SuitExtensions
    {
        internal static readonly int SuitAmount;

        static SuitExtensions()
        {
            SuitAmount = Enum.GetNames(typeof(Suit)).Length;
        }
    }
}
