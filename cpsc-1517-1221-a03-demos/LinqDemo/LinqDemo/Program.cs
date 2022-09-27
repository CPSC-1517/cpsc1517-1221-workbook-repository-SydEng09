using LinqDemo;
using System.Runtime.CompilerServices;
using static System.Console;

var games = new List<VideoGame>
{
    new VideoGame("Diablo III", "Nintendo", 34.99,1),
    new VideoGame("NBA 2K20", "PlayStation", 49.99, 2),
    new VideoGame("NBA 2K20", "Nintendo", 49.99, 3),
    new VideoGame("NBA 2K20", "XBox", 49.99, 4),
    new VideoGame("Forza Horizon", "XBox", 39.99, 5),
    new VideoGame("Final Fantasy", "Nintendo", 34.99, 6),
    new VideoGame("The Outer Worlds","PlayStation", 19.99, 7),
    new VideoGame("Kingdom Hears 3", "Playstation", 19.99, 8),
    new VideoGame("Overwatch", "Nintendo", 34.99, 9),
    new VideoGame("WWE 2K20", "Playstation", 39.99, 10),
    new VideoGame("Kingdom Hears 3", "XBox", 19.99, 11),
    new VideoGame("Dragon Quest", "Playstation", 29.99, 12),
};

//foreach(VideoGame currentgame in games)
//{
//    Console.Write(currentgame);

//}
for(int i = 0; i < games.Count; i++)
{
    Console.WriteLine(games[i]);
}

games.ForEach(currentGame => WriteLine(currentGame));
games.ForEach(currentGame =>
{
    WriteLine(currentGame);
});

games.Where(currentGame => currentGame.Platform == "Nintendo").ToList()
    .ForEach(currentGame => WriteLine(currentGame));
    
var nintendoGameQuery = from currentGame in games 
                        where currentGame.Platform == "Nintendo"
                        select currentGame;
foreach(var currentGame in nintendoGameQuery)
{
    WriteLine(currentGame);
}

games.Select(currentGame => currentGame.Title)
    .ToList()
    .ForEach(title => WriteLine(title));

games.Select(currentGame => currentGame.Platform)
    .Distinct() //prevent duplicate titles from appearing
    .ToList()
    .ForEach(currentPlatform => WriteLine(currentPlatform));

double sumOfAllNinetendoGames = games.Where(item => item.Platform == "Nintendo")
    .Sum(item =>item.Price);

bool isAnyGamesLessThan20 = games.Any(item => item.Price < 20); //any games less then 20?
bool isAnyGamesLessThan50 = games.All(item => item.Price < 50); // all games less then 50
bool isNoPcGamesOnSales = !games.Any(item => item.Platform == "PC Games"); //Is there any PC games?