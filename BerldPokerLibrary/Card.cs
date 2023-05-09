namespace BerldPokerLibrary
{
    public struct Card
    {
        internal Rank Rank { get; set; }
        internal Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public Card(int index)
        {
            if (index < 0 || index >= 52)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Card index must be 0 or greater and smaller than 52.");
            }

            Rank = (Rank)(index / SuitExtensions.SuitAmount);
            Suit = (Suit)(index % SuitExtensions.SuitAmount);
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
