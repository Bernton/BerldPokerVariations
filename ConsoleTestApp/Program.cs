using BerldPokerLibrary;
using BerldPokerLibrary.Trials;

List<Card> boardCards = new()
{

};

List<TrialPlayer> trialPlayers = new()
{
    new(new()
    {
        new(Rank.Ace, Suit.Spades),
        new(Rank.Ace, Suit.Clubs)
    }),
    new(new()
    {

    })
};

TrialRunner runner = new(trialPlayers, boardCards);

DateTime startTime = DateTime.Now;

runner.Start(100000);

DateTime endTime = DateTime.Now;

TimeSpan runnerTime = endTime - startTime;

foreach (TrialPlayer player in trialPlayers)
{
    Console.WriteLine($"{player.Equity}");
}

Console.WriteLine($"{runner.TrialAmount} trials in {runnerTime.TotalMilliseconds} ms");