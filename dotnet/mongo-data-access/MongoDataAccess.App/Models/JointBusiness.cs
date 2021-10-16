namespace MongoDataAccess.App.Models;

internal record JointBusiness(
    string ID,
    string DBName,
    string Name,
    string Description,
    DateTime UpdateDate,
    DateTime DeleteDate,

    string Type,
    string Phone,
    string Address,
    string Email,
    string BankAccount,
    float Ratings,
    IEnumerable<string> Contacts,

    string WorkingHours
) : IJointBusiness;
