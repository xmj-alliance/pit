internal record JointCustomer(
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
    Partner Contacts,

    bool IsAdult
) : IJointCustomer;