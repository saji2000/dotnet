namespace dotnet.Endpoints;
using dotnet.Dtos;

public static class GamesEndpoints
{
    const string GetGameEndPoint = "GetGame";

    private static readonly List<GameDto> games = [
        new (1, "Gta 6", "Open World", 59.99M, new DateOnly(2026, 10, 20)), 
        new (2, "Gta 7", "Open World", 89.99M, new DateOnly(2046, 10, 20))
    ];

    public static WebApplication MapGamesEndpoints(this WebApplication app)
    {
        // GET /games
        app.MapGet("/games", () => games);
        
        // GET /games/id
        app.MapGet("/games/{id}", (int id) =>
        {
            var index = games.FindIndex(game => game.Id == id);
        
            if (index != -1)
            {
                return Results.Ok(games[index]);
            }
            return Results.NotFound();
            
        }).WithName(GetGameEndPoint);
        
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
            if (index != -1)
            {
                GameDto newGame = new (id, game.Name, game.Genre, game.Price, game.ReleaseDate);
                games[index] = newGame;
                return Results.CreatedAtRoute(GetGameEndPoint, new { id = newGame.Id }, newGame);
            }
        
            return Results.NotFound();
        });
        
        app.MapDelete("/games/{id}", (int id) =>
        {
            var index = games.FindIndex(game => game.Id == id);
        
            if (index != -1)
            {
                games.RemoveAt(index);
                return Results.NoContent();
            }
        
            return Results.NotFound();
        });

        return app;
    }

}