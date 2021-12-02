namespace MongoDataAccess.App.Models;

public record InputPartner(
    string Type,

    string? DBName = null,
    string? Name = null,
    string? Description = null,

    string? Phone = null,
    string? Address = null,
    string? Email = null,
    string? BankAccount = null,
    float? Ratings = null,
    IEnumerable<string>? Contacts = null
) : IBaseInputModel;