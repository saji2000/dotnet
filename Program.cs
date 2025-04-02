using dotnet.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndPoint = "GetGame";

List<GameDto> games = [new (1, "Gta 6", "Open World", 59.99M, new DateOnly(2026, 10, 20)), 
    new (2, "Gta 7", "Open World", 89.99M, new DateOnly(2046, 10, 20))];


// GET /games
app.MapGet("/games", () => games);

// GET /games/id
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndPoint);

// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDto game = new (
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
        );
    
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndPoint, new { id = game.Id }, game);
});

// PUT /games/id
app.MapPut("/games/{id}", (int id, UpdateGameDto game) =>
{
    var index = games.FindIndex(game => game.Id == id);
    Console.WriteLine(index);
    if (index != -1)
    {
        GameDto newGame = new (id, game.Name, game.Genre, game.Price, game.ReleaseDate);
        games[index] = newGame;
        return Results.CreatedAtRoute(GetGameEndPoint, new { id = newGame.Id }, newGame);
    }

    return Results.NotFound();



});

app.Run();