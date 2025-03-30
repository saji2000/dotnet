using dotnet.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [new (1, "Gta 6", "Open World", 59.99M, new DateOnly(2026, 10, 20)), 
    new (2, "Gta 7", "Open World", 89.99M, new DateOnly(2046, 10, 20))];

app.MapGet("/Games", () => games);

app.MapGet("/", () => "Hello World!");

app.Run();