namespace MongoDataAccess.App.Models;

internal record InputCustomer(
    string? DBName,
    string? Name,
    string? Description,

    string Type,
    string? Phone,
    string? Address,
    string? Email,
    string? BankAccount,
    float? Ratings,
    IEnumerable<string>? Partners,

    bool IsAdult

) : InputPartner(
    DBName,
    Name,
    Description,
    Type,
    Phone,
    Address,
    Email,
    BankAccount,
    Ratings,
    Partners
);