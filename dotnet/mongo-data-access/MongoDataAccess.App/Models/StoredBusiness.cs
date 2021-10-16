namespace MongoDataAccess.App.Models;

internal record StoredBusiness(
    string WorkingHours
) : IStoredBusiness;
