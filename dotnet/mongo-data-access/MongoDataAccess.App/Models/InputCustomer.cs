namespace MongoDataAccess.App.Models;

public record InputCustomer(
    string? DBName = null,
    string? Name = null,
    string? Description = null,

    
    string? Phone = null,
    string? Address = null,
    string? Email = null,
    string? BankAccount = null,
    float? Ratings = null,
    IEnumerable<string>? Contacts = null,

    bool? IsAdult = null

) : InputPartner(
    Type: "type-customer",
    DBName: DBName,
    Name: Name,
    Description: Description,
    Phone: Phone,
    Address: Address,
    Email: Email,
    BankAccount: BankAccount,
    Ratings: Ratings,
    Contacts: Contacts
);