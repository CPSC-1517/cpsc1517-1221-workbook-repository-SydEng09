using System;

namespace OOPReview
{
    class Program
    {
        static void Main(string[] args)
        {
            var validPlayer1 = new Roster(97, "Connor McDavid", Position.C);
            Console.WriteLine(validPlayer1);

            try
            {
                Roster invalidPlayer1 = new Roster(100, "Leo", Position.C);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ParamName);
            }
            try
            {
                Roster invalidPlayer1 = new Roster(29, null, Position.C);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.ParamName);
            }
            try
            {
                Roster invalidPlayer1 = new Roster(29, "    ", Position.C);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.ParamName);
            }


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
