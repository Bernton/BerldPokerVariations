using BerldPokerLibrary;
using BerldPokerLibrary.Trials;
using System.Numerics;

//Mode  Max iterations
//0	    1
//0_2	1081
//1	    46
//1_2	45540
//2	    1081
//2_2	1070190
//3	    17296
//4	    211876
//5	    2118760
//5_2	2097572400

List<Card> boardCards = new()
{
};

List<TrialPlayer> trialPlayers = new()
{
    new(new()
    {
        new(Rank.King, Suit.Spades),
        new(Rank.King, Suit.Clubs)
    }),
    new(new()
    {
        new(Rank.King, Suit.Hearts),
        new(Rank.Deuce, Suit.Spades)
    }),
    //new(new()
    //{
    //    new(Rank.Jack, Suit.Hearts),
    //    new(Rank.Ten, Suit.Hearts)
    //}),
};

TrialRunner runner = new(trialPlayers, boardCards, true);

DateTime startTime = DateTime.Now;

runner.Start();

DateTime endTime = DateTime.Now;

TimeSpan runnerTime = endTime - startTime;

foreach (TrialPlayer player in trialPlayers)
{
    Console.WriteLine($"{player.Equity}");
}

double trialsPerMillisecond = runner.TrialAmount / runnerTime.TotalMilliseconds;

string insert = runner.WereRandomTrials ? "random" : "exhaustive";
Console.WriteLine($"{runner.TrialAmount} {insert} trials in {runnerTime.TotalMilliseconds} ms");
Console.WriteLine($"{trialsPerMillisecond:0.0} trials/ms");
Console.WriteLine(string.Empty);

for (int i = 0; i < runner.Players.Count; i++)
{
    TrialPlayer player = runner.Players[i];
    var playerCards = player.Cards;

    Console.WriteLine($"Player {(i + 1)} - [{playerCards[0]}] [{playerCards[1]}]");
    Console.WriteLine("--------------------");
    Console.WriteLine(player.WinnerCount.ToString(runner.TrialAmount));
    Console.WriteLine(string.Empty);
}

//// Coinflip
//List<Card> boardCards = new()
//{
//};
//
//List<TrialPlayer> trialPlayers = new()
//{
//    new(new()
//    {
//        new(Rank.Ace, Suit.Spades),
//        new(Rank.Ten, Suit.Spades)
//    }),
//    new(new()
//    {
//        new(Rank.Tray, Suit.Spades),
//        new(Rank.Tray, Suit.Diamonds)
//    })
//};

//// Perfect Coinflip with Flop
//List<Card> boardCards = new()
//{
//    new(Rank.Ten, Suit.Spades),
//    new(Rank.Nine, Suit.Hearts),
//    new(Rank.Deuce, Suit.Clubs)
//};

//List<TrialPlayer> trialPlayers = new()
//{
//    new(new()
//    {
//        new(Rank.Ace, Suit.Diamonds),
//        new(Rank.Ten, Suit.Diamonds)
//    }),
//    new(new()
//    {
//        new(Rank.Queen, Suit.Diamonds),
//        new(Rank.Jack, Suit.Diamonds)
//    })
//};