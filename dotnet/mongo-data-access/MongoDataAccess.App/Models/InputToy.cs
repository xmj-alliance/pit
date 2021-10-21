namespace MongoDataAccess.App.Models;

public record InputToy(
    string? DBName = null,
    string? Name = null,
    string? Description = null,

    bool? HasAgeLimit = null,
    decimal? Price = null
) : IBaseInputModel;