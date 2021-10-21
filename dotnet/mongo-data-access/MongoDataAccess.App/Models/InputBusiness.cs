namespace MongoDataAccess.App.Models;

public record InputBusiness(
    string Type,

    string? DBName = null,
    string? Name = null,
    string? Description = null,

    
    string? Phone = null,
    string? Address = null,
    string? Email = null,
    string? BankAccount = null,
    float? Ratings = null,
    IEnumerable<string>? Partners = null,

    string? WorkingHours = null
) : InputPartner(
    Type: Type,

    DBName: DBName,
    Name: Name,
    Description: Description,
    Phone: Phone,
    Address: Address,
    Email: Email,
    BankAccount: BankAccount,
    Ratings: Ratings,
    Partners: Partners
);
