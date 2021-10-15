internal record InputPartner(
    string? DBName,
    string? Name,
    string? Description,

    string Type,
    string? Phone,
    string? Address,
    string? Email,
    string? BankAccount,
    float? Ratings,
    IEnumerable<string>? Partners
): IBaseInputModel;