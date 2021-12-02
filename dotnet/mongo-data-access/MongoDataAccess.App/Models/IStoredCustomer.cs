namespace MongoDataAccess.App.Models;

public interface IStoredCustomer
{
    string ID { get; }
    string DBName { get; }
    bool IsAdult { get; }
}
