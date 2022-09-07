using System;

namespace OOPReview
{
    class Program
    {
        static void Main(string[] args)
        {
            var senators = new NhlTeam(
                NHLConference.Eastern,
                NHLDivision.Atlantic,
                "Senators",
                "Ottawa");
            senators.GamesPlayed = 82;
            senators.Wins = 33;
            senators.Losses = 42;
            senators.OvertimeLosses = 7;

            Console.WriteLine(senators);
            Console.WriteLine($"Points={senators.Points}");
        }
    }
}
