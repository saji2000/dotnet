using System.ComponentModel.DataAnnotations;

namespace dotnet.Dtos;

public record UpdateGameDto(
    [Required][StringLength(50)] string Name, 
    [Required][StringLength(50)] string Genre, 
    [Required][Range(1, 200)] decimal Price,
    DateOnly ReleaseDate
);