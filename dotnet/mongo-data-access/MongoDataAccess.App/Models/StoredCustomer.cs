namespace MongoDataAccess.App.Models;

public record StoredCustomer(
    bool IsAdult
) : IStoredCustomer;
