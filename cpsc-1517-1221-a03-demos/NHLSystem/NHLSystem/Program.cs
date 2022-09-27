// See https://aka.ms/new-console-template for more information
using NHLSystem;
using System.Net.Http.Headers;
using System.IO;
using System.Text.Json;

//var validPerson = new Person("Connor McDavid");
//Console.WriteLine(validPerson.FullName);

//try
//{
//    var nullPerson = new Person(null);
//    Console.WriteLine("Null test case failed");
//}
//catch(ArgumentException ex)
//{
//    Console.WriteLine(ex.ParamName);
//}

//try
//{
//    var emptyPerson = new Person("");
//    Console.WriteLine("Blank test case failed");
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine(ex.ParamName);
//}

//try
//{
//    var whitespacePerson = new Person("     ");
//    Console.WriteLine("Whitespace test case failed");
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var invalidlenghtPerson = new Person("AB");
//    Console.WriteLine("Min lenght test case failed");
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine(ex.Message);
//}
DateTime startDate = DateTime.Parse("2021-09-02");
Coach oilersCoach = new Coach("Jay Woodcroft", startDate);
Team oilerTeam = new Team("Oilers", oilersCoach);
Player player1 = new Player("Connor Mcdavid", Position.C, 97);
Player player2 = new Player("Evander Kane", Position.LW, 91);
Player player3 = new Player("Leeon Drasittl", Position.C, 29);
oilerTeam.Players.Add(player1);
oilerTeam.Players.Add(player2);
oilerTeam.Players.Add(player3);
player1.Goals = 44;
player1.Assists = 79;
player2.Goals = 22;
player2.Assists = 17;
player3.Goals = 55;
player3.Assists = 55;

Console.WriteLine($"Players in team is {oilerTeam.Players.Count}");
foreach(Player currentplayer in oilerTeam.Players)
{
    Console.WriteLine(currentplayer);
}
Console.WriteLine($"Total player points is {oilerTeam.TotalPlayerPoints}");

CreatePlayersCsvFile();
CreateTeamJsonFile();

var Team = ReadTeamInfoFromJsonFile();
//var Team = ReadPlayerCsvFile();
DisplayTeamInfo(Team);

static void CreatePlayersCsvFile()// CreateTeamJsonFile
{
    DateTime startDate = DateTime.Parse("2021-09-02");
    Coach oilersCoach = new Coach("Jay Woodcroft", startDate);
    Team oilerTeam = new Team("Oilers", oilersCoach);
    Player player1 = new Player("Connor Mcdavid", Position.C, 97);
    Player player2 = new Player("Evander Kane", Position.LW, 91);
    Player player3 = new Player("Leeon Drasittl", Position.C, 29);
    oilerTeam.Players.Add(player1);
    oilerTeam.Players.Add(player2);
    oilerTeam.Players.Add(player3);

    const string PLayerCsvFile = "../../../Players.csv";
    System.IO.File.WriteAllLines(PLayerCsvFile, oilerTeam.Players
        .Select(currentPlayer => currentPlayer.ToString())
        .ToList());
}

static Team ReadPlayerCsvFile()
{
    const string PLayerCsvFile = "../../../Players.csv";
    Coach teamCoach = new Coach("Jay Woodcroft", DateTime.Parse("2022-02-10"));
    Team oilersTeam = new Team("Edmonton Oilers", teamCoach);
    try
    {
        string[] allLines = File.ReadAllLines(PLayerCsvFile);
        foreach(string currentLine in allLines)
        {
            try
            {
                Player currentPlayer = null;
                bool success = Player.TryParse(currentLine, out currentPlayer);
                if (success)
                {
                    oilersTeam.AddPlayer(currentPlayer);
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Format exception {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error parsing data from line with execption {ex.Message}");
            }
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Error reading from file with exception {ex.Message}");
    }
    return oilersTeam;
}

static void DisplayTeamInfo(Team currentTeam)
{
    if (currentTeam == null)
    {
        Console.WriteLine("There is no team supplied");

    }
    else
    {
        Console.WriteLine($"Team: {currentTeam.TeamName}");
        Console.WriteLine($"Coach: {currentTeam.Coach} hired on {currentTeam.Coach.StartDate.ToString("MMM dd, yyyy")}");
        foreach (Player currentPLayer in currentTeam.Players)
        {
            Console.WriteLine(currentPLayer.ToString());
        };
    }
}
 
static Team ReadTeamInfoFromJsonFile()
    {
        Team currentTeam = null!;
        try
        {
            const string TeamJsonFile = "../../../Players.json";
            string jsonString = File.ReadAllText(TeamJsonFile);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
            };
            currentTeam = JsonSerializer.Deserialize<Team>(jsonString, options);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error reading from json file with exception {ex.Message}");
        }
        return currentTeam;
    }
    static void CreateTeamJsonFile()
    {
        DateTime startDate = DateTime.Parse("2021-09-02");
        Coach oilersCoach = new Coach("Jay Woodcroft", startDate);
        Team oilerTeam = new Team("Oilers", oilersCoach);
        Player player1 = new Player("Connor Mcdavid", Position.C, 97);
        Player player2 = new Player("Evander Kane", Position.LW, 91);
        Player player3 = new Player("Leeon Drasittl", Position.C, 29);
        oilerTeam.Players.Add(player1);
        oilerTeam.Players.Add(player2);
        oilerTeam.Players.Add(player3);

        const string TeamJsonFile = "../../../Players.json";
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };
        string jsonString = JsonSerializer.Serialize<Team>(oilerTeam, options);
        File.WriteAllText(TeamJsonFile, jsonString);
    } 





