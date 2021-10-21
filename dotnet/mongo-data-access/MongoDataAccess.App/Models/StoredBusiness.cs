namespace MongoDataAccess.App.Models;

public record StoredBusiness(
    string WorkingHours
) : IStoredBusiness;
