internal record Partner(
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
    IEnumerable<string> Partners
) : IPartner;