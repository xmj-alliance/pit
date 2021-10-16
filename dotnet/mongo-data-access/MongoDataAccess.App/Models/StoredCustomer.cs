namespace MongoDataAccess.App.Models;

internal record StoredCustomer(
    bool IsAdult
) : IStoredCustomer;
