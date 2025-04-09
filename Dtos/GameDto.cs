using System.ComponentModel.DataAnnotations;

namespace dotnet.Dtos;

public record GameDto(
    [Required] int Id, 
    [Required][StringLength(50)] string Name, 
    [Required][StringLength(50)] string Genre, 
    [Required][Range(0, 200)] decimal Price,
    DateOnly ReleaseDate
);